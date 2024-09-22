# ncad_UI_creator

Вспомогательная библиотека для создания UI-описания команд (cfg + cuix) для nanoCAD .NET API. Адаптировано для `net45`, `net6.0`,

# Использование

1. Создается отдельное приложение (UI_LIB), к ней линкуется NC_UI_Creator_Lib.dll;
2. В UI_LIB используя классы из NC_UI_Creator_Lib.dll создается описание меню, в качестве имен команд используя данные из CommandMethod загружаемой библиотеки классов;
3. UI_LIB компилируется и запускается, создавая файлы интерфейса (CFG + CUIX) в заданном каталоге. Далее можно настроить их авто-копирование в bin-папку плагина;
4. Предполагается, что при плагине имеется \*.package файл, где будет вписан целевой CFG

## Ручное описание интерфейса

[Пример использования см. в файле](src/NC_UI_Creator_Sample/UI_Creator_Sample.cs)

Последовательность действий для создания простого ленточного меню:

1. Создать объект класса `UI_Creator`;

```csharp
UI_Creator ui_helper = new UI_Creator();
```

2. Создать объект класса `RibbonTabSource`: описание ленты (имя);

```csharp
RibbonTabSource myTab = new RibbonTabSource("Sample ribbon");
```

3. Создать объект класса `RibbonPanelSource`: описание панели на ленте;   

```csharp
RibbonPanelSource myPanel1 = new RibbonPanelSource("Panel 1");
```

4. Создать определения кнопок - одиночных `RibbonCommandButton` или с выпадающим списком кнопок `RibbonSplitButton`;

```csharp
RibbonCommandButton myButton1 = new RibbonCommandButton("Button1", ButtonStyleVariant.LargeWithText, "NC_COMMAND_1");
```

5. Добавить кнопки на панель `RibbonPanelSource.AddItem()`;

```csharp
myPanel1.AddItem(myButton1);
```

6. Добавить ссылку на панель к ленте `RibbonTabSource.AddRibbonPanelSourceReference()`;

```csharp
myTab.AddRibbonPanelSourceReference(myPanel1.Reference);
```

7. В определение CUI файла в UI_Creator добавить панель и ленту:

```csharp
ui_helper._CUI._RibbonPanelSourceCollection.Add(myPanel1);
ui_helper._CUI._RibbonTabSourceCollection.Add(myTab);
```

8. Сохраним изменения и сформируем CUIX

```csharp
ui_helper._CUI.SaveEdits();
ui_helper.SaveCUIX();
```

9. Инициализируем CFG-файл (информация по командам), добавим ссылку на ленту:

```csharp
Ribbon myRibbon_CFG = new Ribbon("Sample ribbon");
ui_helper._CFG.Ribbons.Add(myRibbon_CFG);
```

10. Сформируем CFG-описание для команды, имеющией иконку в виде локального BMP-файла и добавим описание команды в файл

```csharp
Configman_Command myButton1_atPanel1_CFG = new Configman_Command(myButton1.MenuMacroID);
myButton1_atPanel1_CFG.LocalName = myButton1.Id;
myButton1_atPanel1_CFG.DispName = myButton1.Text;
myButton1_atPanel1_CFG.StatusText = "Выводит окно 1";
myButton1_atPanel1_CFG.SetIcon(IconResourceVariant.LocalFile, IconVariant.BMP, "PseudoIcon_32", "Icons");
ui_helper._CFG.Configman.Commands.AddCommand(myButton1_atPanel1_CFG);
```

11. Сохраним CFG

```csharp
ui_helper.SaveCFG();
```

## Полуавтоматическая генерация интерфейса

Автоматизированная генерация UI может быть настроена для случая описания интерфейса в CSV-файле, см. функциональность класса `UI_Creator_FromCSV`. 

Предполагается, что исходный файл содержит следующие данные:

| Command Name                         | Display Name             | Description                                                        | Panel                                            | ButtonStyle                                                                         | SplitButtonName                                                                              |
| ------------------------------------ | ------------------------ | ------------------------------------------------------------------ | ------------------------------------------------ | ----------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------- |
| Наименование команды (CommandMethod) | Отображаемое имя команды | Описание команды (всплывающий текст при наведении на элемент меню) | Наименование панели, где будет размещена команда | Размер кнопки и наличие текста, значения <br/>NC_UI_Creator_Lib. ButtonStyleVariant | Название кнопки с выпадающими командами. Если это одиночная команда, то просто пустая строка |
| NCAD_TEST_1                          | Тестовая команда 1       | Выводит в командную строку фразу "Hello, ncad!"                    | Общее                                            | LargeWithText                                                                       |                                                                                              |

Конструктору класса UI_Creator_FromCSV надо передать абсолютный файловый путь до файла, символ разделителя строки и флаг, пропускать ли первую (заголовочную) строку файла.

Помимо этого, можно указать следующие свойства перед началом генерации:

- `Modes`: Список режимов генерации данных (по умолчанию создается ленточное меню), можно добавить формирование классического меню и панелей инструментов:

```csharp
CreationMode.WithClassicMenu //classic menu
CreationMode.WithToolbars //toolbars
```

- `IconResVariant`: формат хранения иконок -- локальные файлы или ресурсная DLL;

- `IconsRefPath_or_DLL`: наименование папки с иконками либо название ресурсной DLL с расширением (какой задан `IconResVariant`);

- `IconFormatVariant`: расширение файлов иконок (разрешенные BMP или ICO);

- `RibbonName`: наименование ленты. По умолчанию = имени файла CSV без расширения;

# Возможности

* создание ленточного меню (ленты, панели, кнопки, кнопки с выпадающими значениями, ряды кнопок);
* связывание элементов меню с командами (cfg);
* создание классического меню (cfg);
* создание панелей инструментов и управление их закреплением (cfg);