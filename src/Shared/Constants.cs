// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;

namespace Microsoft.Build.Shared
{
    /// <summary>
    /// Constants that we want to be shareable across all our assemblies.
    /// </summary>
    public static class MSBuildConstants
    {
        /// <summary>
        /// The name of the property that indicates the tools path
        /// </summary>
        public const string ToolsPath = "MSBuildToolsPath";

        /// <summary>
        /// Name of the property that indicates the X64 tools path
        /// </summary>
        public const string ToolsPath64 = "MSBuildToolsPath64";

        /// <summary>
        /// Name of the property that indicates the root of the SDKs folder
        /// </summary>
        public const string SdksPath = "MSBuildSDKsPath";

        /// <summary>
        /// Name of the property that indicates that all warnings should be treated as errors.
        /// </summary>
        public const string TreatWarningsAsErrors = "MSBuildTreatWarningsAsErrors";

        /// <summary>
        /// Name of the property that indicates a list of warnings to treat as errors.
        /// </summary>
        public const string WarningsAsErrors = "MSBuildWarningsAsErrors";

        /// <summary>
        /// Name of the property that indicates the list of warnings to treat as messages.
        /// </summary>
        public const string WarningsAsMessages = "MSBuildWarningsAsMessages";

        /// <summary>
        /// The name of the environment variable that users can specify to override where NuGet assemblies are loaded from in the NuGetSdkResolver.
        /// </summary>
        public const string NuGetAssemblyPathEnvironmentVariableName = "MSBUILD_NUGET_PATH";

        /// <summary>
        /// The name of the target to run when a user specifies the /restore command-line argument.
        /// </summary>
        public const string RestoreTargetName = "Restore";
        /// <summary>
        /// The most current Visual Studio Version known to this version of MSBuild.
        /// </summary>
        public const string CurrentVisualStudioVersion = "16.0";

        /// <summary>
        /// The most current ToolsVersion known to this version of MSBuild.
        /// </summary>
        public const string CurrentToolsVersion = "Current";

        // if you change the key also change the following clones
        // Microsoft.Build.OpportunisticIntern.BucketedPrioritizedStringList.TryIntern
        public const string MSBuildDummyGlobalPropertyHeader = "MSBuildProjectInstance";

        /// <summary>
        /// The most current VSGeneralAssemblyVersion known to this version of MSBuild.
        /// </summary>
        public const string CurrentAssemblyVersion = "15.1.0.0";

        /// <summary>
        /// Current version of this MSBuild Engine assembly in the form, e.g, "12.0"
        /// </summary>
        public const string CurrentProductVersion = "16.0";
        
        /// <summary>
        /// Symbol used in ProjectReferenceTarget items to represent default targets
        /// </summary>
        public const string DefaultTargetsMarker = ".default";

        /// <summary>
        /// Symbol used in ProjectReferenceTarget items to represent targets specified on the ProjectReference item
        /// with fallback to default targets if the ProjectReference item has no targets specified.
        /// </summary>
        public const string ProjectReferenceTargetsOrDefaultTargetsMarker = ".projectReferenceTargetsOrDefaultTargets";
        
        // One-time allocations to avoid implicit allocations for Split(), Trim().
        public static readonly char[] SemicolonChar = { ';' };
        public static readonly char[] SpaceChar = { ' ' };
        public static readonly char[] SingleQuoteChar = { '\'' };
        public static readonly char[] EqualsChar = { '=' };
        public static readonly char[] ColonChar = { ':' };
        public static readonly char[] BackslashChar = { '\\' };
        public static readonly char[] NewlineChar = { '\n' };
        public static readonly char[] CrLf = { '\r', '\n' };
        public static readonly char[] ForwardSlash = { '/' };
        public static readonly char[] ForwardSlashBackslash = { '/', '\\' };
        public static readonly char[] WildcardChars = { '*', '?' };
        public static readonly string[] CharactersForExpansion = { "*", "?", "$(", "@(", "%" };
        public static readonly char[] CommaChar = { ',' };
        public static readonly char[] HyphenChar = { '-' };
        public static readonly char[] DirectorySeparatorChar = { Path.DirectorySeparatorChar };
        public static readonly char[] DotChar = { '.' };
        public static readonly string[] EnvironmentNewLine = { Environment.NewLine };
        public static readonly char[] PipeChar = { '|' };
        public static readonly char[] PathSeparatorChar = { Path.PathSeparator };
    }

