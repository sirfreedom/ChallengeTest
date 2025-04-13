using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UtilCoding
{
    public class XMLManager
    {
        private static XMLManager _instance = null;
        private static object syncRoot = new Object();
        private List<string> lNonDirectory = new List<string>() { "bin", "obj", "packages", ".", "node_modules", "$", "system", "tmp", "temp", "libraries", "build" };

        private XMLManager()
        { }

        public static XMLManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new XMLManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public class XmlComponent
        {

            public XmlComponent() { }

            public string TypeName { get; set; }

            public Dictionary<string, string> Atribs { get; set; } = new Dictionary<string, string>();

            public List<XmlComponent> Components { get; set; } = new List<XmlComponent>();
        }


        public Hashtable GetData(string filepath) 
        {
            Hashtable oHashTable = new Hashtable();
            XmlTextReader reader = new XmlTextReader(filepath);
            String atributo, nombre;
            atributo = String.Empty;
            nombre = String.Empty;
            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        nombre = reader.Name;
                    }
                    else
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                        {
                            atributo = reader.Value.Replace("\r\n", String.Empty).Trim();
                        }
                    }
                    if (atributo != String.Empty && nombre != String.Empty)
                    {
                        oHashTable.Add(nombre, atributo);
                        atributo = String.Empty;
                        nombre = String.Empty;
                    }
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return oHashTable;
        }

        public Dictionary<string, string> AttributesToDictionary(XmlAttributeCollection ListAtributes)
        {
            Dictionary<string, string> atribs = new Dictionary<string, string>();
            foreach (XmlAttribute a in ListAtributes)
            {
                atribs.Add(a.Name, a.Value);
            }
            return atribs;
        }


        public void ReplaceForAll(string path,string FileName,string Extension, List<ReplaceTextDirectory> lreplaceTextDirectory)
        {
            StringBuilder sbFindFile = new StringBuilder();
            string sCurrentPath = string.Empty;
            string[] RootDirectories;
            string[] Directories;
            List<string> lDirectory;
            List<string> lRootDirectory;
            string[] lFiles;
            string[] lLines;
            int Processes = 0;
            try
            {
                RootDirectories = Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly);

                lRootDirectory = RootDirectories.ToList();
                lRootDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));

                sbFindFile.Append(FileName == "" ? "*" : FileName);
                sbFindFile.Append(".");
                sbFindFile.Append(Extension);

                foreach (string sRootDirectory in lRootDirectory)
                {
                    Directories = Directory.GetDirectories(sRootDirectory, "*.*", SearchOption.AllDirectories);
                    lDirectory = Directories.ToList();
                    lDirectory.RemoveAll(x => lNonDirectory.Any(DeleteWord => x.ToLower().Contains(DeleteWord)));
                    lDirectory.Add(sRootDirectory);

                    foreach (string sDirectory in lDirectory)
                    {
                        lFiles = Directory.GetFiles(sDirectory, sbFindFile.ToString());

                        if (FileName != string.Empty && (lFiles.Length == 0 || lFiles.Length > 1))
                        {
                            continue;
                        }

                        foreach (ReplaceTextDirectory r in lreplaceTextDirectory)
                        {

                            //its trying if exist the file.
                            lFiles = Directory.GetFiles(sDirectory, (r.FileName == "" ? "*." : r.FileName) + "." + r.Extension);

                            if (r.FileName != string.Empty && (lFiles.Length == 0 || lFiles.Length > 1))
                            {
                                continue;
                            }

                            for (int i = 0; i < lFiles.Length; i++)
                            {
                                //read all the lines in ... file.
                                lLines = File.ReadAllLines(lFiles[i], Encoding.UTF8);

                                //its Exists, 
                                if (lLines.Where(x => x.Trim().Contains(r.OriginWord.Trim())).ToList().Count() == 1)
                                {
                                    //i get index of the code line.
                                    int Index = lLines.Select((linea, indice) => new { Linea = linea, Indice = indice })
                                    .Where(x => x.Linea.Trim().Contains(r.OriginWord.Trim()))
                                    .Select(x => x.Indice)
                                    .FirstOrDefault();

                                    //i replace old code to new code.
                                    lLines[Index] = lLines[Index].Replace(r.OriginWord.Trim(), r.ReplaceWord.Trim());
                                    File.WriteAllLines(lFiles[i], lLines);
                                    Processes++;
                                }
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("No es posible acceder a una o algunas carpetas seleccionadas, verifique los permisos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene de forma recursiva los subnodos 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="PersistComponent"></param>
        /// <returns></returns>
        public XmlComponent getChildNode(XmlNode node, XmlComponent PersistComponent)
        {
            XmlComponent oComponent = new XmlComponent();
            try
            {
                oComponent.TypeName = node.Name;
                oComponent.Atribs = AttributesToDictionary(node.Attributes);

                if (PersistComponent.Atribs.Count == 0)
                {
                    PersistComponent = oComponent;
                }
                if (PersistComponent.Atribs.Count > 0)
                {
                    PersistComponent.Components.Add(oComponent);
                }

                foreach (XmlNode subnodo in node.ChildNodes)
                {
                    getChildNode(subnodo, oComponent);
                }

            }
            catch (XmlException ex)
            {
                throw new Exception("existen problemas en la lectura del archivo o del nodo, verifique sus datos." + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PersistComponent;
        }


        public class ReplaceTextDirectory
        {
            public string FileName { get; set; }
            public string Extension { get; set; }
            public string OriginWord { get; set; }
            public string ReplaceWord { get; set; }
        }

        /// <summary>
        /// Limpia los espacios fuera de las etiquetas html, para que puedan encriptarse y guardarse de forma correcta.
        /// </summary>
        /// <param name="htmlValue"></param>
        /// <returns></returns>
        public string CleanSpacesHtml(string htmlValue)
        {
            string result;
            const string regex = "(?<=>)\\s+(?=<)";
            result = Regex.Replace(htmlValue, regex, "");
            return result;
        }

    }
}
