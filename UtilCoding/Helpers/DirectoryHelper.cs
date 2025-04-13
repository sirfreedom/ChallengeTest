using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilCoding.Helpers
{
    public class DirectoryHelper
    {
        private static DirectoryHelper _instance = null;
        private static object syncRoot = new Object();
        private List<string> lNonDirectory = new List<string>() { "bin", "obj", "packages", ".", "node_modules", "$", "system", "tmp", "temp", "libraries", "build" };
        private List<string> lNonFiles = new List<string>() { "AssemblyInfo.cs", "Global.asax", "package-lock.json", "package.json", "Web.csproj", "Web.Debug", "Web.Release", "packages.config", "Web.config", "FolderProfile.pubxml", "README.md", ".gitignore" };

        private DirectoryHelper()
        { }

        public static DirectoryHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new DirectoryHelper();
                        }
                    }
                }
                return _instance;
            }
        }


        public Task<List<ObjectFile>> FindFiles(SearchFile search)
        {
            List<ObjectFile> lObjectFile = new List<ObjectFile>();
            string sCurrentPath = string.Empty;
            string[] RootDirectories;
            string[] Directories;
            List<string> lDirectory;
            List<string> lRootDirectory;
            string[] lFiles;
            StringBuilder sbFindFile = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            try
            {
                try
                {
                    RootDirectories = Directory.GetDirectories(search.Path, "*.*", SearchOption.TopDirectoryOnly);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new DirectoryHelperException("File path not found");
                }

                lRootDirectory = RootDirectories.ToList();
                lRootDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));
                sbFindFile.Append(search.FileName);

                lRootDirectory.Add(search.Path);

                foreach (string sRootDirectory in lRootDirectory)
                {
                    Directories = Directory.GetDirectories(sRootDirectory, "*.*", SearchOption.AllDirectories);
                    lDirectory = Directories.ToList();
                    lDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));
                    lDirectory.Add(sRootDirectory);

                    foreach (string sDirectory in lDirectory)
                    {
                        lFiles = Directory.GetFiles(sDirectory, sbFindFile.ToString());

                        if (lFiles.Length == 0)
                        {
                            continue;
                        }

                        foreach (string sFile in lFiles)
                        {
                            FileInfo f = new FileInfo(sFile);
                            ObjectFile objectFile = new ObjectFile();
                            objectFile.LinkArchivo = f.FullName;
                            objectFile.NombreArchivo = f.Name;
                            objectFile.ExtensionArchivo = f.Extension;
                            objectFile.AtributosArchivo = f.Attributes.ToString();
                            objectFile.FechaArchivo = f.CreationTime.ToString();
                            objectFile.TamanoArchivo = f.Length.ToString();
                            lObjectFile.Add(objectFile);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(lObjectFile);
        }


        public Task<List<ObjectFile>> FindTextWithoutAnotherText(SearchText Searchtext)
        {
            List<ObjectFile> lObjectFile = new List<ObjectFile>();
            string sCurrentPath = string.Empty;
            string[] RootDirectories;
            string[] Directories;
            List<string> lDirectory;
            List<string> lRootDirectory;
            string[] lFiles;
            string[] lLines;
            List<string> lFileFilter;
            int ExistResult = 0;
            int NoExistResult = 0;
            StringBuilder sbFindFile = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            try
            {
                try
                {
                    RootDirectories = Directory.GetDirectories(Searchtext.Path, "*.*", SearchOption.TopDirectoryOnly);
                }
                catch (UnauthorizedAccessException) 
                {
                    throw new DirectoryHelperException("File path not found");
                }

                lRootDirectory = RootDirectories.ToList();
                lRootDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));

                sbFindFile.Append(Searchtext.FileName == "" ? "*" : Searchtext.FileName);
                sbFindFile.Append(".");
                sbFindFile.Append(Searchtext.Extension);

                lRootDirectory.Add(Searchtext.Path);

                foreach (string sRootDirectory in lRootDirectory)
                {
                    Directories = Directory.GetDirectories(sRootDirectory, "*.*", SearchOption.AllDirectories);
                    lDirectory = Directories.ToList();
                    lDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));
                    lDirectory.Add(sRootDirectory);

                    foreach (string sDirectory in lDirectory)
                    {
                        lFiles = Directory.GetFiles(sDirectory, sbFindFile.ToString());
                        lFileFilter = lFiles.ToList();
                        lFileFilter.RemoveAll(x => lNonFiles.Any(NonFile => x.ToLower().Contains(NonFile.ToLower())));

                        if (Searchtext.FileName != string.Empty && (lFileFilter.Count == 0 || lFileFilter.Count > 1))
                        {
                            continue;
                        }

                        for (int i = 0; i < lFileFilter.Count; i++)
                        {
                            lLines = File.ReadAllLines(lFileFilter[i], Encoding.UTF8);

                            ExistResult = lLines.Select((linea, indice) => new { Linea = linea, Indice = indice })
                            .Where(x => x.Linea.Contains(Searchtext.IncludeText))
                            .Select(x => x.Indice)
                            .Count();

                            if (Searchtext.ExcludeText.Length > 0)
                            {
                                NoExistResult = lLines.Select((linea, indice) => new { Linea = linea, Indice = indice })
                                .Where(x => x.Linea.Contains(Searchtext.ExcludeText))
                                .Select(x => x.Indice)
                                .Count();
                            }

                            if (
                                (ExistResult > 0 && NoExistResult == 0 && Searchtext.ExcludeText.Length == 0) ||
                                (ExistResult > 0 && NoExistResult == 0 && Searchtext.ExcludeText.Length > 0)
                               )
                            {
                                FileInfo f = new FileInfo(lFileFilter[i]);
                                ObjectFile oObjectFile = new ObjectFile();
                                oObjectFile.LinkArchivo = f.FullName;
                                oObjectFile.NombreArchivo = f.Name;
                                oObjectFile.ExtensionArchivo = f.Extension;
                                oObjectFile.AtributosArchivo = f.Attributes.ToString();
                                oObjectFile.FechaArchivo = f.CreationTime.ToString();
                                oObjectFile.TamanoArchivo = f.Length.ToString();
                                lObjectFile.Add(oObjectFile);
                                ExistResult = 0;
                            }
                        }

                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Task.FromResult(lObjectFile);
        }


        public DataTable ListToDatatable(List<string> lValue) 
        {
            DataTable dt = new DataTable();
            DataColumn dcId = new DataColumn("Id", typeof(string));
            DataColumn dcNombre = new DataColumn("Descripcion", typeof(string));
            DataRow dr;
            try
            {
                dt.Columns.Add(dcId);
                dt.Columns.Add(dcNombre);
                foreach (string s in lValue) 
                {
                    dr = dt.NewRow();
                    dr["Id"] = s;
                    dr["Descripcion"] = s;
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return dt;
        }


        public class SearchText
        {
            public string Path { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
            public string IncludeText { get; set; }
            public string ExcludeText { get; set; }
        }

        public class ObjectFile 
        {
            public string NombreArchivo { get; set; }
            public string LinkArchivo { get; set; }
            public string ExtensionArchivo { get; set; }
            public string AtributosArchivo { get; set; }
            public string FechaArchivo { get; set; }
            public string TamanoArchivo { get; set; }
        }

        public class SearchFile 
        {
            public string Path { get; set; }
            public string FileName { get; set; }
        }

        public class DirectoryHelperException : Exception
        {
            public string _Message;
            
            public DirectoryHelperException() { }
            public override string Message => _Message;
            
            public DirectoryHelperException(string Validacion)
            {
                _Message = Validacion;
            }
        }

    }
}
