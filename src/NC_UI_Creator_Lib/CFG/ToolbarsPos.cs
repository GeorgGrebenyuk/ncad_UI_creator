using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Describe the "toolbarspos" block (location of toolbar elements) of CFG
    /// </summary>
    public class ToolbarsPos : CFG_Base
    {
        public ToolbarsPos() 
        { 
            CFG_SetBlockName(@"\toolbarspos");
            ToolbarsPosElements = new List<ToolbarsPos_Item>();
        }
        public List<ToolbarsPos_Item> ToolbarsPosElements { get; set; }

        
        public override string Content
        {
            get
            {
                foreach (var ToolbarsPosInfoOne in ToolbarsPosElements)
                {
                    CFG_AddContent(ToolbarsPosInfoOne.Content);
                }
                return p_Content;
            }
        }

        public bool IsAny()
        {
            return ToolbarsPosElements.Any();
        }
    }
}
