﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// Describe the [Content_Types].xml file (the un-compulsory part of CUIX)
    /// </summary>
    public class CUIX_CT_File : Aux_XML_DocumentBase
    {
        public const string CT_DefaultName = "[Content_Types].xml";

        internal CUIX_CT_File()
        {
            p_XML = new XDocument();

        }
        public static CUIX_CT_File CreateDefault()
        {
            CUIX_CT_File file_def = new CUIX_CT_File();
            file_def.p_XML = new XDocument();

            Types types_def = new Types();
            types_def.AddDefault(new Default("cui", "text/xml"));
            types_def.AddDefault(new Default("rels", "application/vnd.openxmlformats-package.relationships+xml"));
            types_def.AddDefault(new Default("xml", "text/xml"));
            file_def.p_XML.Add(types_def.XML);

            return file_def;
        }
    }

    public class Types : Aux_XML_ElementBase
    {
        public Types()
        {
            p_XML = new XElement("Types");
        }

        public void AddDefault(Default DefaultDef)
        {
            p_XML.Add(DefaultDef.XML);
        }
    }

    public class Default : Aux_XML_ElementBase
    {
        public string Extension { get; set; }

        public string ContentType { get; set; }

        public Default(string _Extension, string _ContentType)
        {
            this.Extension = _Extension;
            this.ContentType = _ContentType;

            p_XML = new XElement("Default");
            p_XML.Add(new XAttribute("Extension", this.Extension));
            p_XML.Add(new XAttribute("ContentType", this.ContentType));
        }
    }
}
