﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib.CFG
{
    public enum ElementVariant
    {
        _No,
        Menu,
        Toolbars
    }

    public enum DockPositionVariant
    {
        sTop
    }

    /// <summary>
    /// The context of commands (accessibility of buttons)
    /// </summary>
    public enum CommandContextVariant : int
    {
        //Application = i0
        Application = 0,
        //Document = i1
        Document = 1
    }

    //For CFG BitmapDll
    public enum IconVariant
    {
        BMP,
        ICO
    }

    //For CFG BitmapDll
    public enum IconResourceVariant
    {
        LocalFile,
        ResDll
    }

    public abstract class CFG_Base
    {
        //public string BlockName { get; set; }
        public ElementVariant ElementMode { get; set; } = ElementVariant._No;
        internal void CFG_SetBlockName(string name)
        {
            p_Content += $"[{name}]" + Environment.NewLine;
        }

        internal void CFG_AddInfo(string blockName, object blockValue)
        {
            if (blockValue == null) return;
            string s_symbol = "";
            Type blockValueType = blockValue.GetType();
            if (blockValueType.IsEnum)
            {
                s_symbol = "i";
                blockValue = (int)blockValue;
            }
            else if (blockValueType == typeof(int)) s_symbol = "i";
            else if (blockValueType == typeof(string)) s_symbol = "s";
            else if (blockValueType == typeof(bool)) 
            {
                s_symbol = "f";
                if ((bool)blockValue == true) blockValue = "1";
                else blockValue = "0";
            }


            p_Content += $"{blockName}={s_symbol}{blockValue}" + Environment.NewLine;
        }

        internal void CFG_AddContent (string content)
        {
            p_Content += content + Environment.NewLine;
        }

        public virtual string Content { get { return p_Content; } }
        internal string p_Content = "";
    }
}
