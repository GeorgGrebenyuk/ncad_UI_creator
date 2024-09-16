using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    public class RibbonRow : Aux_XML_ElementBase
    {
        public RibbonRow()
        {
            p_XML = new XElement("RibbonRow");
        }

        public void AddRibbonCommandButton(RibbonCommandButton RibbonCommandButtonDef)
        {
            this.p_XML.Add(RibbonCommandButtonDef.XML);
        }
    }
}
