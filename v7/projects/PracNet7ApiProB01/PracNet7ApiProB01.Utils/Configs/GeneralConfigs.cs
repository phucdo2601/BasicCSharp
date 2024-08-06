using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Utils.Configs
{
    public class GeneralConfigs
    {
        public static string LogCurrentMethodName([CallerMemberName] string methodName = "")
        {
            Console.WriteLine($"Current method name: {methodName}");
            return methodName;
        }
    }
}
