using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Describe the "ribbon" block of CFG
    /// </summary>
    public class Ribbon : CFG_Base
    {
        public string RibbonName { get; set; }
        public string CUIX_Path { get; set; } = "%CFG_PATH%\\" + CUIX_File.CUIX_DefaultFileName;
        public bool Visiable { get; set; } = true;
        public Ribbon(string RibbonName, string CUIX_Path = "")
        {
            if (CUIX_Path != "") this.CUIX_Path = CUIX_Path;
            this.RibbonName = RibbonName;
            CFG_SetBlockName(@"\ribbon\" + RibbonName);
            
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("CUIX", CUIX_Path);
                CFG_AddInfo("visiable", Visiable);

                return p_Content;
            }
        }
    }
}
