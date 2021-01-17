﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// <auto-generated>

namespace Roslynator.CSharp
{
    public static partial class AnalyzerOptionDescriptors
    {
        internal static readonly AnalyzerOptionDescriptor SuppressUnityScriptMethods = new AnalyzerOptionDescriptor(null, DiagnosticDescriptors.RemoveUnusedMemberDeclaration, "roslynator.RCS1213.suppress_unity_script_methods");
        internal static readonly AnalyzerOptionDescriptor UseImplicitlyTypedArrayWhenTypeIsObvious = new AnalyzerOptionDescriptor(AnalyzerOptions.UseImplicitlyTypedArrayWhenTypeIsObvious, DiagnosticDescriptors.UseExplicitlyTypedArrayOrViceVersa, "roslynator.RCS1014.use_implicit_when_obvious");
        internal static readonly AnalyzerOptionDescriptor ConvertExpressionBodyToBlockBodyWhenExpressionIsMultiLine = new AnalyzerOptionDescriptor(AnalyzerOptions.ConvertExpressionBodyToBlockBodyWhenExpressionIsMultiLine, DiagnosticDescriptors.ConvertBlockBodyToExpressionBodyOrViceVersa, "roslynator.RCS1016.use_block_body_when_expression_is_multiline");
        internal static readonly AnalyzerOptionDescriptor RemoveEmptyLineBetweenClosingBraceAndSwitchSection = new AnalyzerOptionDescriptor(AnalyzerOptions.RemoveEmptyLineBetweenClosingBraceAndSwitchSection, DiagnosticDescriptors.RemoveRedundantEmptyLine, "roslynator.RCS1036.remove_empty_line_between_closing_brace_and_switch_section");
        internal static readonly AnalyzerOptionDescriptor DoNotRenamePrivateStaticReadOnlyFieldToCamelCaseWithUnderscore = new AnalyzerOptionDescriptor(AnalyzerOptions.DoNotRenamePrivateStaticReadOnlyFieldToCamelCaseWithUnderscore, DiagnosticDescriptors.RenamePrivateFieldToCamelCaseWithUnderscore, "roslynator.RCS1045.suppress_private_static_readonly_field");
        internal static readonly AnalyzerOptionDescriptor RemoveParenthesesFromConditionOfConditionalExpressionWhenExpressionIsSingleToken = new AnalyzerOptionDescriptor(AnalyzerOptions.RemoveParenthesesFromConditionOfConditionalExpressionWhenExpressionIsSingleToken, DiagnosticDescriptors.ParenthesizeConditionOfConditionalExpression, "roslynator.RCS1051.do_not_parenthesize_single_token");
        internal static readonly AnalyzerOptionDescriptor SimplifyConditionalExpressionWhenItIncludesNegationOfCondition = new AnalyzerOptionDescriptor(AnalyzerOptions.SimplifyConditionalExpressionWhenItIncludesNegationOfCondition, DiagnosticDescriptors.SimplifyConditionalExpression, "roslynator.RCS1104.allow_negation");
        internal static readonly AnalyzerOptionDescriptor DoNotUseElementAccessWhenExpressionIsInvocation = new AnalyzerOptionDescriptor(AnalyzerOptions.DoNotUseElementAccessWhenExpressionIsInvocation, DiagnosticDescriptors.UseElementAccess, "roslynator.RCS1246.suppress_when_expression_is_invocation");
        internal static readonly AnalyzerOptionDescriptor UseIsNullPatternInsteadOfInequalityOperator = new AnalyzerOptionDescriptor(AnalyzerOptions.UseIsNullPatternInsteadOfInequalityOperator, DiagnosticDescriptors.UseIsNullPatternInsteadOfComparisonOrViceVersa, "roslynator.RCS1248.support_inequality_operator");
        internal static readonly AnalyzerOptionDescriptor ConvertExpressionBodyToBlockBodyWhenDeclarationIsMultiLine = new AnalyzerOptionDescriptor(AnalyzerOptions.ConvertExpressionBodyToBlockBodyWhenDeclarationIsMultiLine, DiagnosticDescriptors.ConvertBlockBodyToExpressionBodyOrViceVersa, "roslynator.RCS1016.use_block_body_when_declaration_is_multiline");
        internal static readonly AnalyzerOptionDescriptor UseImplicitlyTypedArray = new AnalyzerOptionDescriptor(AnalyzerOptions.UseImplicitlyTypedArray, DiagnosticDescriptors.UseExplicitlyTypedArrayOrViceVersa, "roslynator.RCS1014.invert");
        internal static readonly AnalyzerOptionDescriptor RemoveAccessibilityModifiers = new AnalyzerOptionDescriptor(AnalyzerOptions.RemoveAccessibilityModifiers, DiagnosticDescriptors.AddAccessibilityModifiersOrViceVersa, "roslynator.RCS1018.invert");
        internal static readonly AnalyzerOptionDescriptor RemoveArgumentListFromObjectCreation = new AnalyzerOptionDescriptor(AnalyzerOptions.RemoveArgumentListFromObjectCreation, DiagnosticDescriptors.AddArgumentListToObjectCreationOrViceVersa, "roslynator.RCS1050.invert");
        internal static readonly AnalyzerOptionDescriptor UseStringEmptyInsteadOfEmptyStringLiteral = new AnalyzerOptionDescriptor(AnalyzerOptions.UseStringEmptyInsteadOfEmptyStringLiteral, DiagnosticDescriptors.UseEmptyStringLiteralInsteadOfStringEmptyOrViceVersa, "roslynator.RCS1078.invert");
        internal static readonly AnalyzerOptionDescriptor RemoveCallToConfigureAwait = new AnalyzerOptionDescriptor(AnalyzerOptions.RemoveCallToConfigureAwait, DiagnosticDescriptors.AddCallToConfigureAwaitOrViceVersa, "roslynator.RCS1090.invert");
        internal static readonly AnalyzerOptionDescriptor ConvertBitwiseOperationToHasFlagCall = new AnalyzerOptionDescriptor(AnalyzerOptions.ConvertBitwiseOperationToHasFlagCall, DiagnosticDescriptors.ConvertHasFlagCallToBitwiseOperationOrViceVersa, "roslynator.RCS1096.invert");
        internal static readonly AnalyzerOptionDescriptor ConvertMethodGroupToAnonymousFunction = new AnalyzerOptionDescriptor(AnalyzerOptions.ConvertMethodGroupToAnonymousFunction, DiagnosticDescriptors.ConvertAnonymousFunctionToMethodGroupOrViceVersa, "roslynator.RCS1207.invert");
        internal static readonly AnalyzerOptionDescriptor UseComparisonInsteadOfIsNullPattern = new AnalyzerOptionDescriptor(AnalyzerOptions.UseComparisonInsteadOfIsNullPattern, DiagnosticDescriptors.UseIsNullPatternInsteadOfComparisonOrViceVersa, "roslynator.RCS1248.invert");
    }
}