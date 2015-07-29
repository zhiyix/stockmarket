using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace StockMarket.Utils
{
    public class UserProperties
    {
        private bool debug = false;

        public Dictionary<string, string> appConfigs = new Dictionary<string, string>();
        private string configFileName = @"Configurations\";

        public UserProperties()
        {
        }

        public UserProperties(string fileName)
        {
            this.configFileName += fileName;
        }

        public bool load()
        {
            appConfigs.Clear();
            if (File.Exists(configFileName))
            {
                ExeConfigurationFileMap file =
                    new ExeConfigurationFileMap();
                file.ExeConfigFilename = configFileName;

                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
                    file, ConfigurationUserLevel.None);

                KeyValueConfigurationCollection cfgs =
                    config.AppSettings.Settings;
                foreach (KeyValueConfigurationElement kvce in cfgs)
                {
                    appConfigs.Add(kvce.Key, kvce.Value);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将此Properties表中的属性列表（键和元素对）写入输出字符
        /// </summary>
        /// <param name="writer">输出字符流</param>
        public void store()
        {
            if ((configFileName == null) || (configFileName.Length == 0))
                return;

            string sectionName = "appSettings";

            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            //configFileMap.ExeConfigFilename = tmpFile;
            configFileMap.ExeConfigFilename = configFileName;

            // Get the mapped configuration file
            System.Configuration.Configuration config =
               ConfigurationManager.OpenMappedExeConfiguration(configFileMap, 
               ConfigurationUserLevel.None);

            // Make changes to the new configuration file. 
            //appConfig = new Dictionary<string, string>();
            KeyValueConfigurationCollection cfgs = config.AppSettings.Settings;
            if (config.AppSettings.Settings.Count > 0)
            {
                config.AppSettings.Settings.Clear();
            }
            foreach (KeyValuePair<string, string> kvce in appConfigs)
            {
                config.AppSettings.Settings.Add(kvce.Key, kvce.Value);
            }

            // Create a new configuration file by saving 
            // the application configuration to a new file.
            //config.SaveAs(tmpFile, ConfigurationSaveMode.Full);  

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection =
              (AppSettingsSection)config.GetSection(sectionName);

            if (debug)
            {
                Console.WriteLine();
                Console.WriteLine("Using GetSection(string).");
                Console.WriteLine("AppSettings section:");
                Console.WriteLine(
                  appSettingSection.SectionInformation.GetRawXml());
            }
        }

        public void setProperty(string key, string value)
        {
            string gval;
            if (appConfigs.TryGetValue(key, out gval))
            {
                appConfigs[key] = value;
            }
            else
            {
                appConfigs.Add(key, value);
            }
        }

        public void clear()
        {
            if (appConfigs.Count > 0)
            {
                appConfigs.Clear();
            }
        }

        public bool loadAPIConfiguration(ref com.show.api.APISection customSection)
        {
            string configFile = System.IO.Path.Combine(
                Environment.CurrentDirectory, configFileName);
            
            if (!File.Exists(configFile))
            {
                return false;
            }

            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap =
                new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;

            // Get the configuration file. The file name has
            // this format appname.exe.config.
            // Get the mapped configuration file
            System.Configuration.Configuration config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);
            
            try
            {

                // Create a custom configuration section
                // having the same name that is used in the 
                // roaming configuration file.
                // This is because the configuration section 
                // can be overridden by lower-level 
                // configuration files. 
                // See the GetRoamingConfiguration() function in 
                // this example.
                string sectionName = "apiSection";
                
                if (config.Sections[sectionName] == null)
                {
                    return false;
                }
                // Set console properties using values
                // stored in the configuration file.
                customSection =
                    (com.show.api.APISection)config.GetSection(sectionName);
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[Error exception: {0}]",
                    e.ToString());
            }

            // Display feedback.
            Console.WriteLine();
            Console.WriteLine("Using OpenExeConfiguration(string).");
            // Display the current configuration file path.
            Console.WriteLine("Configuration file is: {0}",
              config.FilePath);

            return true;
        }

        public bool storeAPIConfiguration(com.show.api.APISection customSection)
        {
            string configFile = System.IO.Path.Combine(
                Environment.CurrentDirectory, configFileName);
            
            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap =
                new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;

            // Get the configuration file. The file name has
            // this format appname.exe.config.
            // Get the mapped configuration file
            System.Configuration.Configuration config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            try
            {
                // Create a custom configuration section
                // having the same name that is used in the 
                // roaming configuration file.
                // This is because the configuration section 
                // can be overridden by lower-level 
                // configuration files. 
                // See the GetRoamingConfiguration() function in 
                // this example.
                string sectionName = "apiSection";

                if (config.Sections[sectionName] == null)
                {
                    // Create a custom section if it does 
                    // not exist yet.

                    // Store console settings.

                    // Add configuration information to the
                    // configuration file.
                    config.Sections.Add(sectionName, customSection);

                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section.
                    // This makes the new values available for reading.
                    ConfigurationManager.RefreshSection(sectionName);

                    return true;
                }
                else
                {
                    // Set console properties using values
                    // stored in the configuration file.
                    com.show.api.APISection tmpSection =
                        (com.show.api.APISection)config.GetSection(sectionName);
                    if (tmpSection.ApiElement.AppID.Equals(customSection.ApiElement.AppID) &&
                        tmpSection.ApiElement.Secret.Equals(customSection.ApiElement.Secret))
                    {
                        return true;
                    }
                    else {
                        tmpSection.ApiElement.AppID = customSection.ApiElement.AppID;
                        tmpSection.ApiElement.Secret = customSection.ApiElement.Secret;

                        customSection.SectionInformation.ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);

                        return true;
                    }
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[Error exception: {0}]",
                    e.ToString());
            }

            // Display feedback.
            Console.WriteLine("[Error] storeAPIConfiguration");
            Console.WriteLine("Using OpenExeConfiguration(string).");
            // Display the current configuration file path.
            Console.WriteLine("Configuration file is: {0}",
              config.FilePath);

            return false;
        }
    }
}
