﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NC_UI_Creator_Lib;
using NC_UI_Creator_Lib.CUI;
using NC_UI_Creator_Lib.CFG;

namespace NC_UI_Creator_Sample
{
    /// <summary>
    /// Класс с демонстрацией процессе генерации меню
    /// </summary>
    public class UI_Creator_Sample
    {
        [STAThread]
       public static void Main(string[] args)
       {

            UI_Creator uI_Creator = new UI_Creator();
            uI_Creator.DataSavePath = @"C:\Users\Georg\Documents\GitHub\ncad_UI_creator\test\1";
            //Создаем определение вспомогательного файла *.cui, составная CUIX, описывающий интерфейс
            //Создаем определение ленты "Sample ribbon"
            RibbonTabSource myTab = new RibbonTabSource("Sample ribbon", "SampleRibbonId");

            //Создаем панель с двумя кнопками (большой размер с картинками). Одна классическая, а другая с выпадающим списком
            RibbonPanelSource myPanel1 = new RibbonPanelSource("Panel1", "Panel 1");

            RibbonCommandButton myButton1_atPanel1 = new RibbonCommandButton("", "Button1", "Кнопка 1", ButtonStyleVariant.LargeWithText, Loader.NC_COMMAND_1);
            TooltipTitle myButton1_atPanel1_Help = new TooltipTitle("Запускает команду 1");
            myButton1_atPanel1.Tooltip = myButton1_atPanel1_Help;

            RibbonSplitButton myButton2_atPanel1 = new RibbonSplitButton("Группа кнопок", BehaviorVariant.SplitFollowStaticText, ButtonStyleVariant.LargeWithText);
            RibbonCommandButton myButton1_myButton2 = new RibbonCommandButton("", "Button2", "Кнопка-1 в группе", ButtonStyleVariant.LargeWithText, Loader.NC_COMMAND_2);
            TooltipTitle myButton1_myButton2_Help = new TooltipTitle("Запускает команду 1 из группы");
            myButton1_myButton2.Tooltip = myButton1_atPanel1_Help;

            RibbonCommandButton myButton2_myButton2 = new RibbonCommandButton("", "Button3", "Кнопка-2 в группе", ButtonStyleVariant.LargeWithText, Loader.NC_COMMAND_3);
            TooltipTitle myButton2_myButton2_Help = new TooltipTitle("Запускает команду 2 из группы");
            myButton2_myButton2.Tooltip = myButton2_myButton2_Help;

            myButton2_atPanel1.AddRibbonCommandButton(myButton1_myButton2);
            myButton2_atPanel1.AddRibbonCommandButton(myButton2_myButton2);

            //Добавляем кнопки на панель
            myPanel1.AddItem(myButton1_atPanel1);
            myPanel1.AddItem(myButton2_atPanel1);

            //Добавляем выпадающее меню (снизу панели)
            //Сперва добавляет специальный элемент, "сигнализирующий" о конце кнопок на панели
            myPanel1.AddRibbonPanelBreak();
            //Теперь добавим какую-либо новую кнопку
            RibbonCommandButton myButton4_atPanel1_Bottom = new RibbonCommandButton("", "Button4", "Кнопка 4 низ", ButtonStyleVariant.LargeWithText, Loader.NC_COMMAND_4);
            myPanel1.AddItem(myButton4_atPanel1_Bottom);


            //Добавляем ссылку на панель в ленту
            myTab.AddRibbonPanelSourceReference(myPanel1.Reference);
            //Также добавляем панель в cui_file
            uI_Creator._CUI._RibbonPanelSourceCollection.Add(myPanel1);
            //Добавляем информацию о связи панелей с лентой в cui
            uI_Creator._CUI._RibbonTabSourceCollection.Add(myTab);

            //Создаем вторую панель с мелкими иконками
            RibbonPanelSource myPanel2 = new RibbonPanelSource("Panel2", "Panel 2");
            //Создает специальный контейнер для иконок
            RibbonRowPanel myRowPanel1_atPanel2 = new RibbonRowPanel();

            uI_Creator._CUI.SaveEdits();
            uI_Creator.SaveCUIX();

            //Настройка классического меню, панелей инструментов и самих команд в памяти nanoCAD -- Наполнение CFG файла
            Ribbon myRibbon_CFG = new Ribbon("Sample ribbon", "%CFG_PATH%\\" + CUIX_File.CUIX_DefaultFileName);
            uI_Creator._CFG.Ribbons.Add(myRibbon_CFG);
            //Связывание кнопок с командами, настройка отображения текста кнопок и иконок (по желанию)
            Configman_Command myButton1_atPanel1_CFG = new Configman_Command(myButton1_atPanel1.MenuMacroID);
            myButton1_atPanel1_CFG.LocalName = myButton1_myButton2.Id;
            myButton1_atPanel1_CFG.DispName = myButton1_myButton2.Text;
            myButton1_atPanel1_CFG.StatusText = "Выводит окно 1";
            myButton1_atPanel1_CFG.BitmapDll = "Icons\\PseudoIcon_32.bmp";

            //Кнопка будет доступна вне любого документа
            myButton1_atPanel1_CFG.cmdType = CommandContextVariant.Application;
            uI_Creator._CFG.Configman.Commands.AddCommand(myButton1_atPanel1_CFG);

            Configman_Command myButton1_myButton2_CFG = new Configman_Command(myButton1_myButton2.MenuMacroID);
            myButton1_myButton2_CFG.LocalName = myButton1_atPanel1.Id;
            myButton1_myButton2_CFG.DispName = myButton1_atPanel1.Text;
            myButton1_myButton2_CFG.StatusText = "Кнопка 1 из группы на панели 1";
            myButton1_myButton2_CFG.cmdType = CommandContextVariant.Document;
            myButton1_myButton2_CFG.BitmapDll = "Icons\\PseudoIcon_32.bmp";
            uI_Creator._CFG.Configman.Commands.AddCommand(myButton1_myButton2_CFG);
            

            Configman_Command myButton2_myButton2_CFG = new Configman_Command(myButton2_myButton2.MenuMacroID);
            myButton2_myButton2_CFG.LocalName = myButton2_myButton2.Id;
            myButton2_myButton2_CFG.DispName = myButton2_myButton2.Text;
            myButton2_myButton2_CFG.StatusText = "Кнопка 2 из группы на панели 1";
            myButton2_myButton2_CFG.cmdType = CommandContextVariant.Document;
            myButton2_myButton2_CFG.BitmapDll = "Icons\\PseudoIcon_32.bmp";
            uI_Creator._CFG.Configman.Commands.AddCommand(myButton2_myButton2_CFG);

            Configman_Command myButton4_atPanel1_Bottom_CFG = new Configman_Command(myButton4_atPanel1_Bottom.MenuMacroID);
            myButton4_atPanel1_Bottom_CFG.LocalName = myButton4_atPanel1_Bottom.Id;
            myButton4_atPanel1_Bottom_CFG.DispName = myButton4_atPanel1_Bottom.Text;
            myButton4_atPanel1_Bottom_CFG.StatusText = "Кнопка 4 из выпадающей панели вниз";
            myButton4_atPanel1_Bottom_CFG.cmdType = CommandContextVariant.Document;
            myButton4_atPanel1_Bottom_CFG.BitmapDll = "Icons\\PseudoIcon_32.bmp";
            uI_Creator._CFG.Configman.Commands.AddCommand(myButton4_atPanel1_Bottom_CFG);
            
            //создание классического меню для панелей и кнопок на них
            uI_Creator.SaveCFG();
       }
    }
}