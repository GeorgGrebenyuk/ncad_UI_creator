using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.Attributes
{
    /// <summary>
    /// Определение функции для CFG-файла
    /// </summary>
    public class FunctionDefinition : Attribute
    {
        //=intername
        public string FunctionName { get; set; }

        //=DispName
        public string DisplayName { get; set; }

        public string LocalName { get; set; }

        //=StatusText
        public string Description { get; set; }

        //=BitmapDll
        public string IconRelativePath { get; set; }

        public FunctionDefinition() { }

        public FunctionDefinition(string functionName, string displayName, string localName, string description, string iconRelativePath)
        {
            FunctionName = functionName;
            DisplayName = displayName;
            LocalName = localName;
            Description = description;
            IconRelativePath = iconRelativePath;
        }

        public FunctionDefinition(string functionName, string displayName, string description, string iconRelativePath)
        {
            FunctionName = functionName;
            DisplayName = displayName;
            LocalName = displayName;
            Description = description;
            IconRelativePath = iconRelativePath;
        }


    }
}