    public static class PropertyNames
    {
        /// <summary>
        /// Specifies whether the current evaluation / build is happening during a graph build
        /// </summary>
        public const string IsGraphBuild = nameof(IsGraphBuild);

        public const string InnerBuildProperty = nameof(InnerBuildProperty);
        public const string InnerBuildPropertyValues = nameof(InnerBuildPropertyValues);
    }

    // TODO: Remove these when VS gets updated to setup project cache plugins.
    public static class DesignTimeProperties
    {
        public const string DesignTimeBuild = nameof(DesignTimeBuild);
        public const string BuildingProject = nameof(BuildingProject);
    }

    public static class ItemTypeNames
    {
        /// <summary>
        /// References to other msbuild projects
        /// </summary>
        public const string ProjectReference = nameof(ProjectReference);

        /// <summary>
        /// Statically specifies what targets a project calls on its references
        /// </summary>
        public const string ProjectReferenceTargets = nameof(ProjectReferenceTargets);

        public const string GraphIsolationExemptReference = nameof(GraphIsolationExemptReference);

        /// <summary>
        /// Declares a project cache plugin and its configuration.
        /// </summary>
        public const string ProjectCachePlugin = nameof(ProjectCachePlugin);
    }

    /// <summary>
    /// Constants naming well-known item metadata.
    /// </summary>
    public static class ItemMetadataNames
    {
        public const string fusionName = "FusionName";
        public const string hintPath = "HintPath";
        public const string assemblyFolderKey = "AssemblyFolderKey";
        public const string alias = "Alias";
        public const string aliases = "Aliases";
        public const string parentFile = "ParentFile";
        public const string privateMetadata = "Private";
        public const string copyLocal = "CopyLocal";
        public const string isRedistRoot = "IsRedistRoot";
        public const string redist = "Redist";
        public const string resolvedFrom = "ResolvedFrom";
        public const string destinationSubDirectory = "DestinationSubDirectory";
        public const string destinationSubPath = "DestinationSubPath";
        public const string specificVersion = "SpecificVersion";
        public const string link = "Link";
        public const string subType = "SubType";
        public const string executableExtension = "ExecutableExtension";
        public const string embedInteropTypes = "EmbedInteropTypes";
        public const string targetPath = "TargetPath";
        public const string dependentUpon = "DependentUpon";
        public const string msbuildSourceProjectFile = "MSBuildSourceProjectFile";
        public const string msbuildSourceTargetName = "MSBuildSourceTargetName";
        public const string isPrimary = "IsPrimary";
        public const string targetFramework = "RequiredTargetFramework";
        public const string frameworkDirectory = "FrameworkDirectory";
        public const string version = "Version";
        public const string imageRuntime = "ImageRuntime";
        public const string winMDFile = "WinMDFile";
        public const string winMDFileType = "WinMDFileType";
        public const string msbuildReferenceSourceTarget = "ReferenceSourceTarget";
        public const string msbuildReferenceGrouping = "ReferenceGrouping";
        public const string msbuildReferenceGroupingDisplayName = "ReferenceGroupingDisplayName";
        public const string msbuildReferenceFromSDK = "ReferenceFromSDK";
        public const string winmdImplmentationFile = "Implementation";
        public const string projectReferenceOriginalItemSpec = "ProjectReferenceOriginalItemSpec";
        public const string IgnoreVersionForFrameworkReference = "IgnoreVersionForFrameworkReference";
        public const string frameworkFile = "FrameworkFile";
        public const string ProjectReferenceTargetsMetadataName = "Targets";
        public const string PropertiesMetadataName = "Properties";
        public const string UndefinePropertiesMetadataName = "UndefineProperties";
        public const string AdditionalPropertiesMetadataName = "AdditionalProperties";
        public const string ProjectConfigurationDescription = "ProjectConfigurationDescription";
    }
}
