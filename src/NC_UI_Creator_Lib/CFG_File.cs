using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NC_UI_Creator_Lib.CFG;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// Describe the CFG file (info about commands, classic menu, toolbars)
    /// </summary>
    public class CFG_File
    {
        public const string CFG_DefaultFileName = "NC_UI_DEF.cfg";
        public static string[] CFG_Image_Formats = { ".bmp", "*.ico"};
        public List<Ribbon> Ribbons { get; private set; }
        public Configman Configman { get; private set; }

        public UniversalElementCollection Menus { get; private set; }

        public UniversalElementCollection Toolbars { get; private set; }

        public ToolbarsPos ToolbarsPosInfo { get; private set; }

        internal CFG_File()
        {
            Ribbons = new List<Ribbon>();
            Configman = new Configman();

            Menus = new UniversalElementCollection(ElementVariant.Menu);

            Toolbars = new UniversalElementCollection(ElementVariant.Toolbars);

            ToolbarsPosInfo = new ToolbarsPos();
        }

        public void Save(string cfgDefaultFileName = CFG_DefaultFileName, string cfgSaveDirectoryPath = "")
        {
            string CFG_Data = "";
            foreach (Ribbon ribbon in Ribbons)
            {
                CFG_Data += ribbon.Content;
            }
            CFG_Data += Environment.NewLine;

            CFG_Data += Configman.Content;
            if (Menus.IsAny()) CFG_Data += Menus.Content;
            if (Toolbars.IsAny()) CFG_Data += Toolbars.Content;
            if (ToolbarsPosInfo.IsAny()) CFG_Data += ToolbarsPosInfo.Content;
            CFG_Data += Environment.NewLine;
            try
            {
                File.WriteAllText(Path.Combine(cfgSaveDirectoryPath, cfgDefaultFileName), CFG_Data, Encoding.UTF8);
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}
