// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Build.Evaluation
{
    public static class CharacterUtilities
    {
        static public bool IsNumberStart(char candidate)
        {
            return candidate == '+' || candidate == '-' || candidate == '.' || char.IsDigit(candidate);
        }

        static public bool IsSimpleStringStart(char candidate)
        {
            return candidate == '_' || char.IsLetter(candidate);
        }

        static public bool IsSimpleStringChar(char candidate)
        {
            return IsSimpleStringStart(candidate) || char.IsDigit(candidate);
        }

        static public bool IsHexAlphabetic(char candidate)
        {
            return candidate == 'a' || candidate == 'b' || candidate == 'c' || candidate == 'd' || candidate == 'e' || candidate == 'f' ||
                candidate == 'A' || candidate == 'B' || candidate == 'C' || candidate == 'D' || candidate == 'E' || candidate == 'F';
        }

        static public bool IsHexDigit(char candidate)
        {
            return char.IsDigit(candidate) || IsHexAlphabetic(candidate);
        }
    }
}
