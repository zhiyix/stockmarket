using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StockMarket.Utils
{
    public class FileManager
    {
        public static string getApplicationInstallationPath()
        {
            String applicationWorkingPath = "";
            if (applicationWorkingPath.Length == 0)
            {
                // String path = System.GetEnv("DEBUGDIR");
                String path = "";
                System.Collections.IDictionary dict = System.Environment.GetEnvironmentVariables();
                if (dict.Contains("DEBUGDIR"))
                {
                    // path = System.getProperty("DEBUGDIR");
                    foreach (KeyValuePair<Object, Object> kvp in dict)
                    {
                        if (kvp.Key.Equals("DEBUGDIR"))
                        {
                            path = kvp.Value.ToString();
                        }
                    }
                }
                if (path.Length > 0)
                {
                    return path;
                }
                //Uri uri = JIOConfigurator.getProtectionDomain().getCodeSource().getLocation();
                AppDomain root = AppDomain.CurrentDomain;
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Application base of {0}:\r\n {1}",
                    root.FriendlyName, root.SetupInformation.ApplicationBase);
                Uri uri = new Uri(root.SetupInformation.ApplicationBase);
                try
                {
                    // File file = new File(path);
                    FileInfo file = new FileInfo(uri.LocalPath);
                    if (uri.IsFile && File.Exists(uri.LocalPath))
                    {
                        // path = file.getPath();
                        path = file.DirectoryName;
                    }
                    else if (Directory.Exists(uri.LocalPath))
                    {
                        // path = file.getParentFile().getPath();
                        path = uri.LocalPath;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(uri.LocalPath + " URI could not be loaded (Network path,...) ?: " + ex.Message);
                    //path = System.getProperty("user.dir").replace("\\", "\\");
                    path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                }
                finally
                {
                    path.Replace('\\', '/');
                    //path += "\\";
                    Console.WriteLine("Using Application install path:\r\n " + path);
                }
                return path;
            }
            return applicationWorkingPath;
        }
    }
}
