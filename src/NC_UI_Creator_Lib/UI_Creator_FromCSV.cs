using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NC_UI_Creator_Lib.CUI;
using NC_UI_Creator_Lib.CFG;
using static NC_UI_Creator_Lib.UI_Creator_FromCSV_Config;

namespace NC_UI_Creator_Lib
{
    
    /// <summary>
    /// The auxiliary class for generate UI from CSV file. Look docs for more info.
    /// </summary>
    public class UI_Creator_FromCSV
    {
        /// <summary>
        /// The auxiliary class, describe the single command (button)
        /// </summary>
        internal class CSV_Info
        {
            public string CommandName { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string Panel {  get; set; }
            public ButtonStyleVariant ButtonStyle {  get; set; }
            public string SplitButtonName { get; set; } = "";
            //?
            //public bool Use { get; set; } = true;

            public CSV_Info(string fileLine, char separator)
            {
                string[] fileLineData = fileLine.Split(separator);
                if (fileLineData.Length != 6) throw new Exception("Число аргументов не равно семи");

                CommandName = fileLineData[0];
                DisplayName = fileLineData[1];
                Description = fileLineData[2];
                Panel = fileLineData[3];
                ButtonStyleVariant ButtonStyleTemp = ButtonStyleVariant.LargeWithText;
                Enum.TryParse(fileLineData[4], out ButtonStyleTemp);
                ButtonStyle = ButtonStyleTemp;
                SplitButtonName = fileLineData[5];
            }

            
        }

        
        private CSV_Info[] Data { get; set; }
        private UI_Creator_FromCSV_Config _Config { get; set; }
        public UI_Creator_FromCSV(UI_Creator_FromCSV_Config config, string configPath)
        {
            _Config = config;
            if (!File.Exists(_Config.CSV_FilePath))
            {
                string CSV_FilePath_0 = _Config.CSV_FilePath;
                _Config.CSV_FilePath = Path.Combine(Path.GetDirectoryName(configPath), _Config.CSV_FilePath);
                if (!File.Exists(_Config.CSV_FilePath))
                {
                    throw new FileNotFoundException("Файл не найден " + _Config.CSV_FilePath);
                }
                    
            }
            //Modes = modes;
            _Config.RibbonName = Path.GetFileNameWithoutExtension(_Config.CSV_FilePath);

            int skip = 0;
            if (_Config.CSV_SkipHeader) skip = 1;
            string[] file_data = File.ReadAllLines(_Config.CSV_FilePath).Skip(skip).Where(line=>line.Contains(_Config.CSV_Separator)).ToArray();
            Data = new CSV_Info[file_data.Length];

            int lines_counter = 0;
            foreach (string line in file_data)
            {
                CSV_Info lineDef = new CSV_Info(line, _Config.CSV_Separator);
                Data[lines_counter] = lineDef;
                lines_counter++;
            }
        }

