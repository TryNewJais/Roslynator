﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace Roslynator.CSharp.Analysis
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class UseExplicitlyTypedArrayOrViceVersaAnalyzer : BaseDiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(DiagnosticDescriptors.UseExplicitlyTypedArrayOrViceVersa); }
        }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);

            context.RegisterSyntaxNodeAction(
                c =>
                {
                    if (AnalyzerOptions.UseImplicitlyTypedArrayWhenTypeIsObvious.IsEnabled(c)
                        || !AnalyzerOptions.UseImplicitlyTypedArray.IsEnabled(c))
                    {
                        AnalyzeImplicitArrayCreationExpression(c);
                    }
                },
                SyntaxKind.ImplicitArrayCreationExpression);

            context.RegisterSyntaxNodeAction(
                c =>
                {
                    if (AnalyzerOptions.UseImplicitlyTypedArrayWhenTypeIsObvious.IsEnabled(c)
                        || AnalyzerOptions.UseImplicitlyTypedArray.IsEnabled(c))
                    {
                        AnalyzeArrayCreationExpression(c);
                    }
                },
                SyntaxKind.ArrayCreationExpression);
        }

        private static void AnalyzeImplicitArrayCreationExpression(SyntaxNodeAnalysisContext context)
        {
            var expression = (ImplicitArrayCreationExpressionSyntax)context.Node;

            if (expression.ContainsDiagnostics)
                return;

            if (expression.NewKeyword.ContainsDirectives)
                return;

            if (expression.OpenBracketToken.ContainsDirectives)
                return;

            if (expression.CloseBracketToken.ContainsDirectives)
                return;

            if (AnalyzerOptions.UseImplicitlyTypedArrayWhenTypeIsObvious.IsEnabled(context))
            {
                InitializerExpressionSyntax initializer = expression.Initializer;

                if (initializer != null)
                {
                    var isObvious = false;

                    foreach (ExpressionSyntax expression2 in initializer.Expressions)
                    {
                        isObvious = CSharpTypeAnalysis.IsTypeObvious(expression2, null, context.SemanticModel, context.CancellationToken);

                        if (!isObvious)
                            break;
                    }

                    if (isObvious)
                        return;
                }
            }

            if (!(context.SemanticModel.GetTypeSymbol(expression, context.CancellationToken) is IArrayTypeSymbol arrayTypeSymbol))
                return;

            if (!arrayTypeSymbol.ElementType.SupportsExplicitDeclaration())
                return;

            DiagnosticHelpers.ReportDiagnostic(
                context,
                DiagnosticDescriptors.UseExplicitlyTypedArrayOrViceVersa,
                Location.Create(expression.SyntaxTree, TextSpan.FromBounds(expression.NewKeyword.SpanStart, expression.CloseBracketToken.Span.End)));
        }

        private static void AnalyzeArrayCreationExpression(SyntaxNodeAnalysisContext context)
        {
            var arrayCreation = (ArrayCreationExpressionSyntax)context.Node;

            if (arrayCreation.ContainsDiagnostics)
                return;

            ArrayTypeSyntax arrayType = arrayCreation.Type;

            if (arrayType.ContainsDirectives)
                return;

            SeparatedSyntaxList<ExpressionSyntax> expressions = arrayCreation.Initializer?.Expressions ?? default;

            if (!expressions.Any())
                return;

            if (AnalyzerOptions.UseImplicitlyTypedArrayWhenTypeIsObvious.IsEnabled(context))
            {
                foreach (ExpressionSyntax expression in expressions)
                {
                    if (!CSharpTypeAnalysis.IsTypeObvious(expression, null, context.SemanticModel, context.CancellationToken))
                        return;
                }
            }

            TypeSyntax elementType = arrayType.ElementType;
            SyntaxList<ArrayRankSpecifierSyntax> rankSpecifiers = arrayType.RankSpecifiers;

            TextSpan textSpan = TextSpan.FromBounds(
                elementType.SpanStart,
                ((rankSpecifiers.Count > 1) ? rankSpecifiers.LastButOne() : (SyntaxNode)elementType).Span.End);

            DiagnosticHelpers.ReportDiagnostic(
                context,
                DiagnosticDescriptors.ReportOnly.UseImplicitlyTypedArray,
                Location.Create(arrayCreation.SyntaxTree, textSpan));
        }
    }
}
