using System.Diagnostics;
using System.Runtime.Serialization;

namespace Microsoft.Build.Shared.AssemblyFoldersFromConfig
{
    [DataContract(Name="AssemblyFolder", Namespace = "")]
    [DebuggerDisplay("{Name}: FrameworkVersion = {FrameworkVersion}, Platform = {Platform}, Path= {Path}")]
    public class AssemblyFolderItem
    {
        [DataMember(IsRequired = false, Order = 1)]
        public string Name { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string FrameworkVersion { get; set; }

        [DataMember(IsRequired = true, Order = 3)]
        public string Path { get; set; }

        [DataMember(IsRequired = false, Order = 4)]
        public string Platform { get; set; }
    }
}