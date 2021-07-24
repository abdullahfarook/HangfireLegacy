using System;
using log4net;

namespace HangFireLegacy.Helpers
{
    internal static class Logger
    {
        private static ILog _defaultLogger = null;
        private static ILog _traceLogger = null;
        private static ILog _publishLogger = null;
        private static ILog _codeMetricsLog = null;
        internal static void InitiaLizeLogger()
        {
            GlobalContext.Properties["LogName"] = DateTime.Now.ToString("yyyyMMdd");
            log4net.Config.XmlConfigurator.Configure();
            _defaultLogger = LogManager.GetLogger("DefaultLogger");
            _traceLogger = LogManager.GetLogger("DefaultLogger");
            _publishLogger = LogManager.GetLogger("DefaultLogger");
            _codeMetricsLog = LogManager.GetLogger("DefaultLogger");
        }
        internal static void Info(string message)
        {
            _defaultLogger.Info(message);
        }
        internal static void Info(string message, LogTarget target = LogTarget.DEFAULT)
        {
            _defaultLogger.Info(message);
            //switch (target)
            //{
            //    case LogTarget.DEFAULT:
            //        _defaultLogger.Info(message);
            //        break;
            //    case LogTarget.PUBLISHER:
            //        _publishLogger.Info(message);
            //        break;
            //    case LogTarget.TRACE:
            //        _traceLogger.Info(message);
            //        break;
            //    case LogTarget.CODE_METRICS:
            //        _codeMetricsLog.Info(message);
            //        break;
            //    default:
            //        _defaultLogger.Info(message);
            //        break;
            //}
        }
        internal static void Error(string message, LogTarget target = LogTarget.DEFAULT)
        {
            _defaultLogger.Error(message);
            //switch (target)
            //{
            //    case LogTarget.DEFAULT:
            //        _defaultLogger.Error(message);
            //        break;
            //    case LogTarget.PUBLISHER:
            //        _publishLogger.Error(message);
            //        break;
            //    case LogTarget.TRACE:
            //        _traceLogger.Error(message);
            //        break;
            //    case LogTarget.CODE_METRICS:
            //        _codeMetricsLog.Error(message);
            //        break;
            //    default:
            //        _defaultLogger.Error(message);
            //        break;
            //}
        }
        internal static void Debug(string message, LogTarget target = LogTarget.DEFAULT)
        {
            _defaultLogger.Debug(message);
            //switch (target)
            //{
            //    case LogTarget.DEFAULT:
            //        _defaultLogger.Debug(message);
            //        break;
            //    case LogTarget.PUBLISHER:
            //        _publishLogger.Debug(message);
            //        break;
            //    case LogTarget.TRACE:
            //        _traceLogger.Debug(message);
            //        break;
            //    case LogTarget.CODE_METRICS:
            //        _codeMetricsLog.Debug(message);
            //        break;
            //    default:
            //        _defaultLogger.Debug(message);
            //        break;
            //}
        }
        internal static void Warn(string message, LogTarget target = LogTarget.DEFAULT)
        {
            _defaultLogger.Warn(message);
            //switch (target)
            //{
            //    case LogTarget.DEFAULT:
            //        _defaultLogger.Warn(message);
            //        break;
            //    case LogTarget.PUBLISHER:
            //        _publishLogger.Warn(message);
            //        break;
            //    case LogTarget.TRACE:
            //        _traceLogger.Warn(message);
            //        break;
            //    case LogTarget.CODE_METRICS:
            //        _codeMetricsLog.Warn(message);
            //        break;
            //    default:
            //        _defaultLogger.Warn(message);
            //        break;
            //}
        }
    }
    internal enum LogTarget
    {
        DEFAULT,
        TRACE,
        PUBLISHER,
        CODE_METRICS
    }
}
