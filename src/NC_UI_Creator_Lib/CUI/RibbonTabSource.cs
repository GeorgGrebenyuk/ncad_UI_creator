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
        //=Text
        public string Title { get; set; }

        public string UID { get; set; }

        public RibbonTabSource(string Title, string UID = "")
        {
            if (UID == "") UID = Title + "_Tab";
            this.UID = UID;
            this.Title = Title;

            p_XML = new XElement("RibbonTabSource");
            p_XML.Add(new XAttribute("UID", this.UID));
            p_XML.Add(new XAttribute("Text", this.Title));
        }

        public void AddRibbonPanelSourceReference(RibbonPanelSourceReference RibbonPanelSourceReferenceDef)
        {
            p_XML.Add(RibbonPanelSourceReferenceDef.XML);
        }
    }
}
