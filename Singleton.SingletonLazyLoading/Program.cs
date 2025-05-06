using Singleton.SingletonLazyLoading.Start;

namespace Singleton.SingletonLazyLoading
{
    internal class Program
    {
        static MemoryLogger _logger;
        static void Main(string[] args)
        {
            AssignVoucher("EslamHassan@Gmail.com", "ABC123");

            UseVoucher("ABC123");

            _logger.ShowLog();

            Console.ReadKey();
        }
        static void AssignVoucher(string email, string voucher)
        {
            _logger = MemoryLogger.GetLogger;
            // Logic here
            _logger.LogInfo($"Voucher '{voucher}' assigned");

            // another logic
            _logger.LogError($"unable to send email '{email}'");
        }
        static void UseVoucher(string voucher)
        {
            _logger = MemoryLogger.GetLogger;
            // Logic here
            _logger.LogWarning($"3 attempts made to validate the voucher");

            // Logic here
            _logger.LogInfo($"'{voucher}' is used");
        }
    }
}
