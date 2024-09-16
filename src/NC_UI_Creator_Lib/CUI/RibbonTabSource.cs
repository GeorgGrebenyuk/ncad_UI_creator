using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonTabSource : Aux_XML_ElementBase
    {
        public string Text { get; set; }

        public string UID { get; set; }

        public RibbonTabSource(string _Text, string _UID)
        {
            this.UID = _UID;
            this.Text = _Text;

            p_XML = new XElement("RibbonTabSource");
            p_XML.Add(new XAttribute("UID", this.UID));
            p_XML.Add(new XAttribute("Text", this.Text));
        }

        public void AddRibbonPanelSourceReference(RibbonPanelSourceReference RibbonPanelSourceReferenceDef)
        {
            p_XML.Add(RibbonPanelSourceReferenceDef.XML);
        }
    }
}
