using SeleniumPractice.Pages;

namespace SeleniumPractice.Tests
{
    public class SolarTests : BaseClass
    {

        [Test]
        public void VerifyFiltering()
        {
            // Arrange
            var solarPage = new SolarPage(_driver);
            solarPage.Open();
            solarPage.OpenSolarPanels();
            solarPage.OpenFilters();

            // Act
            var firstProductTextBefore = solarPage.GetFirstProductTitleText();
            solarPage.CheckBrand("JA Solar");
            var firstProductTextAfter = solarPage.GetFirstProductTitleText();

            // Assert
            Assert.That(firstProductTextAfter, Is.Not.EqualTo(firstProductTextBefore));
        }


    }
}