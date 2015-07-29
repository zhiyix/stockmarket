using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace StockMarket.Utils
{
    public class CfgManager
    {
        // Get the ConnectionStrings section.        
        // This function uses the ConnectionStrings 
        // property to read the connectionStrings
        // configuration section.
        /// <summary>
        /// ObjectType of Operation : [RegEdit.Connection]
        /// </summary>
        public static void ReadConnectionStrings()
        {
            // Get the ConnectionStrings collection.
            ConnectionStringSettingsCollection connections =
                ConfigurationManager.ConnectionStrings;

            if (connections.Count != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Using ConnectionStrings property.");
                Console.WriteLine("Connection strings:");

                // Get the collection elements.
                foreach (ConnectionStringSettings connection in
                  connections)
                {
                    string name = connection.Name;
                    string provider = connection.ProviderName;
                    string connectionString = connection.ConnectionString;

                    Console.WriteLine("Name:               {0}",
                      name);
                    Console.WriteLine("Connection string:  {0}",
                      connectionString);
                    Console.WriteLine("Provider:            {0}",
                       provider);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No connection string is defined.");
                Console.WriteLine();
            }
        }

        // Access the machine configuration file using mapping.
        // The function uses the OpenMappedMachineConfiguration 
        // method to access the machine configuration. 
        /// <summary>
        /// ObjectType of Operation : 
        ///     C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config
        /// </summary>
        public static void MapMachineConfiguration()
        {
            // Get the machine.config file.
            Configuration machineConfig =
              ConfigurationManager.OpenMachineConfiguration();
            // Get the machine.config file path.
            ConfigurationFileMap configFile =
              new ConfigurationFileMap(machineConfig.FilePath);

            // Map the application configuration file to the machine 
            // configuration file.
            Configuration config =
              ConfigurationManager.OpenMappedMachineConfiguration(
                configFile);

            // Get the AppSettings section.
            AppSettingsSection appSettingSection =
              (AppSettingsSection)config.GetSection("appSettings");
            appSettingSection.SectionInformation.AllowExeDefinition =
                ConfigurationAllowExeDefinition.MachineToRoamingUser;

            // Display the configuration file sections.
            ConfigurationSectionCollection sections =
              config.Sections;

            Console.WriteLine();
            Console.WriteLine("Using OpenMappedMachineConfiguration.");
            Console.WriteLine("Sections in machine.config:");

            // Get the sections in the machine.config.
            foreach (ConfigurationSection section in sections)
            {
                string name = section.SectionInformation.Name;
                Console.WriteLine("Name: {0}", name);
            }
        }

        // Access a configuration file using mapping.
        // This function uses the OpenMappedExeConfiguration 
        // method to access a new configuration file.   
        // It also gets the custom ConsoleSection and 
        // sets its ConsoleEment BackgroundColor and
        // ForegroundColor properties to green and red
        // respectively. Then it uses these properties to
        // set the console colors.  
        /// <summary>
        /// ObjectType of Operation : ExecuteFile.Config
        /// </summary>
        public static void MapExeConfiguration()
        {
            // Get the application configuration file.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            Console.WriteLine(config.FilePath);

            if (config == null)
            {
                Console.WriteLine(
                  "The configuration file does not exist.");
                Console.WriteLine(
                 "Use OpenExeConfiguration to create the file.");
            }

            // Create a new configuration file by saving 
            // the application configuration to a new file.
            string appName =
              Environment.GetCommandLineArgs()[0];

            string configFile = string.Concat(appName,
              ".2.config");
            config.SaveAs(configFile, ConfigurationSaveMode.Full);

            // Map the new configuration file.
            ExeConfigurationFileMap configFileMap =
                new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            // Make changes to the new configuration file. 
            // This is to show that this file is the 
            // one that is used.
            string sectionName = "consoleSection";

            ConsoleSection customSection =
              (ConsoleSection)config.GetSection(sectionName);

            if (customSection == null)
            {
                customSection = new ConsoleSection();
                config.Sections.Add(sectionName, customSection);
            }
            else
                // Change the section configuration values.
                customSection =
                    (ConsoleSection)config.GetSection(sectionName);

            customSection.ConsoleElement.BackgroundColor =
                ConsoleColor.Green;
            customSection.ConsoleElement.ForegroundColor =
                ConsoleColor.Red;

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);

            // Set console properties using the 
            // configuration values contained in the 
            // new configuration file.
            Console.BackgroundColor =
              customSection.ConsoleElement.BackgroundColor;
            Console.ForegroundColor =
              customSection.ConsoleElement.ForegroundColor;
            try
            {
                Console.Clear();
            }
            catch { }

            Console.WriteLine();
            Console.WriteLine("Using OpenMappedExeConfiguration.");
            Console.WriteLine("Configuration file is: {0}",
              config.FilePath);
        }


        // Get the application configuration file.
        // This function uses the 
        // OpenExeConfiguration(string)method 
        // to get the application configuration file. 
        // It also creates a custom ConsoleSection and 
        // sets its ConsoleEment BackgroundColor and
        // ForegroundColor properties to black and white
        // respectively. Then it uses these properties to
        // set the console colors.  
        public static void GetAppConfiguration()
        {

            // Get the application path needed to obtain
            // the application configuration file.
#if DEBUG
            string applicationName =
                Environment.GetCommandLineArgs()[0];
#else
           string applicationName =
          Environment.GetCommandLineArgs()[0]+ ".exe";
#endif

            string exePath = System.IO.Path.Combine(
                Environment.CurrentDirectory, applicationName);

            // Get the configuration file. The file name has
            // this format appname.exe.config.
            System.Configuration.Configuration config =
              ConfigurationManager.OpenExeConfiguration(exePath);

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
                string sectionName = "consoleSection";
                ConsoleSection customSection = new ConsoleSection();

                if (config.Sections[sectionName] == null)
                {
                    // Create a custom section if it does 
                    // not exist yet.

                    // Store console settings.
                    customSection.ConsoleElement.BackgroundColor =
                        ConsoleColor.Black;
                    customSection.ConsoleElement.ForegroundColor =
                        ConsoleColor.White;

                    // Add configuration information to the
                    // configuration file.
                    config.Sections.Add(sectionName, customSection);
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section.
                    // This makes the new values available for reading.
                    ConfigurationManager.RefreshSection(sectionName);
                }
                // Set console properties using values
                // stored in the configuration file.
                customSection =
                    (ConsoleSection)config.GetSection(sectionName);
                Console.BackgroundColor =
                    customSection.ConsoleElement.BackgroundColor;
                Console.ForegroundColor =
                    customSection.ConsoleElement.ForegroundColor;
                // Apply the changes.
                Console.Clear();
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
        }

        // Get the roaming configuration file associated 
        // with the application.
        // This function uses the OpenExeConfiguration(
        // ConfigurationUserLevel userLevel) method to 
        // get the configuration file.
        // It also creates a custom ConsoleSection and 
        // sets its ConsoleEment BackgroundColor and
        // ForegroundColor properties to blue and yellow
        // respectively. Then it uses these properties to
        // set the console colors.  
        public static void GetRoamingConfiguration()
        {
            // Define the custom section to add to the
            // configuration file.
            string sectionName = "consoleSection";
            ConsoleSection currentSection = null;

            // Get the roaming configuration 
            // that applies to the current user.
            Configuration roamingConfig =
              ConfigurationManager.OpenExeConfiguration(
               ConfigurationUserLevel.PerUserRoaming);

            // Map the roaming configuration file. This
            // enables the application to access 
            // the configuration file using the
            // System.Configuration.Configuration class
            ExeConfigurationFileMap configFileMap =
              new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename =
              roamingConfig.FilePath;

            // Get the mapped configuration file.
            Configuration config =
              ConfigurationManager.OpenMappedExeConfiguration(
                configFileMap, ConfigurationUserLevel.None);

            try
            {
                currentSection =
                     (ConsoleSection)config.GetSection(
                       sectionName);

                // Synchronize the application configuration
                // if needed. The following two steps seem
                // to solve some out of synch issues 
                // between roaming and default
                // configuration.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of the changed section, 
                // if needed. This makes the new values available 
                // for reading.
                ConfigurationManager.RefreshSection(sectionName);

                if (currentSection == null)
                {
                    // Create a custom configuration section.
                    currentSection = new ConsoleSection();

                    // Define where in the configuration file 
                    // hierarchy the associated 
                    // configuration section can be declared.
                    // The following assignment assures that 
                    // the configuration information can be 
                    // defined in the user.config file in the 
                    // roaming user directory. 
                    currentSection.SectionInformation.AllowExeDefinition =
                      ConfigurationAllowExeDefinition.MachineToLocalUser;

                    // Allow the configuration section to be 
                    // overridden by lower-level configuration files.
                    // This means that lower-level files can contain
                    // the section (use the same name) and assign 
                    // different values to it as done by the
                    // function GetApplicationConfiguration() in this
                    // example.
                    currentSection.SectionInformation.AllowOverride =
                      true;

                    // Store console settings for roaming users.
                    currentSection.ConsoleElement.BackgroundColor =
                        ConsoleColor.Blue;
                    currentSection.ConsoleElement.ForegroundColor =
                        ConsoleColor.Yellow;

                    // Add configuration information to 
                    // the configuration file.
                    config.Sections.Add(sectionName, currentSection);
                    config.Save(ConfigurationSaveMode.Modified);
                    // Force a reload of the changed section. This 
                    // makes the new values available for reading.
                    ConfigurationManager.RefreshSection(
                      sectionName);
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine("[Exception error: {0}]",
                    e.ToString());
            }

            // Set console properties using values
            // stored in the configuration file.
            Console.BackgroundColor =
              currentSection.ConsoleElement.BackgroundColor;
            Console.ForegroundColor =
              currentSection.ConsoleElement.ForegroundColor;
            // Apply the changes.
            Console.Clear();

            // Display feedback.
            Console.WriteLine();
            Console.WriteLine(
              "Using OpenExeConfiguration(ConfigurationUserLevel).");
            Console.WriteLine(
                "Configuration file is: {0}", config.FilePath);
        }

    }
}
