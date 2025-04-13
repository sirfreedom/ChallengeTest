using System.Collections.Generic;


namespace ConsoleChallenge
{
    public class DirectoryEntity
    {
        public DirectoryEntity() { }

        //public DirectoryEntity(string DirectoryRef, List<string> folder, List<FileEntity> files ) 
        //{
        //    DirectoryReferencia = DirectoryRef;
        //    Folder = folder;
        //    Files = files;
        //}

        public string DirectoryReferencia { get; set; }

        public string DirectoryName { get; set; }

        public List<FileEntity> Files { get; set; } = new List<FileEntity>();


    }
}
