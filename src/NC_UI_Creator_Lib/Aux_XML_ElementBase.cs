using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib
{

    public abstract class Aux_XML_ElementBase 
    {
        public XElement XML { get { return p_XML; } }

        internal protected XElement p_XML;
    }

    public abstract class Aux_XML_DocumentBase
    {
        public XDocument XML { get { return p_XML; } }

        internal protected XDocument p_XML;

        public void Write(string path)
        {
            try
            {
                this.XML.Save(path);
            }
            catch (Exception ex) { throw new Exception("The error if saving by path = " + path + " " + ex.Message); }
        }

        public virtual void SaveEdits() { }
    }


}
