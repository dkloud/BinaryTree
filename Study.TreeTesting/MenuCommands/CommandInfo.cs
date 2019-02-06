using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.TreeTesting.MenuCommands
{
    public delegate void Command();

    public class CommandInfo
    {
        public string name;
        public Command command;

        public CommandInfo(string name, Command command)
        {
            this.name = name;
            this.command = command;
        }
    };
}
