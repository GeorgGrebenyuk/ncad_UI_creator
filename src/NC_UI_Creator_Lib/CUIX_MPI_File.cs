using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// Класс для представления файла Menu_Package_Info.xml
    /// </summary>
    public class CUIX_MPI_File : Aux_XML_DocumentBase
    {
        public const string MPI_DefaultName = "Menu_Package_Info.xml";
        public CUIX_MPI_File()
        {
            p_XML = new XDocument();
        }

        public static CUIX_MPI_File CreateDefault()
        {
            CUIX_MPI_File file_def = new CUIX_MPI_File();
            MenuPackageParts data_def = new MenuPackageParts();
            data_def.AddPartData(new PartData("/" + CUIX_CUI_File.CUI_DefaultName));
            data_def.AddPartData(new PartData("/" + CUIX_MPI_File.MPI_DefaultName));

            file_def.p_XML.Add(data_def.XML);

            return file_def;
        }
    }

    public class PartData : Aux_XML_ElementBase
    {
        public string PartData_Name {  get; set; }
        public string PartData_Modified { get; set; }

        public PartData(string _PartData_Name)
        {
            this.PartData_Name = _PartData_Name;
            var utc_time = DateTime.UtcNow;
            this.PartData_Modified = $"{utc_time.Year}-{utc_time.Month}-{utc_time.Day}T{utc_time.Hour}:{utc_time.Minute}:{utc_time.Second}.{utc_time.Millisecond}+00:00";
        }
    }
    public class MenuPackageParts : Aux_XML_ElementBase
    {
        public MenuPackageParts()
        {
            p_XML = new XElement("MenuPackageParts");
        }

        public void AddPartData(PartData PartDataDef)
        {
            p_XML.Add(PartDataDef.XML);
        }

        
    }
}
