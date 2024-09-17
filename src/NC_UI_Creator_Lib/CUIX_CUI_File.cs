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

    public class CUIX_CUI_File : Aux_XML_DocumentBase
    {
        public const string CUI_DefaultName = "RibbonRoot.cui";
        public List<RibbonPanelSource> _RibbonPanelSourceCollection { get; set; }
        public List<RibbonTabSource> _RibbonTabSourceCollection { get; set; }

        public CUIX_CUI_File()
        {
            p_XML = new XDocument();

            _RibbonPanelSourceCollection = new List<RibbonPanelSource>();
            _RibbonTabSourceCollection = new List<RibbonTabSource>();
        }

        public override void SaveEdits()
        {
            RibbonRoot root = new RibbonRoot();

            RibbonPanelSourceCollection RibbonPanelSourceCollectionDef = new RibbonPanelSourceCollection();
            foreach (var def in _RibbonPanelSourceCollection)
            {
                RibbonPanelSourceCollectionDef.AddRibbonPanelSource(def);
            }
            root.SetRibbonPanelSourceCollection(RibbonPanelSourceCollectionDef);

            RibbonTabSourceCollection RibbonTabSourceCollectionDef = new RibbonTabSourceCollection();
            foreach (var def in _RibbonTabSourceCollection)
            {
                RibbonTabSourceCollectionDef.AddRibbonTabSource(def);
            }
            root.SetRibbonTabSourceCollection(RibbonTabSourceCollectionDef);

            p_XML.Add(root);
        }
    }
}
