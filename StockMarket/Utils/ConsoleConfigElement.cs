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
    //*** Auxiliary Classes ***//

    // Define a custom configuration element to be 
    // contained by the ConsoleSection. This element 
    // stores background and foreground colors that
    // the application applies to the console window.
    public class ConsoleConfigElement : ConfigurationElement
    {
        // Create the element.
        public ConsoleConfigElement()
        { }

        // Create the element.
        public ConsoleConfigElement(ConsoleColor fColor,
            ConsoleColor bColor)
        {
            ForegroundColor = fColor;
            BackgroundColor = bColor;
        }

        // Get or set the console background color.
        [ConfigurationProperty("background",
          DefaultValue = ConsoleColor.Black,
          IsRequired = false)]
        public ConsoleColor BackgroundColor
        {
            get
            {
                return (ConsoleColor)this["background"];
            }
            set
            {
                this["background"] = value;
            }
        }

        // Get or set the console foreground color.
        [ConfigurationProperty("foreground",
           DefaultValue = ConsoleColor.White,
           IsRequired = false)]
        public ConsoleColor ForegroundColor
        {
            get
            {
                return (ConsoleColor)this["foreground"];
            }
            set
            {
                this["foreground"] = value;
            }
        }
    }
}
