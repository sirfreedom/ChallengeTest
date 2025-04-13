using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MediaDevices;

namespace WhatappCopy
{
    public class WhatAppCopy
    {
        private static WhatAppCopy _instance = null;
        private static object syncRoot = new Object();

        private WhatAppCopy() { }

        public static WhatAppCopy Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new WhatAppCopy();
                        }
                    }
                }
                return _instance;
            }
        }



        public void Copy(string PathStorage, string PathLocal, string TypeCopy, List<string> CellExclude) 
        {
            IEnumerable<MediaDevice> ldevice = MediaDevice.GetDevices();
            MediaDirectoryInfo mRootDirectory;
            string[] lDirectory = { };
            StringBuilder sbDirectory = new StringBuilder();

            foreach (MediaDevice m in ldevice)
            {
                m.Connect();

                var resultado = from a in m.Model.Trim().Split(' ').ToList()
                                   join b in CellExclude on a equals b
                                   select new { a, b };

                if (resultado.Count() > 0) 
                {
                    continue;
                }

                sbDirectory.Append(PathStorage);
                mRootDirectory = m.GetRootDirectory();

                try
                {
                    lDirectory = m.GetDirectories(sbDirectory.ToString());
                }
                catch (DirectoryNotFoundException)
                {
                    continue;
                }

                foreach (string sDirectory in lDirectory)
                {
                    string[] lFile;
                    lFile = m.GetFiles(sDirectory, TypeCopy);

                    foreach (string sFile in lFile)
                    {
                        string sFileName = string.Empty;
                        StringBuilder sbFileName = new StringBuilder();
                        MediaFileInfo oMediaFileInfo = m.GetFileInfo(sFile);
                        sFileName = oMediaFileInfo.Name;

                        using (Stream sTempFile = oMediaFileInfo.OpenRead())
                        {
                            sbFileName.Append(PathLocal);
                            sbFileName.Append(sFileName);
                            using (var fileStream = new FileStream(sbFileName.ToString(), FileMode.Create, FileAccess.Write))
                            {
                                sTempFile.CopyTo(fileStream);
                            }
                        }
                    }

                }
                m.Disconnect();
            }
        }



    }
}
