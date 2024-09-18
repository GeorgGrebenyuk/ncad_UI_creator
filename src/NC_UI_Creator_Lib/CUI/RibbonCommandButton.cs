using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonCommandButton : Aux_XML_ElementBase
    {
        public string UID { get; set; } = "";

        public string Id { get; set; }

        public string Text { get; set; }

        public ButtonStyleVariant ButtonStyle { get; set; }

        public string MenuMacroID { get; set; }

        public string KeyTip { get; set; }

        public RibbonCommandButton(string uID, string id, string text, ButtonStyleVariant buttonStyle, string menuMacroID, string keyTip = "")
        {
            UID = uID;
            Id = id;
            Text = text;
            ButtonStyle = buttonStyle;
            MenuMacroID = menuMacroID;
            KeyTip = keyTip;

            p_XML = new XElement("RibbonCommandButton");
            p_XML.Add(new XAttribute("UID", UID));
            p_XML.Add(new XAttribute("Id", Id));
            p_XML.Add(new XAttribute("ButtonStyle", ButtonStyle.ToString()));
            p_XML.Add(new XAttribute("MenuMacroID", MenuMacroID));
            p_XML.Add(new XAttribute("KeyTip", KeyTip));
        }
    }
}
