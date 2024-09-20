using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    //TODO: Разобраться с элементом (непонятно, что он делает), т.к. влияния не видно
    public class TooltipTitle : Aux_XML_ElementBase
    {
        public BooleanLowerVariant xlate {  get; set; }
        public string UID { get; set; } = "";// "i" + Guid.NewGuid().ToString("N");

        public string Value { get; set; } = "";
        public TooltipTitle(string value, string UID = "",  BooleanLowerVariant xlate = BooleanLowerVariant.True)
        {
            this.xlate = xlate;
            this.Value = value;
            if (UID != "") this.UID = UID;

            p_XML = new XElement("TooltipTitle");
            p_XML.Add(new XAttribute("xlate", this.xlate.ToString().ToLower()));
            p_XML.Add(new XAttribute("UID", this.UID));
            p_XML.SetValue(value);

        }
    }
}
