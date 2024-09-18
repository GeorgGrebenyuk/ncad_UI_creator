﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// Конструкия для описания элементов CFG-файла menu и toolbar
    /// </summary>
    public class UniversalElement : CFG_Base
    {

        public string name { get; set; }
        public string intername { get; set; } = "";
        internal string menuName { get; set; } = "";

        public void SetData(string name, string intername = "", Menu_Item ParentMenu = null)
        {
            this.name = name;
            this.intername = intername;

            
            if (ElementMode == ElementVariant.Menu) menuName = @"menu\";
            else if (ElementMode == ElementVariant.Toolbars)  menuName = @"toolbars\";

            if (ParentMenu != null) menuName += ParentMenu.menuName + @"\";

            if (intername != "") menuName += intername;
            else menuName += name;

            CFG_SetBlockName(menuName);
        }

        public override string Content
        {
            get
            {
                CFG_AddInfo("name", name);
                if (intername != "") CFG_AddInfo("intername", intername);
                return p_Content;
            }
        }
    }
}