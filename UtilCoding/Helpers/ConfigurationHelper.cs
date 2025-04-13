using System;
using System.Configuration;

namespace UtilCoding
{
    public class ConfigurationHelper
    {
        private static ConfigurationHelper _instance = null;
        private static object syncRoot = new Object();

        private ConfigurationHelper()
        { }

        public static ConfigurationHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigurationHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        public string Read(string Key) 
        {
            string sValue = string.Empty;
            try
            {

                if (ConfigurationManager.AppSettings[Key] == null) {
                    return string.Empty;
                }

                sValue = ConfigurationManager.AppSettings[Key].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sValue;
        }


        public void Save(string Key, string Value) 
        {
            Configuration config;
            try
            {
                if (ConfigurationManager.AppSettings[Key] == null)
                {
                    config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings.Add(Key, Value);
                    config.Save(ConfigurationSaveMode.Modified);
                    return;
                }

                if (ConfigurationManager.AppSettings[Key].ToString() == string.Empty) {
                    return;
                }

                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[Key].Value = Value;
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex) 
            {
                throw ex;   
            }
        }


    }
}
