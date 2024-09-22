using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Describe the location of one toolbar block of CFG
    /// </summary>
    public class ToolbarsPos_Item : CFG_Base
    {
        public DockPositionVariant DockPosition {  get; set; }
        public int row { get; set; }
        public int pos { get; set; }
        public bool InitialVisible { get; set; } = false;
        public ToolbarsPos_Item(Toolbar_Item Toolbar)
        {
            CFG_SetBlockName(@"\toolbarspos\" + Toolbar.menuName.Replace("menu\\", ""));
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("DockPosition", DockPosition.ToString());
                CFG_AddInfo("row", row);
                CFG_AddInfo("pos", pos);
                CFG_AddInfo("InitialVisible", InitialVisible);
                return p_Content;
            }
        }
    }
}
