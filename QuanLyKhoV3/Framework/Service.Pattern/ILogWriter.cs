using System;

namespace Service.Pattern
{
    public interface ILogWriter
    {
        void WriteLog(DateTime logTime, string message);
        void WriteLog(DateTime logTime, string message, params object[] parameter);
    }
}