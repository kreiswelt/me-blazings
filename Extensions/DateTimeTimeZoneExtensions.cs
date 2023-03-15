using Microsoft.Graph.Models;
using System.Globalization;

namespace me_blazings.Extensions
{
    public static class DateTimeTimeZoneExtensions
    {
        public static DateTime? ToDateTime(this DateTimeTimeZone dateTimeTimeZone)
        {
            if (string.IsNullOrWhiteSpace(dateTimeTimeZone.DateTime))
            {
                return null;
            }

            // 2023-03-01T23:33:12.0000000
            DateTime dateTime = DateTime.ParseExact(dateTimeTimeZone.DateTime, "yyyy-MM-ddTHH:mm:ss.fffffff", CultureInfo.InvariantCulture);
            DateTimeKind kind = DateTimeKind.Unspecified;

            if (!string.IsNullOrWhiteSpace(dateTimeTimeZone.TimeZone))
            {
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(dateTimeTimeZone.TimeZone);

                if (timeZoneInfo.Id == TimeZoneInfo.Utc.Id)
                {
                    kind = DateTimeKind.Utc;
                }
                else if (timeZoneInfo.Id == TimeZoneInfo.Local.Id)
                {
                    kind = DateTimeKind.Local;
                }
            }

            return (DateTime.SpecifyKind(dateTime, kind));
        }
    }
}
