using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;


namespace Microsoft.Build.Shared.AssemblyFoldersFromConfig
{
    [DataContract(Name = "AssemblyFoldersConfig", Namespace = "")]
    public class AssemblyFolderCollection
    {
        [DataMember]
        public List<AssemblyFolderItem> AssemblyFolders { get; set; }

        /// <summary>
        /// Deserialize the file into an AssemblyFolderCollection.
        /// </summary>
        /// <param name="filePath">Path to the AssemblyFolder.config file.</param>
        /// <returns>New deserialized collection instance.</returns>
        public static AssemblyFolderCollection Load(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(AssemblyFolderCollection));
                return (AssemblyFolderCollection)serializer.ReadObject(reader, true);
            }
        }
    }
}
