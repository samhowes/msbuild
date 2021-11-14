// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Microsoft.Build.Shared
{
    /// <summary>
    /// Contains the names of the known elements in the XML project file.
    /// </summary>
    public static class XMakeElements
    {
        public const string project = "Project";
        public const string visualStudioProject = "VisualStudioProject";
        public const string target = "Target";
        public const string propertyGroup = "PropertyGroup";
        public const string output = "Output";
        public const string itemGroup = "ItemGroup";
        public const string itemDefinitionGroup = "ItemDefinitionGroup";
        public const string usingTask = "UsingTask";
        public const string projectExtensions = "ProjectExtensions";
        public const string onError = "OnError";
        public const string error = "Error";
        public const string warning = "Warning";
        public const string message = "Message";
        public const string import = "Import";
        public const string importGroup = "ImportGroup";
        public const string choose = "Choose";
        public const string when = "When";
        public const string otherwise = "Otherwise";
        public const string usingTaskParameterGroup = "ParameterGroup";
        public const string usingTaskParameter = "Parameter";
        public const string usingTaskBody = "Task";
        public const string sdk = "Sdk";

        public static readonly char[] InvalidTargetNameCharacters = { '$', '@', '(', ')', '%', '*', '?', '.' };

        // Names that cannot be used as property or item names because they are reserved
        public static readonly HashSet<string> ReservedItemNames = new HashSet<string>
        {
            // XMakeElements.project, "Project" is not reserved, because unfortunately ProjectReference items already use it as metadata name.
            XMakeElements.visualStudioProject,
            XMakeElements.target,
            XMakeElements.propertyGroup,
            XMakeElements.output,
            XMakeElements.itemGroup,
            XMakeElements.usingTask,
            XMakeElements.projectExtensions,
            XMakeElements.onError,
            // XMakeElements.import "Import" items are used by Visual Basic projects
            XMakeElements.importGroup,
            XMakeElements.choose,
            XMakeElements.when,
            XMakeElements.otherwise
        };
    }
}
