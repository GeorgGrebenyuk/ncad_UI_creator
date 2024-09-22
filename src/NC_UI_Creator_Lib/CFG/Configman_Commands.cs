using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC_UI_Creator_Lib.CFG
{
    /// <summary>
    /// The collection of congigman's commands
    /// </summary>
    public class Configman_Commands : CFG_Base
    {
        internal Configman_Commands()
        {
            CFG_SetBlockName(@"\configman\commands");
            Commands = new List<Configman_Command>();
        }

        public List<Configman_Command> Commands { get; private set; }
        public void AddCommand(Configman_Command Configman_CommandsDef)
        {
            if (!Commands.Where(c=>c.intername == Configman_CommandsDef.intername).Any()) Commands.Add(Configman_CommandsDef);
        }

        public override string Content
        {
            get
            {
                foreach (var command in Commands)
                {
                    CFG_AddContent(command.Content);
                }
                return p_Content;
            }
        }

    }
}
