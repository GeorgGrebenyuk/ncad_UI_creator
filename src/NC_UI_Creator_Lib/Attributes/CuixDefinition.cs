using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.Attributes
{
    /// <summary>
    /// Атрибут для указания имени ленты и пути для сохранения. Можно применить к классу
    /// </summary>
    public class CuixDefinition : Attribute
    {
        /// <summary>
        /// Наименование ленты
        /// </summary>
        public string RibbonName { get; set; } = "";

        /// <summary>
        /// Относительный файловый путь для сохранения CFG & CUIX файлов, сгенерированных приложением (как правило, в папку репозитория, для хранения вместе с кодом)
        /// </summary>
        public string RelativeSavePath { get; set; } = "";
    }
}
