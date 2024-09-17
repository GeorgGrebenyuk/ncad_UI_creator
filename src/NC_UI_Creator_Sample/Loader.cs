namespace NC_UI_Creator_Sample
{
    /// <summary>
    /// Допустим, это класс-загрузчик (LOADER) в отдельной DLL
    /// </summary>
    public class Loader : IExtensionApplication
    {
        public const string NC_COMMAND_1 = "NC_UI_Creator_Sample_Command1";
        public const string NC_COMMAND_2 = "NC_UI_Creator_Sample_Command2";
        public const string NC_COMMAND_3 = "NC_UI_Creator_Sample_Command3";
        public const string NC_COMMAND_4 = "NC_UI_Creator_Sample_Command4";
        public const string NC_COMMAND_5 = "NC_UI_Creator_Sample_Command5";
        public const string NC_COMMAND_6 = "NC_UI_Creator_Sample_Command6";

        [CommandMethod(NC_COMMAND_1)]
        public void CommandMethod1()
        {

        }

        [CommandMethod(NC_COMMAND_2)]
        public void CommandMethod2()
        {

        }

        [CommandMethod(NC_COMMAND_3)]
        public void CommandMethod3()
        {

        }

        [CommandMethod(NC_COMMAND_4)]
        public void CommandMethod4()
        {

        }

        [CommandMethod(NC_COMMAND_5)]
        public void CommandMethod5()
        {

        }

        [CommandMethod(NC_COMMAND_6)]
        public void CommandMethod6()
        {

        }

        public void Initialize()
        {
            
        }

        public void Terminate()
        {
            
        }
    }
}
