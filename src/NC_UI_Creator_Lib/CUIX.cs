using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib
{
    public class CUIX
    {
        public CUIX() { }

        public string CUI_Path { get; set; }
        public string CT_Path { get; set; }
        public string MPI_Path { get; set; }

        public CUIX(string _CUI_Path, string _CT_Path, string _MPI_Path)
        {
            this.CUI_Path = _CUI_Path;
            this.CT_Path = _CT_Path;
            this.MPI_Path = _MPI_Path;
        }

        public void Save(string cuixSaveFilePath)
        {
            using (var zip = ZipFile.Open(cuixSaveFilePath, ZipArchiveMode.Create))
            {
                zip.CreateEntryFromFile(this.CUI_Path, Path.GetFileName(this.CUI_Path));
                zip.CreateEntryFromFile(this.CT_Path, Path.GetFileName(this.CT_Path));
                zip.CreateEntryFromFile(this.MPI_Path, Path.GetFileName(this.MPI_Path));
            }
        }
    }
}
