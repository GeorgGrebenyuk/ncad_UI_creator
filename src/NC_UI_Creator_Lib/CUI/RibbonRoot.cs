using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    /// <summary>
    /// Describe the root-element of CUI-file
    /// </summary>
    public class RibbonRoot : Aux_XML_ElementBase
    {

        internal RibbonRoot()
        {
            p_XML = new XElement("RibbonRoot");
        }

        public void SetRibbonPanelSourceCollection(RibbonPanelSourceCollection RibbonPanelSourceCollectionDef)
        {
            p_XML.Add(RibbonPanelSourceCollectionDef.XML);
        }

        public void SetRibbonTabSourceCollection(RibbonTabSourceCollection RibbonTabSourceCollectionDef)
        {
            p_XML.Add(RibbonTabSourceCollectionDef.XML);
        }
    }
}