        public UI_Creator Create()
        {
            UI_Creator helper = new UI_Creator();

            Ribbon ourRibbon_CFG = new Ribbon(_Config.RibbonName);
            helper._CFG.Ribbons.Add(ourRibbon_CFG);

            RibbonTabSource ourRibbon = new RibbonTabSource(_Config.RibbonName);
            Menu_Item ourRibbon_Menu = new Menu_Item();
            ourRibbon_Menu.SetData(_Config.RibbonName);
            if (_Config.Modes.Contains(CreationMode.WithClassicMenu)) helper._CFG.Menus.AddItem(ourRibbon_Menu);

            Toolbar_Item ourRibbon_Toolbar = new Toolbar_Item();
            ourRibbon_Toolbar.SetData(_Config.RibbonName);
            if (_Config.Modes.Contains(CreationMode.WithToolbars)) helper._CFG.Toolbars.AddItem(ourRibbon_Toolbar);

            //The temp collection Panel:Content
            Dictionary<string, List<CSV_Info>> panel2contents = new Dictionary<string, List<CSV_Info>>();
            foreach (var oneCommandInfo in Data)
            {
                List<CSV_Info> commands;
                if (panel2contents.TryGetValue(oneCommandInfo.Panel, out commands)) panel2contents[oneCommandInfo.Panel].Add(oneCommandInfo);
                else 
                {
                    commands = new List<CSV_Info>() { oneCommandInfo };
                    panel2contents.Add(oneCommandInfo.Panel, commands);
                }
            }

            foreach (var panel2content in panel2contents)
            {
                string panelName = panel2content.Key;
                RibbonPanelSource ourPanel = new RibbonPanelSource(panelName);
                Menu_Item ourPanel_Menu = new Menu_Item();
                ourPanel_Menu.SetData(panelName, ourRibbon_Menu);
                if (_Config.Modes.Contains(CreationMode.WithClassicMenu)) helper._CFG.Menus.AddItem(ourPanel_Menu);

                Toolbar_Item ourPanel_Toolbar = new Toolbar_Item();
                ourPanel_Toolbar.SetData(panelName);
                if (_Config.Modes.Contains(CreationMode.WithToolbars)) helper._CFG.Toolbars.AddItem(ourPanel_Toolbar);

                //Let's getting a buttons inside SplitButton (if exists)
                var SplitButtons = panel2content.Value.Where(a => a.SplitButtonName != "");
                Dictionary<string, List<CSV_Info>> SplitButton2Data = new Dictionary<string, List<CSV_Info>>();
                List<string> CommandNamesInSplit = new List<string>();
                if (SplitButtons.Any())
                {
                    foreach (var button in SplitButtons)
                    {
                        List<CSV_Info> commands;
                        if (SplitButton2Data.TryGetValue(button.SplitButtonName, out commands)) SplitButton2Data[button.SplitButtonName].Add(button);
                        else
                        {
                            commands = new List<CSV_Info>() { button };
                            SplitButton2Data.Add(button.SplitButtonName, commands);
                        }
                        CommandNamesInSplit.Add(button.CommandName);
                    }
                }

                /* There need an effectivence for placing buttons in panel's area: 
                 * LargeWithText и LargeWithoutText are placing in full-height of panel.
                 * MediumWithText и MediumWithoutText there are two icons can be placing in panel's height
                 * SmallWithText и SmallWithoutText there are three icons can be placing in panel's height.
                 * It's 
                 * It is advisable to run process the firstly for large, the next -- for medium, and in the end -- for small buttons
                 */
                ButtonStyleVariant[] LargeStyles = new ButtonStyleVariant[] { ButtonStyleVariant.LargeWithText, ButtonStyleVariant.LargeWithoutText };
                ButtonStyleVariant[] MediumStyles = new ButtonStyleVariant[] { ButtonStyleVariant.MediumWithText, ButtonStyleVariant.MediumWithoutText };
                ButtonStyleVariant[] SmallStyles = new ButtonStyleVariant[] { ButtonStyleVariant.SmallWithoutText, ButtonStyleVariant.SmallWithText };

                //The temp collection for useful commands (actually for Split's content)
                List<string> usedCommands = new List<string>();

                ButtonsProcessing(panel2content.Value.Where(b => LargeStyles.Contains(b.ButtonStyle)), 1);
                ButtonsProcessing(panel2content.Value.Where(b => MediumStyles.Contains(b.ButtonStyle)), 2);
                ButtonsProcessing(panel2content.Value.Where(b => SmallStyles.Contains(b.ButtonStyle)), 3);

                void ButtonsProcessing(IEnumerable<CSV_Info> buttons, int SizeValue)
                {
                    if (buttons.Any())
                    {
                        CSV_Info[] buttons_Arr = buttons.ToArray();
                        for (int c_counter = 0; c_counter < buttons_Arr.Count(); c_counter += SizeValue)
                        {
                            ItemOfPanel button_1 = null, button_2 = null, button_3 = null;
                            button_1 = CreateButtonDef(c_counter);
                            if (SizeValue >1) button_2 = CreateButtonDef(c_counter + 1);
                            if (SizeValue >2) button_3 = CreateButtonDef(c_counter + 2);

                            if (SizeValue == 1 && button_1 != null) ourPanel.AddItem(button_1);
                            else
                            {
                                RibbonRowPanel RowPanel = new RibbonRowPanel();

                                RibbonRow row_1 = new RibbonRow();
                                if (button_1 != null) 
                                {
                                    row_1.AddItem(button_1);
                                    RowPanel.AddRibbonRow(row_1);
                                }

                                RibbonRow row_2 = new RibbonRow();
                                if (button_2 != null)
                                {
                                    row_2.AddItem(button_2);
                                    RowPanel.AddRibbonRow(row_2);
                                }

                                if (SizeValue == 3)
                                {
                                    RibbonRow row_3 = new RibbonRow();
                                    if (button_3 != null)
                                    {
                                        row_3.AddItem(button_3);
                                        RowPanel.AddRibbonRow(row_3);
                                    }
                                }

                                ourPanel.AddItem(RowPanel);
                            }
                        }

                        ItemOfPanel CreateButtonDef (int index)
                        {
                            CSV_Info buttonDef;
                            if (index < buttons_Arr.Count()) buttonDef = buttons_Arr[index];
                            else return null;

                            //If that command was processed (as split's element)
                            if (usedCommands.Contains(buttonDef.CommandName)) return CreateButtonDef(index + 1);

                            ItemOfPanel createdItem = null;
                            if (CommandNamesInSplit.Contains(buttonDef.CommandName))
                            {
                                var needCommands = SplitButton2Data[buttonDef.SplitButtonName];
                                RibbonSplitButton splitButton = new RibbonSplitButton(buttonDef.SplitButtonName, buttonDef.ButtonStyle);
                                foreach (var needCommand in needCommands)
                                {
                                    RibbonCommandButton ButtonAtSplit = new RibbonCommandButton(needCommand.DisplayName, needCommand.ButtonStyle, needCommand.CommandName);
                                    usedCommands.Add(needCommand.CommandName);
                                    splitButton.AddRibbonCommandButton(ButtonAtSplit);

                                    ButtonProcessing(needCommand);
                                }

                                createdItem = splitButton;
                            }
                            else
                            {
                                RibbonCommandButton commonButton = new RibbonCommandButton(buttonDef.DisplayName, buttonDef.ButtonStyle, buttonDef.CommandName);

                                createdItem = commonButton;
                                usedCommands.Add(buttonDef.CommandName);

                                ButtonProcessing(buttonDef);
                            }
                            
                            return createdItem;
                        }
                    }
                }

                void ButtonProcessing(CSV_Info ButtonInfo)
                {
                    Configman_Command CFG_ButtonCommand = new Configman_Command(ButtonInfo.CommandName);
                    CFG_ButtonCommand.DispName = ButtonInfo.DisplayName;
                    CFG_ButtonCommand.StatusText = ButtonInfo.Description;
                    CFG_ButtonCommand.SetIcon(_Config.IconResVariant, _Config.IconFormatVariant, ButtonInfo.CommandName, _Config.IconsRefPath_or_DLL);

                    helper._CFG.Configman.Commands.AddCommand(CFG_ButtonCommand);

                    Menu_Item CFG_ButtonMenu = new Menu_Item();
                    CFG_ButtonMenu.SetData(ButtonInfo.DisplayName, ourPanel_Menu, ButtonInfo.CommandName);
                    if (_Config.Modes.Contains(CreationMode.WithClassicMenu)) helper._CFG.Menus.AddItem(CFG_ButtonMenu);

                    Toolbar_Item CFG_Button_Toolbar = new Toolbar_Item();
                    CFG_Button_Toolbar.SetData(ButtonInfo.DisplayName, ourPanel_Toolbar, ButtonInfo.CommandName);
                    if (_Config.Modes.Contains(CreationMode.WithToolbars)) helper._CFG.Toolbars.AddItem(CFG_Button_Toolbar);
                }

                helper._CUI._RibbonPanelSourceCollection.Add(ourPanel);
                ourRibbon.AddRibbonPanelSourceReference(ourPanel.Reference);

            }
            helper._CUI._RibbonTabSourceCollection.Add(ourRibbon);
            helper._CUI.SaveEdits();

            return helper;
        }
    }
}
