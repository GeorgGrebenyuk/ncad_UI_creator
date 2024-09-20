using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonPanelBreak : Aux_XML_ElementBase, ItemOfPanel
    {
        public RibbonPanelBreak()
        {
            p_XML = new XElement("RibbonPanelBreak", new XAttribute("Id", "RibbonPanelBreak"));
        }

        public static RibbonPanelBreak Create()
        {
            return new RibbonPanelBreak();
        }

        public ItemOfPanelVariant GetVariant()
        {
            return ItemOfPanelVariant.RibbonPanelBreak;
        }
    }
}
