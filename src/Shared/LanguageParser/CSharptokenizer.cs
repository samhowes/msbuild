// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using System.Collections;

namespace Microsoft.Build.Shared.LanguageParser
{
    /*
     * Class:   CSharpTokenizer
     *
     * Given C# sources, return an enumerator that will provide tokens one at a time.
     *
     */
    sealed public class CSharpTokenizer : IEnumerable
    {
        /*
            These are the tokens that are specific to the C# tokenizer.
            Tokens that should be shared with other tokenizers should go
            into Token.cs.
        */
        public class CharLiteralToken : Token { } // i.e. A char value.
        public class NullLiteralToken : Token { } // i.e. A literal Null.

        public class UnrecognizedStringEscapeToken : SyntaxErrorToken { } // An unrecognized string escape character was used.
        public class EndOfFileInsideStringToken : SyntaxErrorToken { } // The file ended inside a string.
        public class NewlineInsideStringToken : SyntaxErrorToken { } // The string has a newline embedded.
        public class EndOfFileInsideCommentToken : SyntaxErrorToken { } // The file ended inside a multi-line comment.

        public class OpenScopeToken : OperatorOrPunctuatorToken { } // i.e. "{"
        public class CloseScopeToken : OperatorOrPunctuatorToken { } // i.e. "}"

        // The source lines
        private Stream _binaryStream = null;

        // Whether to force ANSI or not.
        private bool _forceANSI = false;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="binaryStream"></param>
        /// <param name="forceANSI"></param>
        public CSharpTokenizer(Stream binaryStream, bool forceANSI)
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
            return new CSharpTokenEnumerator(_binaryStream, _forceANSI);
        }
    }
}
