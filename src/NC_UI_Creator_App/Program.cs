using System;
using System.IO;
using NC_UI_Creator_Lib;

namespace NC_UI_Creator_App
{
    public class Program
    {
        private const string Exception_1 = "Конфиг-файл не задан!";
        private const string Exception_2 = "Конфиг-файл по указанному пути не найден, либо был указан неверный путь ";
        private const string Exception_3 = "Конфиг-файл не был корректно обработан";

        private static void OnExceptionWork(string exception)
        {
#if DEBUG
            Console.WriteLine(exception);
#else
            throw new Exception(exception);
#endif
        }

        [STAThread]
        public static void Main(string[] args)
        {
            string configPath = "";
//#if DEBUG
//            configPath = "test_2_config.xml";
//#else
//            if (args.Length == 0) OnExceptionWork(Exception_1);
//            configPath = args[0];
//#endif
            if (args.Length == 0) OnExceptionWork(Exception_1);
            configPath = args[0];

            if (!File.Exists(configPath)) OnExceptionWork(Exception_2 + configPath);

            UI_Creator_FromCSV_Config config = UI_Creator_FromCSV_Config.LoadFrom(configPath);
            if (config == null) OnExceptionWork(Exception_3);

            UI_Creator_FromCSV creator = new UI_Creator_FromCSV(config);

            var UI_Data = creator.Create();
            UI_Data.DataSavePath = Path.GetDirectoryName(configPath);

            UI_Data.SaveCUIX(config.DeleteTempFiles);
            UI_Data.SaveCFG();

            Console.WriteLine("\nEnd!");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
