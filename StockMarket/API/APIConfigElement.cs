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
    //*** Auxiliary Classes ***//

    // Define a custom configuration element to be 
    // contained by the ConsoleSection. This element 
    // stores background and foreground colors that
    // the application applies to the console window.
    public class APIConfigElement : ConfigurationElement
    {
        // Create the element.
        public APIConfigElement()
        { }

        // Create the element.
        public APIConfigElement(String appid,
            String secret)
        {
            AppID = appid;
            Secret = secret;
        }

        // Get or set the console background color.
        [ConfigurationProperty("secret",
          DefaultValue = "0123456789abcdefghijklmnopqrstuv",
          IsRequired = true)]
        public String Secret
        {
            get
            {
                return (String)this["secret"];
            }
            set
            {
                this["secret"] = value;
            }
        }

        // Get or set the console foreground color.
        [ConfigurationProperty("appid",
           DefaultValue = "",
           IsRequired = true)]
        public String AppID
        {
            get
            {
                return (String)this["appid"];
            }
            set
            {
                this["appid"] = value;
            }
        }
    }
}
