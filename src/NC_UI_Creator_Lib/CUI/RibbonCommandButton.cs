using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    /// <summary>
    /// Describe the RibbonCommandButton elements of CUI (information about single button)
    /// </summary>
    public class RibbonCommandButton : Aux_XML_ElementBase, ItemOfPanel
    {
        public string UID { get; set; } = "";

        public string Id { get; set; } = "";

        //=Text
        public string Text { get; set; }

        public ButtonStyleVariant ButtonStyle { get; set; }

        public string MenuMacroID { get; set; }

        public string KeyTip { get; set; }

        private TooltipTitle p_Tooltip;
        public TooltipTitle Tooltip 
        { 
            get 
            { 
                return p_Tooltip;
            } 
            set
            {
                if (value.Value != "") 
                {
                    p_Tooltip = value;
                    p_XML.Add(value.XML);
                }
            }
        }

        public RibbonCommandButton(string title, ButtonStyleVariant buttonStyle, string menuMacroID, string id = "", string uID = "", string keyTip = "")
        {
            UID = uID;
            Id = id;
            Text = title;
            ButtonStyle = buttonStyle;
            MenuMacroID = menuMacroID;
            KeyTip = keyTip;

            p_XML = new XElement("RibbonCommandButton");
            p_XML.Add(new XAttribute("UID", UID));
            p_XML.Add(new XAttribute("Id", Id));
            p_XML.Add(new XAttribute("Text", Text));
            p_XML.Add(new XAttribute("ButtonStyle", ButtonStyle.ToString()));
            p_XML.Add(new XAttribute("MenuMacroID", MenuMacroID));
            p_XML.Add(new XAttribute("KeyTip", KeyTip));
        }

        public ItemOfPanelVariant GetVariant()
        {
            return ItemOfPanelVariant.RibbonCommandButton;
        }
    }
}
