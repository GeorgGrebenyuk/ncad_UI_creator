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

        //=Text
        public string Title { get; set; }

        public string HiddenInEditor { get; set; }

        private List<ItemOfPanel> Items { get; }

        public RibbonPanelSource(string Title, string UID = "",  bool _HiddenInEditor = false)
        {
            if (UID == "") UID = Title;
            this.UID = UID;
            this.Title = Title;
            this.HiddenInEditor = $"{_HiddenInEditor}";
            this.Items = new List<ItemOfPanel>();

            p_XML = new XElement("RibbonPanelSource");
            p_XML.Add(new XAttribute("UID", UID));
            p_XML.Add(new XAttribute("Text", Title));
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

        public void AddItem(ItemOfPanel item)
        {
            Items.Add(item);
            ItemOfPanelVariant ItemOfPanel_Type = item.GetVariant();

            XElement item_XML = null;
            if (ItemOfPanel_Type == ItemOfPanelVariant.RibbonSplitButton) item_XML = ((RibbonSplitButton)item).XML;
            else if (ItemOfPanel_Type == ItemOfPanelVariant.RibbonCommandButton) item_XML = ((RibbonCommandButton)item).XML;
            else if (ItemOfPanel_Type == ItemOfPanelVariant.RibbonRow) item_XML = ((RibbonRow)item).XML;
            else if (ItemOfPanel_Type == ItemOfPanelVariant.RibbonRowPanel) item_XML = ((RibbonRowPanel)item).XML;
            else if (ItemOfPanel_Type == ItemOfPanelVariant.RibbonPanelBreak) item_XML = ((RibbonPanelBreak)item).XML;

            if (item_XML != null) p_XML.Add(item_XML);
            else
            {
                throw new Exception("Неизвестный тип ItemOfPanel" + item);
            }
        }

        /// <summary>
        /// Вспомогательный элемент, сигнализирующий, что далее идет выпадающая часть панели
        /// </summary>
        public void AddRibbonPanelBreak()
        {
            p_XML.Add(RibbonPanelBreak.Create().XML);
        }

        //public void AddRibbonCommandButton(RibbonCommandButton RibbonCommandButtonDef)
        //{
        //    p_XML.Add(RibbonCommandButtonDef.XML);
        //}

        //public void AddRibbonSplitButton(RibbonSplitButton RibbonSplitButtonDef)
        //{
        //    p_XML.Add(RibbonSplitButtonDef.XML);
        //}

        //public void AddRibbonRowPanel(RibbonRowPanel RibbonRowPanelDef)
        //{
        //    p_XML.Add(RibbonRowPanelDef.XML);
        //}

    }
}
