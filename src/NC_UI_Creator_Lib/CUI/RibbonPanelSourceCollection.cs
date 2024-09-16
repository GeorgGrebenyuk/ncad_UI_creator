using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonPanelSourceCollection : Aux_XML_ElementBase
    {
        public RibbonPanelSourceCollection()
        {
            p_XML = new XElement("RibbonPanelSourceCollection");
        }

        public void AddRibbonPanelSource(RibbonPanelSource RibbonPanelSourceDef)
        {
            p_XML.Add(RibbonPanelSourceDef.XML);
        }


    }
}
