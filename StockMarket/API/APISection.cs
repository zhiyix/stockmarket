using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

namespace com.show.api
{
    // Define a custom section that is used by the application
    // to create custom configuration sections at the specified 
    // level in the configuration hierarchy that is in the 
    // proper configuration file.
    // This enables the user that has the proper access 
    // rights, to make changes to the configuration files.
    public class APISection : ConfigurationSection
    {
        // Create a configuration section.
        public APISection()
        { }

        // Set or get the ConsoleElement. 
        [ConfigurationProperty("apiElement")]
        public APIConfigElement ApiElement
        {
            get
            {
                return (
                  (APIConfigElement)this["apiElement"]);
            }
            set
            {
                this["apiElement"] = value;
            }
        }
    }
}
