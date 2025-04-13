using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace UtilCoding
{
    public class BackupChanges
    {
        private static BackupChanges _instance = null;
        private static object syncRoot = new Object();
        private const string ENCRYPTION_KEY = "C987654Z";
        private readonly static byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

        private BackupChanges()
        { }

        public static BackupChanges Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new BackupChanges();
                        }
                    }
                }
                return _instance;
            }
        }


        #region Class

        public class ComboType
        {
            public ComboType()
            {
            }
            public ComboType(int id, string description)
            {
                Id = id;
                Description = description;
            }

            public int Id { get; set; }
            public string Description { get; set; }
        }

        public class BackUpEntity 
        { 
            public string Id { get; set; }
            public int k { get; set; }
            public string d { get; set; }
            public string v { get; set; }
        }

        #endregion 


        public void WriteInsertXml(string Key, string text, string Descripcion = "", bool IsEncript = false)
        {
            StringBuilder sbPath = new StringBuilder();
            string sApp = AppDomain.CurrentDomain.BaseDirectory.ToString();
            DataSet ds = new DataSet("ds");
            DataTable dt1 = new DataTable("dt1");

            DataColumn dcId = new DataColumn("id", typeof(string));
            DataColumn dcKey = new DataColumn("k", typeof(string));
            DataColumn dcDescript1 = new DataColumn("d", typeof(string));
            DataColumn dcVencimiento = new DataColumn("v", typeof(string));
            string sFile = "dsBackup.xml";
            DataRow dr;
            try
            {
                sbPath.Append(sApp);
                sbPath.Append(sFile);

                if (File.Exists(sbPath.ToString()))
                {
                    ds.ReadXml(sbPath.ToString());
                    dt1 = ds.Tables["dt1"];
                }
                else
                {
                    dt1.Columns.Add(dcId);
                    dt1.Columns.Add(dcKey);
                    dt1.Columns.Add(dcDescript1);
                    dt1.Columns.Add(dcVencimiento);
                    ds.Tables.Add(dt1);
                }

                dr = dt1.NewRow();
                dr["id"] = DateTime.Now.Ticks.ToString();
                dr["k"] = Key;
                dr["d"] = (IsEncript == true) ? Encrypt(text) : text;
                dr["v"] = Descripcion;
                ds.Tables["dt1"].Rows.Add(dr);
                ds.WriteXml(sbPath.ToString());
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Poda()
        {
            string sFile = "dsBackup.xml";
            DataSet ds = new DataSet();
            StringBuilder sbPath = new StringBuilder();
            string sApp = AppDomain.CurrentDomain.BaseDirectory.ToString();
            sbPath.Append(sApp);
            sbPath.Append(sFile);

            if (!File.Exists(sbPath.ToString()))
            {
                return;
            }

            ds.ReadXml(sbPath.ToString());
            //ds.Tables["dt1"]
            ds.WriteXml(sbPath.ToString());
        }


        public string DatarowToString(DataRow dr, string Campo, string ValorDefault = "")
        {
            string s = ValorDefault;
            try
            {
                if (dr[Campo] != null)
                {
                    if (dr[Campo].ToString().Length != 0)
                    {
                        s = dr[Campo].ToString();

                        if (s.Length == 0)
                        {
                            s = ValorDefault;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return s;
        }


        public string NullToString(object value)
        {
            string s = string.Empty;

            if (value != null)
            {
                s = value.ToString();
            }
            return s;
        }


        public List<BackUpEntity> Read(string Key, bool IsEncript = false)
        {
            string sFile = "dsBackup.xml";
            string DatatableName = "dt1";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            StringBuilder sbPath = new StringBuilder();
            string sApp = AppDomain.CurrentDomain.BaseDirectory.ToString();
            sbPath.Append(sApp);
            sbPath.Append(sFile);
            StringBuilder sbFilter = new StringBuilder();
            List<BackUpEntity> lBackUp = new List<BackUpEntity>();
            BackUpEntity oBackupEntity;
            sbFilter.Append("k = ");
            sbFilter.Append(Key);

            if (File.Exists(sbPath.ToString()))
            {
                ds.ReadXml(sbPath.ToString());
                dt = DataTableToDataTableFiltrado(ds.Tables[DatatableName], sbFilter.ToString());

                foreach (DataRow dr in dt.Rows) 
                {
                    oBackupEntity = new BackUpEntity();
                    oBackupEntity.Id = dr["id"].ToString();
                    oBackupEntity.k = int.Parse(dr["k"].ToString());
                    oBackupEntity.d = (IsEncript == true) ? Decrypt(dr["d"].ToString()) : dr["d"].ToString(); 
                    oBackupEntity.v = dr["v"].ToString();
                    lBackUp.Add(oBackupEntity);
                }
                oBackupEntity = new BackUpEntity();
                oBackupEntity.Id = DateTime.Now.Ticks.ToString();
                oBackupEntity.k = 0;
                oBackupEntity.d = "";
                oBackupEntity.v = "";
                lBackUp.Add(oBackupEntity);
            }
            return lBackUp;
        }


        public bool ConfigurationExist()
        {
            string sFile = "dsBackup.xml";
            StringBuilder sbPath = new StringBuilder();
            string sApp = AppDomain.CurrentDomain.BaseDirectory.ToString();
            sbPath.Append(sApp);
            sbPath.Append(sFile);
            bool b = false;
            StringBuilder sbFilter = new StringBuilder();
            try
            {
                b = (File.Exists(sbPath.ToString()));
            }
            catch (Exception)
            {
                throw;
            }
            return b;
        }


        private DataTable DataTableToDataTableFiltrado(DataTable dt, string Condicion)
        {
            DataTable dtReturn = new DataTable();
            try
            {
                if (dt == null)
                {
                    return dtReturn;
                }

                if (dt.Rows.Count > 0 && dt.Select(Condicion).Length > 0)
                {
                    dtReturn = dt.Select(Condicion).CopyToDataTable();
                }
                else
                {
                    dtReturn = dt.Copy();
                    dtReturn.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtReturn;
        }



        private string Encrypt(string inputText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);
            string sReturn = string.Empty;

            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        sReturn = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }

            return sReturn;
        }

        private string Decrypt(string inputText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(inputText);
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);
            string s = string.Empty;
            try
            {

                if (inputText.Length == 0)
                {
                    return string.Empty;
                }

                using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainText = new byte[encryptedData.Length];
                            int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                            s = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                s = inputText;
            }
            catch (Exception)
            {
                throw;
            }
            return s;
        }





    }
}
