using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.ThreadSafeUsingDoubkeCheckedLock.Start
{
    public class MemoryLogger
    {
        private int _InfoCount;
        private int _WarningCount;
        private int _ErrorCount;


        private static MemoryLogger _instance = null;
        private static readonly object _lock = new object();


        private List<LogMessage> _logs = new List<LogMessage>();
        public IReadOnlyCollection<LogMessage> Logs => _logs;

        
        private MemoryLogger(){ } 

        public static MemoryLogger GetLogger
        {
            get
            {
                if(_instance == null)
                {

                    lock(_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MemoryLogger();
                        }
                        
                     }
                }
                return _instance;
            }
        }

    
    
        public void Log(string message, LogType logType)
        {
            _logs.Add(new LogMessage
            {
                LogType = logType,
                Message = message,
                CreatedAt = DateTime.Now,
            });
        }


        public void LogInfo(string message) 
        {
            ++_InfoCount;
            Log(message , LogType.INFO);    
        }
        public void LogWarning(string message)
        {
            ++_WarningCount;
            Log(message, LogType.WARNING);
        }
        public void LogError(string message)
        {
            ++_ErrorCount;
            Log(message, LogType.ERROR);
        }
        public void ShowLog()
        {
            _logs.ForEach(a => Console.WriteLine(a));
            Console.WriteLine($"-------------------------------");
            Console.WriteLine($"Info ({_InfoCount}), Warning ({_WarningCount}), Error ({_ErrorCount})");
        }
    }
}
