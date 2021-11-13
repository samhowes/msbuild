// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.Build.Shared;

namespace Microsoft.Build.Evaluation
{
    /// <summary>
    /// Base class for all expression nodes.
    /// </summary>
    public abstract class GenericExpressionNode
    {
        public abstract bool CanBoolEvaluate(ConditionEvaluator.IConditionEvaluationState state);
        public abstract bool CanNumericEvaluate(ConditionEvaluator.IConditionEvaluationState state);
        public abstract bool CanVersionEvaluate(ConditionEvaluator.IConditionEvaluationState state);
        public abstract bool BoolEvaluate(ConditionEvaluator.IConditionEvaluationState state);
        public abstract double NumericEvaluate(ConditionEvaluator.IConditionEvaluationState state);
        public abstract Version VersionEvaluate(ConditionEvaluator.IConditionEvaluationState state);

        /// <summary>
        /// Returns true if this node evaluates to an empty string,
        /// otherwise false.
        /// (It may be cheaper to determine whether an expression will evaluate
        /// to empty than to fully evaluate it.)
        /// Implementations should cache the result so that calls after the first are free.
        /// </summary>
        public virtual bool EvaluatesToEmpty(ConditionEvaluator.IConditionEvaluationState state)
        {
            return false;
        }

        /// <summary>
        /// Value after any item and property expressions are expanded
        /// </summary>
        /// <returns></returns>
        public abstract string GetExpandedValue(ConditionEvaluator.IConditionEvaluationState state);

        /// <summary>
        /// Value before any item and property expressions are expanded
        /// </summary>
        /// <returns></returns>
        public abstract string GetUnexpandedValue(ConditionEvaluator.IConditionEvaluationState state);

        /// <summary>
        /// If any expression nodes cache any state for the duration of evaluation, 
        /// now's the time to clean it up
        /// </summary>
        public abstract void ResetState();

        /// <summary>
        /// The main evaluate entry point for expression trees
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Evaluate(ConditionEvaluator.IConditionEvaluationState state)
        {
            ProjectErrorUtilities.VerifyThrowInvalidProject(
                CanBoolEvaluate(state),
                state.ElementLocation,
                "ConditionNotBooleanDetail",
                state.Condition,
                GetExpandedValue(state));

            return BoolEvaluate(state);
        }

        /// <summary>
        /// Get display string for this node for use in the debugger.
        /// </summary>
        public virtual string DebuggerDisplay { get; }


        #region REMOVE_COMPAT_WARNING
        public virtual bool PossibleAndCollision
        {
            set { /* do nothing */ }
            get { return false; }
        }

        public virtual bool PossibleOrCollision
        {
            set { /* do nothing */ }
            get { return false; }
        }

        public bool PotentialAndOrConflict()
        {
            // The values of the functions are assigned to boolean locals
            // in order to force evaluation of the functions even when the 
            // first one returns false
            bool detectOr = DetectOr();
            bool detectAnd = DetectAnd();
            return detectOr && detectAnd;
        }

        public abstract bool DetectOr();
        public abstract bool DetectAnd();
        #endregion

    }
}
