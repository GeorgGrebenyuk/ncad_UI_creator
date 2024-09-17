using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC_UI_Creator_Lib;

namespace NC_UI_Creator_Lib.Attributes
{
    /// <summary>
    /// Определение функции для CUIX-файла
    /// </summary>
    public class FunctionAtCuiDefinition : Attribute
    {
        public enum UI_ModeVariant
        {
            RibbonCommandButton,
            RibbonSplitButton,
            RibbonRowButton
        }
        //RibbonPanelSource
        public string PanelSourceName { get; set; }

        //TODO: update for classic menu

        public UI_ModeVariant UI_Mode { get; set; } = UI_ModeVariant.RibbonCommandButton;

        public string RibbonSplitButtonName { get; set; } = "";

        public ButtonStyleVariant ButtonStyle { get; set; } = ButtonStyleVariant.LargeWithText;

        //CommandMethod
        //public string FunctionName { get; set; }
    }
}
