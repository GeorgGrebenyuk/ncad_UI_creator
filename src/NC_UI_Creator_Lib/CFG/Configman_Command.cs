using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Describe the single command in configman's block of CFG
    /// </summary>
    public class Configman_Command : CFG_Base
    {
        public int weight { get; set; } = 10;
        public CommandContextVariant cmdType { get; set; } = CommandContextVariant.Document;

        /// <summary>
        /// The command for the button
        /// </summary>
        public string intername { get; set; }

        /// <summary>
        /// The display name of button
        /// </summary>
        public string DispName { get; set; }
        public string LocalName { get; set; } = "";

        /// <summary>
        /// The extended test (after mouse hover)
        /// </summary>
        public string StatusText { get; set; } = "";

        /// <summary>
        /// The information about icon's storage (local or in dll) and icon's name
        /// </summary>
        public string BitmapDll { get; private set; }

        public Configman_Command(string CommandName)
        {
            this.intername = CommandName;
            CFG_SetBlockName(@"\configman\commands\" + CommandName);
        }

        /// <summary>
        /// Set info about icon
        /// </summary>
        /// <param name="iconResVariant">The resources type: local file (.ICO or .BMP) or resource-dll with icons (.ICO or .BMP)</param>
        /// <param name="iconVariant">The file type of image (.ICO or .BMP)</param>
        /// <param name="icon_name">Filename without extension</param>
        /// <param name="dll_or_localPath">Relative path to images or Resource-dll's name with extension</param>
        public void SetIcon(IconResourceVariant iconResVariant, IconVariant iconVariant, string icon_name, string dll_or_localPath = "")
        {
            if (iconResVariant == IconResourceVariant.LocalFile)
            {
                string ext = "." + iconVariant.ToString().ToLower();
                if (dll_or_localPath != "") BitmapDll = dll_or_localPath + "\\" + icon_name + ext;
            }
            else if (iconResVariant == IconResourceVariant.ResDll)
            {
                BitmapDll = dll_or_localPath + " |";
                if (iconVariant == IconVariant.ICO) BitmapDll += "Icon=s" + icon_name;
                else BitmapDll += "BitmapId=s" + icon_name;
            }
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("weight", weight);
                CFG_AddInfo("cmdtype", cmdType);
                CFG_AddInfo("intername", intername);
                CFG_AddInfo("DispName", DispName);
                CFG_AddInfo("LocalName", LocalName);
                CFG_AddInfo("StatusText", StatusText);
                CFG_AddInfo("BitmapDll", BitmapDll);

                return p_Content;
            }
        }
    }
}
