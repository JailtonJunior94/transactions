using System.Runtime.InteropServices;

namespace Transactions.Core.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetBrazilianTime(this DateTime dateTime)
        {
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(isLinux ? "America/Sao_Paulo" : "E. South America Standard Time");

            return TimeZoneInfo.ConvertTime(dateTime, tzi);
        }

        public static DateTime DateUTC(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);
        }
    }
}
