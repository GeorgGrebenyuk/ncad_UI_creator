using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    /// <summary>
    /// Describe the link of RibbonPanelSource
    /// </summary>
    public class RibbonPanelSourceReference : Aux_XML_ElementBase
    {
        public string UID { get; set; }

        public string PanelId { get; set; }

        public string ResizeStyle { get; set; }

        public RibbonPanelSourceReference(string _UID, string _PanelId, string _ResizeStyle = "Default")
        {
            this.UID = _UID;
            this.PanelId = _PanelId;
            this.ResizeStyle = _ResizeStyle;

            p_XML = new XElement("RibbonPanelSourceReference");
            p_XML.Add(new XAttribute("UID", this.UID));
            p_XML.Add(new XAttribute("PanelId", this.PanelId));
            p_XML.Add(new XAttribute("ResizeStyle", this.ResizeStyle));
        }
    }
}
