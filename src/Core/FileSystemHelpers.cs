// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Roslynator
{
    internal static class FileSystemHelpers
    {
        public static bool IsCaseSensitive { get; } = GetIsCaseSensitive();

        public static StringComparer Comparer { get; }
            = (IsCaseSensitive) ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;

        public static StringComparer CultureComparer { get; }
            = (IsCaseSensitive) ? StringComparer.CurrentCulture : StringComparer.CurrentCultureIgnoreCase;

        public static StringComparison Comparison { get; }
            = (IsCaseSensitive) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

        public static StringComparison CultureComparison { get; }
            = (IsCaseSensitive) ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

        private static bool GetIsCaseSensitive()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return false;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return true;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return true;

            Debug.Fail(RuntimeInformation.OSDescription);

            return true;
        }
    }
}
