// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

#pragma warning disable RCS1223

namespace Roslynator
{
    public abstract class DiagnosticComparer : IComparer<Diagnostic>, IEqualityComparer<Diagnostic>, IComparer, IEqualityComparer
    {
        public static DiagnosticComparer Id { get; } = new DiagnosticIdComparer();

        public static DiagnosticComparer SpanStart { get; } = new DiagnosticSpanStartComparer();

        internal static DiagnosticComparer IdThenFilePathThenSpanStart { get; } = new DiagnosticIdThenFilePathThenSpanStartComparer();

        private StringComparer Comparer => StringComparer.CurrentCulture;

        private StringComparer PathComparer => FileSystemHelpers.CultureComparer;

        public abstract int Compare(Diagnostic x, Diagnostic y);

        public abstract bool Equals(Diagnostic x, Diagnostic y);

        public abstract int GetHashCode(Diagnostic obj);

        public int Compare(object x, object y)
        {
            if (x == y)
                return 0;

            if (x == null)
                return -1;

            if (y == null)
                return 1;

            if (x is Diagnostic a
                && y is Diagnostic b)
            {
                return Compare(a, b);
            }

            throw new ArgumentException("", nameof(x));
        }

        new public bool Equals(object x, object y)
        {
            if (x == y)
                return true;

            if (x == null)
                return false;

            if (y == null)
                return false;

            if (x is Diagnostic a
                && y is Diagnostic b)
            {
                return Equals(a, b);
            }

            throw new ArgumentException("", nameof(x));
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
                return 0;

            if (obj is Diagnostic diagnostic)
                return GetHashCode(diagnostic);

            throw new ArgumentException("", nameof(obj));
        }

        private class DiagnosticIdComparer : DiagnosticComparer
        {
            public override int Compare(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return 0;

                if (x == null)
                    return -1;

                if (y == null)
                    return 1;

                return Comparer.Compare(x.Id, y.Id);
            }

            public override bool Equals(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return true;

                if (x == null)
                    return false;

                if (y == null)
                    return false;

                return Comparer.Equals(x.Id, y.Id);
            }

            public override int GetHashCode(Diagnostic obj)
            {
                if (obj == null)
                    return 0;

                return Comparer.GetHashCode(obj.Id);
            }
        }

        private class DiagnosticSpanStartComparer : DiagnosticComparer
        {
            public override int Compare(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return 0;

                if (x == null)
                    return -1;

                if (y == null)
                    return 1;

                return x.Location.SourceSpan.Start.CompareTo(y.Location.SourceSpan.Start);
            }

            public override bool Equals(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return true;

                if (x == null)
                    return false;

                if (y == null)
                    return false;

                return x.Location.SourceSpan.Start == y.Location.SourceSpan.Start;
            }

            public override int GetHashCode(Diagnostic obj)
            {
                if (obj == null)
                    return 0;

                return obj.Location.SourceSpan.Start.GetHashCode();
            }
        }

        private class DiagnosticIdThenFilePathThenSpanStartComparer : DiagnosticComparer
        {
            public override int Compare(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return 0;

                if (x == null)
                    return -1;

                if (y == null)
                    return 1;

                int result = Comparer.Compare(x.Id, y.Id);

                if (result != 0)
                    return result;

                result = PathComparer.Compare(x.Location.SourceTree?.FilePath, y.Location.SourceTree?.FilePath);

                if (result != 0)
                    return result;

                return x.Location.SourceSpan.Start.CompareTo(y.Location.SourceSpan.Start);
            }

            public override bool Equals(Diagnostic x, Diagnostic y)
            {
                if (object.ReferenceEquals(x, y))
                    return true;

                if (x == null)
                    return false;

                if (y == null)
                    return false;

                return Comparer.Equals(x.Id, y.Id)
                    && PathComparer.Equals(x.Location.SourceTree?.FilePath, y.Location.SourceTree?.FilePath)
                    && x.Location.SourceSpan.Start == y.Location.SourceSpan.Start;
            }

            public override int GetHashCode(Diagnostic obj)
            {
                if (obj == null)
                    return 0;

                return Hash.Combine(
                    Comparer.GetHashCode(obj.Id),
                    Hash.Combine(
                        PathComparer.GetHashCode(obj.Location.SourceTree?.FilePath),
                        obj.Location.SourceSpan.Start));
            }
        }
    }
}
