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

            foreach (string dll_path in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly))
            {
                string dll_name = Path.GetFileNameWithoutExtension(dll_path);
                string dll_nameDLL = Path.GetFileName(dll_path);

                


                Assembly assembly = Assembly.LoadFrom(dll_path);
                Type[] types = new Type[] { };
                Exception ex_save = new Exception();
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                CuixDefinition temp_CuixDefinition = new CuixDefinition();
                List<FunctionAtCuiDefinition> temp_functions_CuiDefs = new List<FunctionAtCuiDefinition>();
                List<FunctionDefinition> temp_functions_Defs = new List<FunctionDefinition>();
                bool temp_copyFiles = false;

                foreach (Type type in types)
                {
                    //Check CuixDefinition
                    var Element_CuixDefinition_attrs = 
                        (CuixDefinition[])type.GetCustomAttributes(typeof(CuixDefinition), true);
                    var Element_FunctionAtCuiDefinition_attrs = 
                        (FunctionAtCuiDefinition[])type.GetCustomAttributes(typeof(FunctionAtCuiDefinition), true);
                    var Element_FunctionDefinition_attrs = 
                        (FunctionDefinition[])type.GetCustomAttributes(typeof(FunctionDefinition), true);


                    if (Element_CuixDefinition_attrs.Length > 0)
                    {
                        temp_CuixDefinition = Element_CuixDefinition_attrs[0];
                    }


                    if (Element_FunctionAtCuiDefinition_attrs.Length > 0)
                    {
                        temp_functions_CuiDefs.Add(Element_FunctionAtCuiDefinition_attrs[0]);
                    }


                    if (Element_FunctionDefinition_attrs.Length > 0)
                    {
                        temp_functions_Defs.Add(Element_FunctionDefinition_attrs[0]);
                    }
                }

                //Начинаем обработку данных (для корректного получения types
                if (types.Length > 0)
                {
                    if (temp_CuixDefinition.RibbonName == "")
                    {
                        temp_CuixDefinition.RibbonName = dll_name;
                        temp_copyFiles = false;
                    }
                    else temp_copyFiles = true;


                }
            }

            Console.WriteLine("End!");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
