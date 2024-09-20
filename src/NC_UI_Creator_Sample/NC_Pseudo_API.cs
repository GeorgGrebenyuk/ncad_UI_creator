using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Sample
{
    /// <summary>
    /// Псевдо-атрибут для маркировки Teigha.Runtime.CommandMethod
    /// </summary>
    public class CommandMethod : Attribute
    {
        public string CommandName { get; set; }
        public CommandMethod(string commandName)
        {
            this.CommandName = commandName;
        }
    }

    /// <summary>
    /// Псевдо-интерфейс для Teigha.Runtime.IExtensionApplication
    /// </summary>
    public interface IExtensionApplication
    {
        void Initialize();
        void Terminate();
    }
}
