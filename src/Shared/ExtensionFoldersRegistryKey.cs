// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Build.Shared
{
    /// <summary>
    /// Contains information about entries in the AssemblyFoldersEx registry keys.
    /// </summary>
    public class ExtensionFoldersRegistryKey
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ExtensionFoldersRegistryKey(string registryKey, Version targetFrameworkVersion)
        {
            ErrorUtilities.VerifyThrowArgumentNull(registryKey, nameof(registryKey));
            ErrorUtilities.VerifyThrowArgumentNull(targetFrameworkVersion, nameof(targetFrameworkVersion));

            RegistryKey = registryKey;
            TargetFrameworkVersion = targetFrameworkVersion;
        }

        /// <summary>
        /// The registry key to the component
        /// </summary>
        public string RegistryKey { get; }

        /// <summary>
        /// Target framework version for the registry key
        /// </summary>
        public Version TargetFrameworkVersion { get; }
    }
}
