using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace eCommerce.SharedLibrary.Logs
{
    public static class LogException
    {
        public static void LogExceptions(Exception ex)
        {
            LogToFile(ex.Message);
            LogToConsole(ex.Message);
            LogToDebug(ex.Message);
        }

        private static void LogToDebug(string ex)
        {
            Log.Debug(ex);

        }

        private static void LogToConsole(string ex)
        {
            Log.Warning(ex);

        }

        private static void LogToFile(string ex)
        {
            Log.Information(ex);
        }
    }
}
