using SeleniumPractice.models;
using SeleniumPractice.Pages;
using System.Reflection;

namespace SeleniumPractice.Tests
{
    public class BookingTests : BaseClass
    {
        int defaultSearchResultsCountPerPage = 25;

        [Test]
        public void VerifyFiltering()
        {
            var AssemblyDirectory = TestContext.CurrentContext.TestDirectory;
            var csvPath = Path.Combine(AssemblyDirectory, "data", "booking.csv");

            List<SearchCriterion> searchCriteria = new();

            using (var reader = new StreamReader(csvPath))
            {
                var wasFirstLineRead = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (! wasFirstLineRead)
                    {
                        wasFirstLineRead = true;
                        continue;
                    }
                    

                    var values = line.Split(',');
                    var searchCriterion = new SearchCriterion()
                    {
                        City = values[0],
                        StartDate = values[1],
                        EndDate = values[2],
                    };

                    searchCriteria.Add(searchCriterion);
                }
            }

            // Arrange
            var bookingPage = new BookingPage(_driver);
            bookingPage.Open();
            bookingPage.CloseRegisterPopup();
            bookingPage.FillCity(searchCriteria.First().City);
            bookingPage.FillDates(searchCriteria.First().StartDate, searchCriteria.First().EndDate);
            bookingPage.ClickSearch();

            // Assert
            var searchResultsCount = bookingPage.GetRoomsSearchResults().Count();
            Assert.That(searchResultsCount, Is.EqualTo(defaultSearchResultsCountPerPage));
        }


    }
}