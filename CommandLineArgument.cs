using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineBase
{
    public class CommandLineArgument<T> 
    {
        private bool _set = false;

        public string Name;
        public string Switch;
        public string HelpText;
        public bool Required;

        private T _value;
        public T Value
        {
            get { if (!_set) return Default; else return _value; }
            private set { _set = true; _value = value; }
        }

        public Func<bool> Validator
        {
            get
            {
                return delegate()
                {
                    return true;
                };
            }

        }

        public string Message;
        public T Default = default(T);

        public void Load(string[] args)
        {
            if (Switch.StartsWith("@arg"))
            {
                var argIndex = Convert.ToInt16(Switch.Substring(4));

                if (args.Length <= argIndex) Value = Default;
                else Value = (T)Convert.ChangeType(args[argIndex], typeof(T));
                return;
            }

            bool isValue = false;
            foreach (string arg in args)
            {
                if (isValue)
                {
                    Value = (T)Convert.ChangeType(arg, typeof(T));
                    break;
                }
                if (arg == Switch)
                {
                    isValue = true;
                    continue;
                }
            }
        }
    }

    public class CommandLineArgument 
    {        
        private bool _set = false;

        public string Name;
        public string Switch;
        public string HelpText;
        public bool Required;

        private string _value;
        public string Value
        {
            get { if(!_set) return Default; else return _value; }
            private set { _set = true; _value = value; }
        }

        public Func<bool> Validator
        {
            get
            {
                return delegate()
                {
                    if(Required && string.IsNullOrEmpty(Value))
                    {
                        return false;
                    }

                    return true;
                };
            }

        }

        public string Message;
        public string Default = string.Empty;

        public void Load(string[] args)
        {
            if(Switch.StartsWith("@arg"))
            {
                var argIndex = Convert.ToInt16(Switch.Substring(4));

                if (args.Length <= argIndex) Value = Default;
                else Value = args[argIndex];
                return;
            }

            bool isValue = false;
            foreach(string arg in args)
            {
                if(isValue)
                {
                    Value = arg;
                    break;
                }
                if(arg == Switch)
                {
                    isValue = true;
                    continue;
                }
            }
        }
    }
}
