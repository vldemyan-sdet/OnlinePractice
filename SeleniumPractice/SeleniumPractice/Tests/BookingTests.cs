using SeleniumPractice.Helpers;
using SeleniumPractice.models;
using SeleniumPractice.Pages;

namespace SeleniumPractice.Tests
{
    public class BookingTests : BaseClass
    {
        int defaultSearchResultsCountPerPage = 25;

        [TestCaseSource(nameof(SearchCriteriaData))]
        public void VerifyFiltering(SearchCriterion searchCriterion)
        {
            // Arrange
            var bookingPage = new BookingPage(_driver);
            bookingPage.Open();
            bookingPage.CloseRegisterPopup();
            bookingPage.FillCity(searchCriterion.City);
            bookingPage.FillDates(searchCriterion.StartDate, searchCriterion.EndDate);
            bookingPage.ClickSearch();
            bookingPage.FilterByDistanceToCenter(searchCriterion.Distance);

            // Assert
            var searchResultsCount = bookingPage.GetRoomsSearchResults().Count();
            Assert.That(searchResultsCount, Is.EqualTo(defaultSearchResultsCountPerPage));
        }

        static IEnumerable<SearchCriterion> SearchCriteriaData()
        {
            return DataProvider.GetSearchCriteraTestData("booking.csv");
        }
    }
}