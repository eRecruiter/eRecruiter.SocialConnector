using System;

namespace eRecruiter.SocialConnector
{
    /// <summary>
    /// Represents an instant in time, typically expressed as a date.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Gets the day of the month represented by this instance.
        /// </summary>
        /// <returns>The day component, expressed as a value between 1 and 31.</returns>
        public int? Day { get; set; }

        /// <summary>
        /// Gets the month component of the date represented by this instance.
        /// </summary>
        /// <returns>The month component, expressed as a value between 1 and 12.</returns>
        public int? Month { get; set; }

        /// <summary>
        /// Gets the year component of the date represented by this instance.
        /// </summary>
        /// <returns>The year, between 1 and 9999.</returns>
        public int? Year { get; set; }

        /// <summary>
        /// Converts the date to a <see cref="System.DateTime"/> object, if the <see cref="Day"/>, <see cref="Month"/> and <see cref="Year"/> property are have values, and returns it.
        /// </summary>
        /// <returns>An instance of <see cref="DateTime"/> with the values of day, month and year or null if no <see cref="DateTime"/> object could be instantiated.</returns>
        public DateTime? GetDateIfPossible()
        {
            if (Day.HasValue && Month.HasValue & Year.HasValue)
                try
                {
                    return new DateTime(Year.Value, Month.Value, Day.Value);
                }
                catch (ArgumentOutOfRangeException)
                {
                    //if day, month or year values are out of range, no possible date can be created, so return null
                    return null;
                }
            return null;
        }

        /// <summary>
        /// Converts the date to a string if <see cref="Month"/> and <see cref="Year"/> have values.
        /// </summary>
        /// <returns>A string in format "{<see cref="Month"/>}-{<see cref="Year"/>}" if the properties are set, else null.</returns>
        public string GetMonthYearIfPossible()
        {
            if (Month.HasValue & Year.HasValue)
                return Month.Value + "-" + Year.Value;
            return null;
        }
    }
}
