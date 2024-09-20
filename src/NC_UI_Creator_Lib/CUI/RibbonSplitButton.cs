using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonSplitButton : Aux_XML_ElementBase, ItemOfPanel
    {
        //=Text
        public string Title { get; set; }
        public BehaviorVariant Behavior { get; set; }
        public ButtonStyleVariant ButtonStyle { get; set; }

        public RibbonSplitButton(string _Title, BehaviorVariant _Behavior, ButtonStyleVariant _ButtonStyle)
        {
            this.Title = _Title;
            this.Behavior = _Behavior;
            this.ButtonStyle = _ButtonStyle;

            p_XML = new XElement("RibbonSplitButton");
            p_XML.Add(new XAttribute("Text", this.Title));
            p_XML.Add(new XAttribute("Behavior", this.Behavior.ToString()));
            p_XML.Add(new XAttribute("ButtonStyle", this.ButtonStyle.ToString()));

        }

        public void AddRibbonCommandButton(RibbonCommandButton RibbonCommandButtonDef)
        {
            this.p_XML.Add(RibbonCommandButtonDef.XML);
        }

        public ItemOfPanelVariant GetVariant()
        {
            return ItemOfPanelVariant.RibbonSplitButton;
        }
    }
}
