using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class ConfigurationSettings
    {
        private static string _mode;



        //public static void SetAppSetting(string key, string value)
        //{

        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    config.AppSettings.Settings.Remove(key);
        //    config.AppSettings.Settings.Add(key,value);
        //    config.AppSettings.Settings[key].Value = value;
        //    config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}


        public static string GetMode()
        {
            if (string.IsNullOrEmpty(_mode))
            {
                _mode = ConfigurationManager.AppSettings["Mode"];
            }

            return _mode;
        }
    }
}



    

