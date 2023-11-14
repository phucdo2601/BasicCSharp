using System;
using System.IO;

namespace LearnBasicDelegateb01
{
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            //LogDel logDel = new LogDel(LogTextToScreen);
            //LogDel logDel = new LogDel(LogTextToFile);

            Log log = new Log();

            LogDel LogTextToScreenDel, LogTextToFileDel;

            LogTextToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;

            Console.WriteLine("Please input your name: ");
            var inputVar = Console.ReadLine();
            //multiLogDel(inputVar);

            LogText(LogTextToScreenDel, inputVar);


            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
