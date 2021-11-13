// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Immutable;

namespace Microsoft.Build.Evaluation
{
    public partial class LazyItemEvaluator<P, I, M, D>
    {
        public interface IItemOperation
        {
            void Apply(ImmutableList<ItemData>.Builder listBuilder, ImmutableHashSet<string> globsToIgnore);
        }
    }
}