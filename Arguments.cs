using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineBase
{
    public class Arguments : IEnumerable<CommandLineArgument>
    {
        #region Internal Variables

        private List<CommandLineArgument> _args;

        #endregion

        #region Constructor

        public Arguments(string appName, string appDesc, params CommandLineArgument[] args)
        {
            _args = new List<CommandLineArgument>(args);
            CommandLineHelp.ApplicationTitle = appName;
            CommandLineHelp.Description = appDesc;
        }

        public string this[string s]
        {
            get { return _args.Where(x => x.Name == s).First().Value; }
        }

        public string this[int i]
        {
            get { return _args[i].Value; } 
        }

        #endregion

        public virtual string GetHelp()
        {
            return CommandLineHelp.ToString();
        }

        private CommandLineHelp _help;
        protected CommandLineHelp CommandLineHelp
        {
            get
            {
                if(_help == null)
                {
                    _help = new CommandLineHelp(_args);
                }
                return _help;
            }
        }


        #region IEnumerable<CommandLineArgument> Members

        public IEnumerator<CommandLineArgument> GetEnumerator()
        {
            foreach(CommandLineArgument arg in _args)
            {
                yield return arg;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach(CommandLineArgument arg in _args)
            {
                yield return arg;
            }
        }

        #endregion

        #region IEnumerable<CommandLineArgument> Members

        IEnumerator<CommandLineArgument> IEnumerable<CommandLineArgument>.GetEnumerator()
        {
            foreach(CommandLineArgument arg in _args)
            {
                yield return arg;
            }
        }

        #endregion
    }
}
