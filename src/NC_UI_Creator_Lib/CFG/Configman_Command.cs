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
        public string BitmapDll { get; set; }

        public Configman_Command(string CommandName)
        {
            this.intername = CommandName;
            CFG_SetBlockName(@"\configman\commands\" + CommandName);
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
