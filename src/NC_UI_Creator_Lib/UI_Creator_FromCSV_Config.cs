using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC_UI_Creator_Lib.CUI;
using NC_UI_Creator_Lib.CFG;
using System.Xml.Serialization;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// Вспомогательный класс с информацией по генерации UI_Creator_FromCSV
    /// </summary>
    public class UI_Creator_FromCSV_Config
    {
        public enum CreationMode
        {
            WithClassicMenu,
            WithToolbars
        }

        public CreationMode[] Modes { get; set; } = new CreationMode[] { };

        /// <summary>
        /// The name of folder with icons OR the name with extension of Resource-dll. By default = "Isons"
        /// </summary>
        public string IconsRefPath_or_DLL { get; set; } = "Icons";
        public IconResourceVariant IconResVariant { get; set; } = IconResourceVariant.LocalFile;
        public IconVariant IconFormatVariant { get; set; } = IconVariant.BMP;

        /// <summary>
        /// The ribbon's name. By default = the name of CSV without extension
        /// </summary>
        public string RibbonName { get; set; }

        public string CSV_FilePath { get; set; }

        public char CSV_Separator { get; set; } = '\t';

        public bool CSV_SkipHeader { get; set; } = false;

        public bool DeleteCUIXFiles { get; set; } = false;

        public bool DeleteConfigFiles { get; set; } = false;

        public UI_Creator_FromCSV_Config() { }

        public static UI_Creator_FromCSV_Config LoadFrom(string configXml_Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UI_Creator_FromCSV_Config));
            UI_Creator_FromCSV_Config config = null;

            using (FileStream fs = new FileStream(configXml_Path, FileMode.Open))
            {
                config = xmlSerializer.Deserialize(fs) as UI_Creator_FromCSV_Config;
            }

            return config;
        }

        public void WriteXML(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UI_Creator_FromCSV_Config));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, this);
            }
        }
    }
}
