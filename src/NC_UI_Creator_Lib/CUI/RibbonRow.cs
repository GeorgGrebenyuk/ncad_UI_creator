using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CUI
{
    /// <summary>
    /// Describe the RibbonRow-element of CUI
    /// </summary>
    public class RibbonRow : Aux_XML_ElementBase, ItemOfPanel
    {
        public RibbonRow()
        {
            p_XML = new XElement("RibbonRow");
        }

        //public void AddRibbonCommandButton(RibbonCommandButton RibbonCommandButtonDef)
        //{
        //    this.p_XML.Add(RibbonCommandButtonDef.XML);
        //}

        //public void AddRibbonSplitButton(RibbonSplitButton RibbonSplitButtonDef)
        //{
        //    this.p_XML.Add(RibbonSplitButtonDef.XML);
        //}

        public void AddItem(ItemOfPanel item)
        {
            if (item.GetVariant() == ItemOfPanelVariant.RibbonSplitButton) this.p_XML.Add(((RibbonSplitButton)item).XML);
            else if (item.GetVariant() == ItemOfPanelVariant.RibbonCommandButton) this.p_XML.Add(((RibbonCommandButton)item).XML);
        }

        public ItemOfPanelVariant GetVariant()
        {
            return ItemOfPanelVariant.RibbonRow;
        }
    }
}
