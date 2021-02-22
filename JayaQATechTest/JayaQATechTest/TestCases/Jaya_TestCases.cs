using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Runtime;
using FluentAssertions;
using JayaTestCases.Pages;



namespace JayaTestCases.TestCases
{
    [TestFixture]
    public class Jaya_TestCases 
    {

        private readonly IWebDriver _driver;

        private readonly HomePage _homePage;

        private readonly SelectFlightPage _selectFlightPage;

        private readonly PersonalInfoPage _personalInfoPage;

        private readonly FlightSchedulePage _flightSchedulePage;

        private readonly CheckItinerariesPage _checkItinerariesPage;

        public Jaya_TestCases()
        {

            _driver = new ChromeDriver();

            _homePage = new HomePage(_driver);

            _selectFlightPage = new SelectFlightPage(_driver);

            _personalInfoPage = new PersonalInfoPage(_driver);

            _flightSchedulePage = new FlightSchedulePage(_driver);

            _checkItinerariesPage = new CheckItinerariesPage(_driver);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _homePage.OpenHomePage();

            _homePage.IsHomePageLoaded().Should().BeTrue();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void BookingFlight_FlightIsBookedSuccessfully()
        {
            SearchFlight("Bogota", "BOG", "Miami", "MIA");

            SelectFlights();

            InputPassengerInfo(lastName:"John", firstName:"Smith", gender:"Masculino", country:"Colombia", day:"2", month:"Enero", year:"1988", email:"mail@test.co", phone:"1234567");

        }

        [Test]
        public void SearchFlightAndOrderByDepartTime_FlightAreOrdered()
        {
            _homePage.ClickAndOpenMenu();

            _homePage.ClicklinkHorariosVuelo();

            _flightSchedulePage.IsFlightSchedulePageIsLoaded().Should().BeTrue();

            _flightSchedulePage.InputFlightCities("Bogota", "BOG", "Cartagena", "CTG");

            _flightSchedulePage.SelectDepartDate();

            _flightSchedulePage.SelectReturnDate();

            _flightSchedulePage.ClickSearchScheduleButton();

            _checkItinerariesPage.SwitchToWindowCheckItinerariesAndAssertTitle("Itinerario de vuelos | Avianca");

            _checkItinerariesPage.OrderByDepartTime();
        }

        #region Private Methods

        private void SearchFlight(string fromCity, string codeFromCity, string toCity, string codeFromeCity)
        {
            _homePage.ClickReservaTuVueloLink();

            _homePage.ClickIdaYVueltaLink();

            _homePage.AddFromCity(fromCity, codeFromCity);

            _homePage.AddToCity(toCity, codeFromeCity);

            _homePage.SelectDepartureDate();

            _homePage.SelectReturnDate();

            _homePage.AddPassengerToEconomicClass();

            _homePage.ClickSearchFlightButton();

            _homePage.CloseWarningModal();
        }

        private void SelectFlights()
        {
            _selectFlightPage.SelectDepartureFlightOnTheList();

            _selectFlightPage.ClickContinueButton();

            _selectFlightPage.SelectReturnFlightOnTheList();

            _selectFlightPage.ClickContinueButton();
        }

        private void InputPassengerInfo(string firstName, string lastName, string gender, string country, string day, string month, string year, string email, string phone )
        {
            _personalInfoPage.ClickTabInfo();

            _personalInfoPage.InputPersonalInfo(firstName, lastName, gender, country, day, month, year);

            _personalInfoPage.ClickContacInfo();

            _personalInfoPage.InputContactInfo(email, phone);

            _personalInfoPage.ClickSaveInfo();

            _personalInfoPage.AssertTitleAfterSaveInfo();
        }

        #endregion

    }
}
