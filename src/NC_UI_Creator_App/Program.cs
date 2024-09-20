using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

using NC_UI_Creator_Lib.Attributes;

namespace NC_UI_Creator_App
{
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string app_directory = AppDomain.CurrentDomain.BaseDirectory;

            //TODO: сделать обработку TSV как есть в TBS MenuFileGen и оговорить спецификацию файла

            Console.WriteLine("End!");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
