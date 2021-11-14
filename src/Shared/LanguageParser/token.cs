// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Build.Shared.LanguageParser
{
    /*
     * Class:   Token
     *
     * Base class for all token classes.
     *
     */
    public abstract class Token
    {
        // The text from the originating source file that caused this token.
        private string _innerText = null;
        // The line number that the token fell on.
        private int _line = 0;

        /*
         * Method:  InnerText
         * 
         * Get or set the InnerText for this token
         */
        public string InnerText
        {
            get { return _innerText; }
            set { _innerText = value; }
        }

        /*
         * Method:  Line
         * 
         * Get or set the Line for this token
         */
        public int Line
        {
            get
            {
                return _line;
            }
            set
            {
                _line = value;
            }
        }

        /*
         * Method:  EqualsIgnoreCase
         * 
         * Return true if the given string equals the content of this token
         */
        public bool EqualsIgnoreCase(string compareTo)
        {
            return String.Equals(_innerText, compareTo, StringComparison.OrdinalIgnoreCase);
        }
    }

    /*
        Table of tokens shared by the parsers.
        Tokens that are specific to a particular parser are nested within the given
        parser class.
    */
    public class WhitespaceToken : Token { }
    public abstract class LiteralToken : Token { }
    public class BooleanLiteralToken : Token { } // i.e. true or false
    public abstract class IntegerLiteralToken : Token { } // i.e. a literal integer
    public class HexIntegerLiteralToken : IntegerLiteralToken { } // i.e. a hex literal integer
    public class DecimalIntegerLiteralToken : IntegerLiteralToken { } // i.e. a hex literal integer
    public class StringLiteralToken : Token { } // i.e. A string value.
    public abstract class SyntaxErrorToken : Token { } // A syntax error.
    public class ExpectedIdentifierToken : SyntaxErrorToken { }
    public class ExpectedValidHexDigitToken : SyntaxErrorToken { } // Got a non-hex digit when we expected to have one.
    public class EndOfFileInsideStringToken : SyntaxErrorToken { } // The file ended inside a string.
    public class UnrecognizedToken : SyntaxErrorToken { } // An unrecognized token was spotted.
    public class CommentToken : Token { }
    public class IdentifierToken : Token { } // An identifier
    public class KeywordToken : Token { } // An keyword
    public class PreprocessorToken : Token { } // #if, #region, etc.
    public class OpenConditionalDirectiveToken : PreprocessorToken { }
    public class CloseConditionalDirectiveToken : PreprocessorToken { }
    public class OperatorOrPunctuatorToken : Token { } // One of the predefined operators or punctuators
    public class OperatorToken : OperatorOrPunctuatorToken { }
}
