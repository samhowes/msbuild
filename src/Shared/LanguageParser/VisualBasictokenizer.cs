// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Collections;

namespace Microsoft.Build.Shared.LanguageParser
{
    /*
     * Class:   VisualBasicTokenizer
     *
     * Given vb sources, return an enumerator that will provide tokens one at a time.
     *
     */
    sealed public class VisualBasicTokenizer : IEnumerable
    {
        /*
            These are the tokens that are specific to the VB tokenizer.
            Tokens that should be shared with other tokenizers should go
            into Token.cs.
        */
        public class LineTerminatorToken : Token { }
        public class SeparatorToken : Token { }

        public class LineContinuationToken : WhitespaceToken { }

        public class OctalIntegerLiteralToken : IntegerLiteralToken { }

        public class ExpectedValidOctalDigitToken : SyntaxErrorToken { }

        // The source lines
        private Stream _binaryStream = null;

        // Whether or not to force ANSI reading.
        private bool _forceANSI;

        /*
         * Method:  VisualBasicTokenizer
         * 
         * Construct
         */
        public VisualBasicTokenizer(Stream binaryStream, bool forceANSI)
        {
            _binaryStream = binaryStream;
            _forceANSI = forceANSI;
        }

        /*
         * Method:  GetEnumerator
         * 
         * Return a new token enumerator.
         */
        public IEnumerator GetEnumerator()
        {
            return new VisualBasicTokenEnumerator(_binaryStream, _forceANSI);
        }
    }
}
