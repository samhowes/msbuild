// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;

namespace Microsoft.Build.Evaluation
{
    /// <summary>
    /// Performs logical NOT on left child
    /// Does not update conditioned properties table
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class NotExpressionNode : OperatorExpressionNode
    {
        /// <summary>
        /// Evaluate as boolean
        /// </summary>
        public override bool BoolEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            return !LeftChild.BoolEvaluate(state);
        }

        public override bool CanBoolEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            return LeftChild.CanBoolEvaluate(state);
        }

        /// <summary>
        /// Returns unexpanded value with '!' prepended. Useful for error messages.
        /// </summary>
        public override string GetUnexpandedValue(ConditionEvaluator.IConditionEvaluationState state)
        {
            return "!" + LeftChild.GetUnexpandedValue(state);
        }

        /// <summary>
        /// Returns expanded value with '!' prepended. Useful for error messages.
        /// </summary>
        public override string GetExpandedValue(ConditionEvaluator.IConditionEvaluationState state)
        {
            return "!" + LeftChild.GetExpandedValue(state);
        }

        public override string DebuggerDisplay => $"(not {LeftChild.DebuggerDisplay})";
    }
}
