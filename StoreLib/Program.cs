using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace StoreLib
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
                .File("Logs\\BL_Log.txt")
                .CreateLogger();
        }
    }
}
