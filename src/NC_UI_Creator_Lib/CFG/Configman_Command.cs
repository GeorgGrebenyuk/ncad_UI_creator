using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    public class Configman_Command : CFG_Base
    {
        public int weight { get; set; } = 10;
        public CommandContextVariant cmdType { get; set; } = CommandContextVariant.Document;
        public string intername { get; set; }
        public string DispName { get; set; }
        public string LocalName { get; set; } = "";
        public string StatusText { get; set; } = "";
        public string BitmapDll { get; private set; }

        public Configman_Command(string CommandName)
        {
            this.intername = CommandName;
            CFG_SetBlockName(@"\configman\commands\" + CommandName);
        }

        /// <summary>
        /// Задает информацию об иконке команды
        /// </summary>
        /// <param name="iconResVariant">Тип ресурса: локальная картинка (BMP или ICO) или ресурсная DLL с этими же форматами</param>
        /// <param name="iconVariant">Тип картинки (BMP или ICO)</param>
        /// <param name="icon_name">Имя файла БЕЗ расширения</param>
        /// <param name="dll_or_localPath">Относительный путь к картинке или имя dll с расширением</param>
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
