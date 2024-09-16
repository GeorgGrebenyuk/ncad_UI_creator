using NC_UI_Creator_Lib.CUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib
{
    public enum ButtonStyleVariant
    {
        LargeWithText,
        LargeWithoutText,
        MediumWithText,
        MediumWithoutText,
        SmallWithText,
        SmallWithoutText
    }

    public enum BehaviorVariant
    {
        SplitFollowStaticText
    }

    public enum ResizeStyleVariant
    {
        None
    }

    public class CUIX_CUI : Aux_XML_DocumentBase
    {
        public const string CUI_DefaultName = "RibbonRoot.cui";

        public CUIX_CUI()
        {
            p_XML = new XDocument();
        }

        public void SetRibbonRoot(RibbonRoot RibbonRootDef)
        {
            this.p_XML.Add(RibbonRootDef.XML);
        }
    }
}
