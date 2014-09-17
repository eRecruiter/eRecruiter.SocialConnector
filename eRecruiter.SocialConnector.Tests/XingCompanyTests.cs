using eRecruiter.SocialConnector.Xing.Entities;
using NUnit.Framework;

namespace eRecruiter.SocialConnector.Tests
{
    [TestFixture]
    public class XingCompanyTests
    {
        [TestCase("2014", 2014)]
        [TestCase("1914", 1914)]
        [TestCase("2055", 2055)]
        [TestCase("05", 2005)]
        [TestCase("95", 1995)]
        public void Can_parse_year_only_end_date(string dateString, int expectedParsedYear)
        {
            var company = new XingCompany {EndDateString = dateString};

            Assert.Null(company.EndDate.Day);
            Assert.Null(company.EndDate.Month);
            Assert.NotNull(company.EndDate.Year);
            Assert.AreEqual(company.EndDate.Year, expectedParsedYear);
        }

        [TestCase("2014-02", 2014, 2)]
        [TestCase("2000-12", 2000, 12)]
        [TestCase("1914-11", 1914, 11)]
        [TestCase("1914-1", 1914, 1)]
        [TestCase("1900-2", 1900, 2)]
        [TestCase("1900-09", 1900, 9)]
        [TestCase("2045-3", 2045, 3)]
        public void Can_parse_year_and_month_end_date(string dateString, int expectedParsedYear, int expectedParsedMonth)
        {
            var company = new XingCompany {EndDateString = dateString};

            Assert.Null(company.EndDate.Day);
            Assert.NotNull(company.EndDate.Month);
            Assert.NotNull(company.EndDate.Year);
            Assert.AreEqual(company.EndDate.Year, expectedParsedYear);
            Assert.AreEqual(company.EndDate.Month, expectedParsedMonth);
        }

        [TestCase("2014", 2014)]
        [TestCase("1914", 1914)]
        [TestCase("2055", 2055)]
        [TestCase("05", 2005)]
        [TestCase("95", 1995)]
        public void Can_parse_year_only_begin_date(string dateString, int expectedParsedYear)
        {
            var company = new XingCompany {BeginDateString = dateString};

            Assert.Null(company.StartDate.Day);
            Assert.Null(company.StartDate.Month);
            Assert.NotNull(company.StartDate.Year);
            Assert.AreEqual(company.StartDate.Year, expectedParsedYear);
        }

        [TestCase("2014-02", 2014, 2)]
        [TestCase("2000-12", 2000, 12)]
        [TestCase("1914-11", 1914, 11)]
        [TestCase("1914-1", 1914, 1)]
        [TestCase("1900-2", 1900, 2)]
        [TestCase("1900-09", 1900, 9)]
        [TestCase("2045-3", 2045, 3)]
        public void Can_parse_year_and_month_begin_date(string dateString, int expectedParsedYear, int expectedParsedMonth)
        {
            var company = new XingCompany {BeginDateString = dateString};

            Assert.Null(company.StartDate.Day);
            Assert.NotNull(company.StartDate.Month);
            Assert.NotNull(company.StartDate.Year);
            Assert.AreEqual(company.StartDate.Year, expectedParsedYear);
            Assert.AreEqual(company.StartDate.Month, expectedParsedMonth);
        }

        [TestCase("20155")]
        [TestCase("2")]
        [TestCase("2-2-2")]
        [TestCase("01-2014")]
        public void Can_not_parse_wrong_formatted_date(string dateString)
        {
            var company = new XingCompany {BeginDateString = dateString};

            Assert.Null(company.StartDate);
        }
    }
}