using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonRowPanel : Aux_XML_ElementBase, ItemOfPanel
    {
        public string UID { get; set; }
        public ResizeStyleVariant ResizeStyle {  get; set; }

        public int ResizePriority { get; set; }

        public BooleanUpperVariant TopJustify { get; set; } = BooleanUpperVariant.True;
        public RibbonRowPanel(string _UID = "", ResizeStyleVariant _ResizeStyle = ResizeStyleVariant.None, int _ResizePriority = 100, BooleanUpperVariant _TopJustify = BooleanUpperVariant.True)
        {
            UID = _UID;
            ResizeStyle = _ResizeStyle;
            ResizePriority = _ResizePriority;
            TopJustify = _TopJustify;

            p_XML = new XElement("RibbonRowPanel");
            p_XML.Add(new XAttribute("UID", this.UID));
            p_XML.Add(new XAttribute("ResizeStyle", this.ResizeStyle.ToString()));
            p_XML.Add(new XAttribute("ResizePriority", this.ResizePriority.ToString()));
            p_XML.Add(new XAttribute("TopJustify", this.TopJustify.ToString()));
        }

        public void AddRibbonRow(RibbonRow RibbonRowDef)
        {
            this.p_XML.Add(RibbonRowDef.XML);
        }

        public ItemOfPanelVariant GetVariant()
        {
            return ItemOfPanelVariant.RibbonRowPanel;
        }
    }
}
