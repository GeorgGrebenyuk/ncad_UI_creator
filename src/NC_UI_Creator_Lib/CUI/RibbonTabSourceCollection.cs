using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    /// <summary>
    /// Describe the collection of RibbonTabSource (link with ribbon and all panels in it)
    /// </summary>
    public class RibbonTabSourceCollection : Aux_XML_ElementBase
    {
        internal RibbonTabSourceCollection()
        {
            p_XML = new XElement("RibbonTabSourceCollection");
        }

        public void AddRibbonTabSource(RibbonTabSource RibbonTabSourceDef)
        {
            p_XML.Add(RibbonTabSourceDef.XML);
        }
    }
}
