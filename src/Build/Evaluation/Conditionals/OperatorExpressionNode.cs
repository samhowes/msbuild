// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Build.Shared;

namespace Microsoft.Build.Evaluation
{
    /// <summary>
    /// Base class for nodes that are operators (have children in the parse tree)
    /// </summary>
    public abstract class OperatorExpressionNode : GenericExpressionNode
    {
        /// <summary>
        /// Numeric evaluation is never allowed for operators
        /// </summary>
        public override double NumericEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            // Should be unreachable: all calls check CanNumericEvaluate() first
            ErrorUtilities.VerifyThrow(false, "Cannot numeric evaluate an operator");
            return 0.0D;
        }

        /// <summary>
        /// Version evaluation is never allowed for operators
        /// </summary>
        public override Version VersionEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            ErrorUtilities.VerifyThrow(false, "Cannot version evaluate an operator");
            return null;
        }

        /// <summary>
        /// Whether boolean evaluation is allowed: always allowed for operators
        /// </summary>
        public override bool CanBoolEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            return true;
        }

        /// <summary>
        /// Whether the node can be evaluated as a numeric: by default,
        /// this is not allowed
        /// </summary>
        public override bool CanNumericEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            return false;
        }

        /// <summary>
        /// Whether the node can be evaluated as a version: by default,
        /// this is not allowed
        /// </summary>
        public override bool CanVersionEvaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            return false;
        }

        /// <summary>
        /// Value after any item and property expressions are expanded
        /// </summary>
        /// <returns></returns>
        public override string GetExpandedValue(ConditionEvaluator.IConditionEvaluationState state)
        {
            return null;
        }

        /// <summary>
        /// Value before any item and property expressions are expanded
        /// </summary>
        /// <returns></returns>
        public override string GetUnexpandedValue(ConditionEvaluator.IConditionEvaluationState state)
        {
            return null;
        }

        /// <summary>
        /// If any expression nodes cache any state for the duration of evaluation, 
        /// now's the time to clean it up
        /// </summary>
        public override void ResetState()
        {
            LeftChild?.ResetState();

            RightChild?.ResetState();
        }

        /// <summary>
        /// Storage for the left child
        /// </summary>
        public GenericExpressionNode LeftChild { set; get; }

        /// <summary>
        /// Storage for the right child
        /// </summary>
        public GenericExpressionNode RightChild { set; get; }

        #region REMOVE_COMPAT_WARNING
        public override bool DetectAnd()
        {
            // Read the state of the current node
            bool detectedAnd = this.PossibleAndCollision;
            // Reset the flags on the current node
            this.PossibleAndCollision = false;
            // Process the children of the node if preset
            bool detectAndRChild = false;
            bool detectAndLChild = false;
            if (RightChild != null)
            {
                detectAndRChild = RightChild.DetectAnd();
            }
            if (LeftChild != null)
            {
                detectAndLChild = LeftChild.DetectAnd();
            }
            return detectedAnd || detectAndRChild || detectAndLChild;
        }

        public override bool DetectOr()
        {
            // Read the state of the current node
            bool detectedOr = this.PossibleOrCollision;
            // Reset the flags on the current node
            this.PossibleOrCollision = false;
            // Process the children of the node if preset
            bool detectOrRChild = false;
            bool detectOrLChild = false;
            if (RightChild != null)
            {
                detectOrRChild = RightChild.DetectOr();
            }
            if (LeftChild != null)
            {
                detectOrLChild = LeftChild.DetectOr();
            }
            return detectedOr || detectOrRChild || detectOrLChild;
        }
        #endregion
    }
}
