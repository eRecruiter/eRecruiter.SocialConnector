using System;
using System.Globalization;

namespace eRecruiter.SocialConnector.Xing
{
    public static class XingDateParser
    {
        public static Date Parse(string dateString)
        {
            if (dateString == null)
            {
                return null;
            }

            try
            {
                var date = DateTime.ParseExact(dateString, new[] {"yyyy-MM", "yyyy-M", "yyyy", "yy"}, CultureInfo.InvariantCulture, DateTimeStyles.None);
                return new Date
                {
                    Month = dateString.Contains("-") ? (int?) date.Month : null,
                    Year = date.Year
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
