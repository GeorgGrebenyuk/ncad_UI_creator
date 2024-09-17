using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CFG
{
    public abstract class CFG_Base
    {
        //public string BlockName { get; set; }
        internal void CFG_SetBlockName(string name)
        {
            p_Content += $"[{name}]" + Environment.NewLine;
        }

        internal void CFG_AddInfo(string blockName, string blockValue)
        {
            p_Content += $"{blockName}={blockValue}" + Environment.NewLine;
        }

        internal void CFG_AddContent (string content)
        {
            p_Content += content + Environment.NewLine;
        }

        public virtual string Content { get { return p_Content; } }
        internal string p_Content = "";
    }
}
