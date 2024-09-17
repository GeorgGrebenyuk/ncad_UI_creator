using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    public class Configman_Command : CFG_Base
    {
        public string weight { get; set; } = "i10";
        public string cmdtype { get; set; } = "i1";
        public string intername { get; set; }
        public string DispName { get; set; }
        public string LocalName { get; set; } = "s";
        public string StatusText { get; set; } = "s";
        public string BitmapDll { get; set; }

        public Configman_Command(string CommandName)
        {
            this.intername = "s" + CommandName;
            CFG_SetBlockName(@"\configman\commands\" + CommandName);
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("weight", weight);
                CFG_AddInfo("cmdtype", cmdtype);
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
