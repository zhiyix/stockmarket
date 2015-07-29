using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

namespace StockMarket.Utils
{
    // Define a custom section that is used by the application
    // to create custom configuration sections at the specified 
    // level in the configuration hierarchy that is in the 
    // proper configuration file.
    // This enables the user that has the proper access 
    // rights, to make changes to the configuration files.
    public class ConsoleSection : ConfigurationSection
    {
        // Create a configuration section.
        public ConsoleSection()
        { }

        // Set or get the ConsoleElement. 
        [ConfigurationProperty("consoleElement")]
        public ConsoleConfigElement ConsoleElement
        {
            get
            {
                return (
                  (ConsoleConfigElement)this["consoleElement"]);
            }
            set
            {
                this["consoleElement"] = value;
            }
        }
    }
}
