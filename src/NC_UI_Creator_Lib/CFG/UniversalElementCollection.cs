using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Конструкия для описания группы элементов CFG-файла menu и toolbar
    /// </summary>
    public class UniversalElementCollection : CFG_Base
    {
        public List<UniversalElement> Elements { get; private set; }
        public UniversalElementCollection(ElementVariant variant)
        {
            ElementMode = variant;

            string elementName = "";
            if (ElementMode == ElementVariant.Menu) elementName = @"\menu";
            else if (ElementMode == ElementVariant.Toolbars) elementName = @"\toolbars";
            CFG_SetBlockName(elementName);

            Elements = new List<UniversalElement>();
        }

        public void AddItem(UniversalElement ItemDef)
        {
            if (ItemDef.name != "" && !Elements.Where(c => c.name == ItemDef.name).Any()) Elements.Add(ItemDef);
        }

        public bool IsAny()
        {
            return Elements.Any(); 
        }

        public override string Content
        {
            get
            {

                foreach (var menu in Elements)
                {
                    CFG_AddContent(menu.Content);
                }
                return p_Content;
            }
        }
    }
}
