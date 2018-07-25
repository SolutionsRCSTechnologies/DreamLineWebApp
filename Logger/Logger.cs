using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.Diagnostics;

namespace Logger
{
    public class Logger
    {
        private static readonly ILog mlog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static Logger log = null;
        private Logger()
        {
        }        
        private void WriteLog(LoggerType logType, string logMessage, string methodName)
        {
            if (!string.IsNullOrEmpty(logMessage))
            {
                string msg = BuildMessage(logType, logMessage, methodName);
                log4net.Config.XmlConfigurator.Configure();
                switch (logType)
                {
                    case LoggerType.DEBUG:
                        mlog.Debug(msg);
                        break;
                    case LoggerType.INFO:
                        mlog.Info(msg);
                        break;
                    case LoggerType.FATAL:
                        mlog.Fatal(msg);
                        break;
                    case LoggerType.WARN:
                        mlog.Warn(msg);
                        break;
                    case LoggerType.ERROR:
                        mlog.Error(msg);
                        break;
                    default:
                        mlog.Debug(msg);
                        break;
                }
            }
        }

        private string BuildMessage(LoggerType logType, string message, string methodName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(DateTime.Now);
            builder.Append(" | " + logType.ToString());
            builder.Append(" | " + Process.GetCurrentProcess().MachineName);
            builder.Append(" | " + Environment.UserName);
            builder.Append(" | " + Process.GetCurrentProcess().Id);
            builder.Append(" | " + methodName);
            builder.Append(" | " + message);
            builder.Append(Environment.NewLine);
            return builder.ToString();
        }

        public static Logger GetInstance()
        {
            if (log == null)
            {
                log = new Logger();
            }
            return log;
        }

        public void Info(string message, string methodName)
        {
            WriteLog(LoggerType.INFO, message, methodName);
        }
        public void Debug(string message, string methodName)
        {
            WriteLog(LoggerType.DEBUG, message, methodName);
        }
        public void Fatal(string message, string methodName)
        {
            WriteLog(LoggerType.FATAL, message, methodName);
        }
        public void Warn(string message, string methodName)
        {
            WriteLog(LoggerType.WARN, message, methodName);
        }
        public void Error(string message, string methodName)
        {
            WriteLog(LoggerType.ERROR, message, methodName);
        }
    }

    public enum LoggerType
    {
        FATAL,
        WARN,
        DEBUG,
        ERROR,
        INFO
    }
}
