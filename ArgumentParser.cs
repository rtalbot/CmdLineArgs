using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineBase
{
    public static class ArgumentParser
    {
        public static Arguments Parse(Arguments def, string[] args)
        {
            foreach(CommandLineArgument arg in def)
            {
                try
                {
                    arg.Load(args);

                    if(!arg.Validator())
                        throw new Exception(arg.Message);                    
                }
                catch(Exception ex)
                {
                    throw new ArgumentException(
                            string.Format("Error:{1}{0}{1}{1}{2}{1}",
                            arg.Message,
                            Environment.NewLine,
                            def.GetHelp()), ex);
                }
            }
            return def;
        }
    }
}
