using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// Общий класс с функциональностью по созданию CFG + CUIX
    /// </summary>
    public class UI_Creator
    {
        public UI_Creator()
        {
            Initialize();
        }
        public void Initialize()
        {
            _CUI = new CUIX_CUI_File();
            _CT = CUIX_CT_File.CreateDefault();
            _MPI = CUIX_MPI_File.CreateDefault();
            _CFG = new CFG_File();
        }
        public CUIX_CUI_File _CUI { get; set; }
        public CUIX_CT_File _CT { get; set; } = CUIX_CT_File.CreateDefault();
        public CUIX_MPI_File _MPI { get; set; } = CUIX_MPI_File.CreateDefault();

        public CFG_File _CFG { get; set; }

        private string CUIX_FileName = CUIX_File.CUIX_DefaultFileName;
        public string CUIX_DefaultFilePath
        {
            get
            {
                return Path.Combine(DataSavePath, CUIX_FileName);
            }
        }

        private string CFG_FileName = CFG_File.CFG_DefaultFileName;
        public string CFG_DefaultFilePath
        {
            get
            {
                return Path.Combine(DataSavePath, CFG_FileName);
            }
        }

        /// <summary>
        /// Абсолютный путь до папки, где будут сохранены CUIX (и его части) и CFG. По-умолчанию это текущий каталог с DLL
        /// </summary>
        public string DataSavePath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;


        //public void SetCUI (CUIX_CUI CUI)
        //{
        //    this._CUI = CUI;
        //}

        //public void SetCT(CUIX_CT CT)
        //{
        //    this._CT = CT;
        //}

        //public void SetMPI(CUIX_MPI MPI)
        //{
        //    this._MPI = MPI;
        //}

        public void SaveCUIX(string CUIXFileName = CUIX_File.CUIX_DefaultFileName)
        {
            CUIX_FileName = CUIXFileName;
            var _CUIX = new CUIX_File(_CUI, _CT, _MPI);
            _CUIX.Save(CUIXFileName, DataSavePath);
        }

        public void SaveCFG(string CFGFileName = CFG_File.CFG_DefaultFileName)
        {
            CFG_FileName = CFGFileName;
            var _CFG = new CFG_File();
            _CFG.Save(CFGFileName, DataSavePath);
        }
    }
}
