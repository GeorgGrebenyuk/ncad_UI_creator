using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CFG
{
    
    public class Configman : CFG_Base
    {
        public Configman()
        {
            Commands = new Configman_Commands();
            CFG_SetBlockName(@"\configman");
        }
        public Configman_Commands Commands { get; private set; }

        public override string Content
        {
            get
            {
                CFG_AddContent(Commands.Content);
                return p_Content;
            }
        }
    }
}
