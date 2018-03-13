using System;
using System.Collections.Generic;
using MathSequence.Web.Interfaces;
using log4net;
using Newtonsoft.Json;

namespace MathSequence.Web
{
    public class LogWrapper : ILogWrapper
    {
        private readonly ILog _log;

        public LogWrapper(Type type)
        {
            _log = LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (_log.IsInfoEnabled)
            {
                _log.InfoFormat(format, GetLogFriendlyArgs(args));
            }
        }

        public void Error(string message)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (_log.IsErrorEnabled)
            {
                _log.ErrorFormat(format, GetLogFriendlyArgs(args));
            }
        }

        /// <summary>
        /// Converts class types to json strings
        /// </summary>
        private static object[] GetLogFriendlyArgs(object[] args)
        {
            var logFriendlyArgs = new List<object>();
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == null)
                    {
                        logFriendlyArgs.Add("null");
                    }
                    else if (BuiltinType(args[i]))
                    {
                        logFriendlyArgs.Add(args[i]);
                    }
                    else
                    {
                        logFriendlyArgs.Add(JsonConvert.SerializeObject(args[i]));
                    }
                }
            }
            return logFriendlyArgs.ToArray();
        }

        private static bool BuiltinType(object item)
        {
            if (item == null)
            {
                return false;
            }

            var ns = item.GetType().Namespace;
            return ns != null && ns.StartsWith("System");
        }
    }
}