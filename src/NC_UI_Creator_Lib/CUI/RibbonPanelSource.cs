using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonPanelSource : Aux_XML_ElementBase
    {
        public string UID { get; set; }

        public string Text { get; set; }

        public string HiddenInEditor { get; set; }

        public RibbonPanelSource(string _UID, string _Text, bool _HiddenInEditor = false)
        {
            this.UID = _UID;
            this.Text = _Text;
            this.HiddenInEditor = $"{_HiddenInEditor}";

            p_XML = new XElement("RibbonPanelSource");
            p_XML.Add(new XAttribute("UID", UID));
            p_XML.Add(new XAttribute("Text", Text));
            p_XML.Add(new XAttribute("HiddenInEditor", HiddenInEditor));


        }

        public RibbonPanelSourceReference Reference
        {
            get
            {
                RibbonPanelSourceReference Ref = new RibbonPanelSourceReference("", this.UID);
                return Ref;
            }
        }

        public void AddRibbonCommandButton(RibbonCommandButton RibbonCommandButtonDef)
        {
            p_XML.Add(RibbonCommandButtonDef.XML);
        }

        public void AddRibbonSplitButton(RibbonSplitButton RibbonSplitButtonDef)
        {
            p_XML.Add(RibbonSplitButtonDef.XML);
        }

        public void AddRibbonRowPanel(RibbonRowPanel RibbonRowPanelDef)
        {
            p_XML.Add(RibbonRowPanelDef.XML);
        }

    }
}
