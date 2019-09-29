using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineBase
{
    public class CommandLineHelp
    {
        public string ApplicationTitle;
        public string Description;

        private List<CommandLineArgument> _args;

        public CommandLineHelp(List<CommandLineArgument> args)
        {
            _args = args;
        }

        public override string ToString()
        {
            StringBuilder helpText = new StringBuilder();
            helpText.AppendFormat("Help for {0}{1}{1}", ApplicationTitle, Environment.NewLine);
            helpText.AppendFormat("Description: {0} {1}", Description, Environment.NewLine);

            foreach(CommandLineArgument arg in _args)
            {
                helpText.AppendFormat("Argument {0} {1}", arg.Name, Environment.NewLine);
                helpText.AppendFormat(" Switch: {0} {1}", arg.Switch, Environment.NewLine);
                helpText.AppendFormat(" Usage: {0} {1}", arg.HelpText, Environment.NewLine);
            }
            return helpText.ToString();
        }

    }
}
