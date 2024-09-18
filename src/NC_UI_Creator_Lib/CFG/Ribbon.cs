using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    public class Ribbon : CFG_Base
    {
        public string RibbonName { get; set; }
        public string CUIX_Path { get; set; }
        public Ribbon(string RibbonName, string CUIX_Path)
        {
            this.RibbonName = RibbonName;
            this.CUIX_Path = CUIX_Path;
            CFG_SetBlockName(@"\ribbon\" + RibbonName);
            
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("CUIX", CUIX_Path);

                return p_Content;
            }
        }
    }
}
