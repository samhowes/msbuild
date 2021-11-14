// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Build.Evaluation
{
    /// <summary>
    /// This struct represents a reference to a piece of item metadata.  For example,
    /// %(EmbeddedResource.Culture) or %(Culture) in the project file.  In this case,
    /// "EmbeddedResource" is the item name, and "Culture" is the metadata name.
    /// The item name is optional.
    /// </summary>
    public struct MetadataReference
    {
        /// <summary>
        /// The item name
        /// </summary>
        public string ItemName;       // Could be null if the %(...) is not qualified with an item name.

        /// <summary>
        /// The metadata name
        /// </summary>
        public string MetadataName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itemName">Name of the item</param>
        /// <param name="metadataName">Name of the metadata</param>
        public MetadataReference
        (
            string itemName,
            string metadataName
        )
        {
            this.ItemName = itemName;
            this.MetadataName = metadataName;
        }
    }
}
