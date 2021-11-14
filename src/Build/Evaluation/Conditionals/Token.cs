// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ErrorUtilities = Microsoft.Build.Shared.ErrorUtilities;

namespace Microsoft.Build.Evaluation
{
    /// <summary>
    /// This class represents a token in the Complex Conditionals grammar.  It's
    /// really just a bag that contains the type of the token and the string that
    /// was parsed into the token.  This isn't very useful for operators, but
    /// is useful for strings and such.
    /// </summary>
    public sealed class Token
    {
        public readonly static Token Comma = new Token(TokenType.Comma);
        public readonly static Token LeftParenthesis = new Token(TokenType.LeftParenthesis);
        public readonly static Token RightParenthesis = new Token(TokenType.RightParenthesis);
        public readonly static Token LessThan = new Token(TokenType.LessThan);
        public readonly static Token GreaterThan = new Token(TokenType.GreaterThan);
        public readonly static Token LessThanOrEqualTo = new Token(TokenType.LessThanOrEqualTo);
        public readonly static Token GreaterThanOrEqualTo = new Token(TokenType.GreaterThanOrEqualTo);
        public readonly static Token And = new Token(TokenType.And);
        public readonly static Token Or = new Token(TokenType.Or);
        public readonly static Token EqualTo = new Token(TokenType.EqualTo);
        public readonly static Token NotEqualTo = new Token(TokenType.NotEqualTo);
        public readonly static Token Not = new Token(TokenType.Not);
        public readonly static Token EndOfInput = new Token(TokenType.EndOfInput);

        /// <summary>
        /// Valid tokens
        /// </summary>
        public enum TokenType
        {
            Comma, LeftParenthesis, RightParenthesis,
            LessThan, GreaterThan, LessThanOrEqualTo, GreaterThanOrEqualTo,
            And, Or,
            EqualTo, NotEqualTo, Not,
            Property, String, Numeric, ItemList, ItemMetadata, Function,
            EndOfInput
        };

        private TokenType _tokenType;
        private string _tokenString;

        /// <summary>
        /// Constructor for types that don't have values
        /// </summary>
        /// <param name="tokenType"></param>
        private Token(TokenType tokenType)
        {
            _tokenType = tokenType;
            _tokenString = null;
        }

        /// <summary>
        /// Constructor takes the token type and the string that
        /// represents the token
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tokenString"></param>
        public Token(TokenType type, string tokenString)
            : this(type, tokenString, false /* not expandable */)
        { }

        /// <summary>
        /// Constructor takes the token type and the string that
        /// represents the token.
        /// If the string may contain content that needs expansion, expandable is set.
        /// </summary>
        public Token(TokenType type, string tokenString, bool expandable)
        {
            ErrorUtilities.VerifyThrow
                (
                type == TokenType.Property ||
                type == TokenType.String ||
                type == TokenType.Numeric ||
                type == TokenType.ItemList ||
                type == TokenType.ItemMetadata ||
                type == TokenType.Function,
                "Unexpected token type"
                );

            ErrorUtilities.VerifyThrowInternalNull(tokenString, nameof(tokenString));

            _tokenType = type;
            _tokenString = tokenString;
            this.Expandable = expandable;
        }

        /// <summary>
        /// Whether the content potentially has expandable content,
        /// such as a property expression or escaped character.
        /// </summary>
        public bool Expandable
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsToken(TokenType type)
        {
            return _tokenType == type;
        }

        public string String
        {
            get
            {
                if (_tokenString != null)
                {
                    return _tokenString;
                }

                // Return a token string for 
                // an error message.
                switch (_tokenType)
                {
                    case TokenType.Comma:
                        return ",";
                    case TokenType.LeftParenthesis:
                        return "(";
                    case TokenType.RightParenthesis:
                        return ")";
                    case TokenType.LessThan:
                        return "<";
                    case TokenType.GreaterThan:
                        return ">";
                    case TokenType.LessThanOrEqualTo:
                        return "<=";
                    case TokenType.GreaterThanOrEqualTo:
                        return ">=";
                    case TokenType.And:
                        return "and";
                    case TokenType.Or:
                        return "or";
                    case TokenType.EqualTo:
                        return "==";
                    case TokenType.NotEqualTo:
                        return "!=";
                    case TokenType.Not:
                        return "!";
                    case TokenType.EndOfInput:
                        return null;
                    default:
                        ErrorUtilities.ThrowInternalErrorUnreachable();
                        return null;
                }
            }
        }
    }
}