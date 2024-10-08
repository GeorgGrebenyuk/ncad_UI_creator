﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NC_UI_Creator_Lib
{
    /// <summary>
    /// The auxiliary class with functions to create CUIX + CFG files and their content
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
        public CUIX_CUI_File _CUI { get; private set; }
        public CUIX_CT_File _CT { get; private set; } = CUIX_CT_File.CreateDefault();
        public CUIX_MPI_File _MPI { get; private set; } = CUIX_MPI_File.CreateDefault();

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

        public void SaveCUIX(bool DelTempFiles = false, string CUIXFileName = CUIX_File.CUIX_DefaultFileName)
        {
            this.CUIX_FileName = CUIXFileName;
            var _CUIX = new CUIX_File(_CUI, _CT, _MPI);
            _CUIX.Save(CUIXFileName, DataSavePath, DelTempFiles);
        }

        public void SaveCFG(string CFGFileName = CFG_File.CFG_DefaultFileName)
        {
            this.CFG_FileName = CFGFileName;
            _CFG.Save(CFGFileName, DataSavePath);
        }
    }
}
