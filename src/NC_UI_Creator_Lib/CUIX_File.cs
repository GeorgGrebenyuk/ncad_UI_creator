using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NC_UI_Creator_Lib
{
    public class CUIX_File
    {
        internal CUIX_File() { }

        public CUIX_CUI_File _CUI { get; set; }
        public CUIX_CT_File _CT { get; set; }
        public CUIX_MPI_File _MPI { get; set; }

        public const string CUIX_DefaultFileName = "NC_UI_DEF.cuix";

        public CUIX_File(CUIX_CUI_File CUI, CUIX_CT_File CT , CUIX_MPI_File MPI)
        {
            this._CUI = CUI;
            this._CT = CT;
            this._MPI = MPI;
        }

        public void Save(string cuixDefaultFileName = CUIX_DefaultFileName, string cuixSaveDirectoryPath = "")
        {
            if (cuixSaveDirectoryPath == "") cuixSaveDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(cuixSaveDirectoryPath)) Directory.CreateDirectory(cuixSaveDirectoryPath);
            

            string CUI_Path = Path.Combine(cuixSaveDirectoryPath, CUIX_CUI_File.CUI_DefaultName);
            string CT_Path = Path.Combine(cuixSaveDirectoryPath, CUIX_CT_File.CT_DefaultName);
            string MPI_Path = Path.Combine(cuixSaveDirectoryPath, CUIX_MPI_File.MPI_DefaultName);
            string CUIX_Path = Path.Combine(cuixSaveDirectoryPath, cuixDefaultFileName);

            _CUI.Write(CUI_Path);
            _CT.Write(CT_Path);
            _MPI.Write(MPI_Path);

            if (File.Exists(CUIX_Path)) File.Delete(CUIX_Path);

            try
            {
                using (var zip = ZipFile.Open(CUIX_Path, ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(CUI_Path, Path.GetFileName(CUI_Path));
                    zip.CreateEntryFromFile(CT_Path, Path.GetFileName(CUI_Path));
                    zip.CreateEntryFromFile(MPI_Path, Path.GetFileName(CUI_Path));
                }
            }
            catch (Exception e) { throw new Exception(e.Message); }

            
        }
    }
}
