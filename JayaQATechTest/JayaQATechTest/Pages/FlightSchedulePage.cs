using System;
using JayaTestCases.Helpers;
using OpenQA.Selenium;

namespace JayaTestCases.Pages
{
    public class FlightSchedulePage : Helper
    {
        private readonly By origenTextbox = By.Id("origenIter");

        private readonly By destinoTextbox = By.Id("destinoIter");

        private readonly By fechaIdaTextBox = By.Id("fechaIdaIter");

        private readonly By fechaVueltaTextBox = By.Id("fechaRegresoIter");

        private readonly By consultarButton = By.Id("mainContent_Ir");

        public FlightSchedulePage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsFlightSchedulePageIsLoaded()
        {
            WaitForElementUntilIsVisible(consultarButton);

            return IsElementVisible(consultarButton);
        }

        public void InputFlightCities(string fromCity, string fromCityCode, string toCity, string toCityCode)
        {
            ScrollToElement(origenTextbox);

            AddFromCity(fromCity, fromCityCode);

            AddToCity(toCity, toCityCode);
        }

        public void AddFromCity(string cityName, string cityCode)
        {
            ClearFieldAndSentKeys(origenTextbox, cityName);

            var cityDropdownElement = (By.XPath($"//div[@class='bs-list-countries']/ul/li[@class='item' and @data-city='{cityCode}']"));

            ClickElement(cityDropdownElement);

            WaitForElementUntilIsVisible(By.XPath($"//span[@class='text' and contains(text(), '{cityCode}')]"));
        }

        public void AddToCity(string cityName, string cityCode)
        {
            ClearFieldAndSentKeys(destinoTextbox, cityName);

            var cityDropdownElement = (By.XPath($"//div[@class='bs-list-countries']/ul/li[@class='item' and @data-city='{cityCode}']"));

            ClickElement(cityDropdownElement);

            WaitForElementUntilIsVisible(By.XPath($"//span[@class='text' and contains(text(), '{cityCode}')]"));
        }

        public void SelectDepartDate()
        {
            var tomorrowDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            By tomorrowOnCalendar = By.XPath($"//div[@data-name='fechaIdaIter']//td[@class='cal1']//td[@data-date='{tomorrowDate}']");

            ScrollToElement(fechaIdaTextBox);

            ClickElement(fechaIdaTextBox);

            ClickElement(tomorrowOnCalendar);

        }

        public void SelectReturnDate()
        {
            var tomorrowDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            By tomorrowOnCalendar = By.XPath($"//div[@data-name='fechaRegresoIter']//td[@class='cal1']//td[@data-date='{tomorrowDate}']");

            ScrollToElement(fechaVueltaTextBox);

            ClickElement(fechaVueltaTextBox);

            ClickElement(tomorrowOnCalendar);
        }

        public void ClickSearchScheduleButton()
        {
            ClickElement(consultarButton);

            WaitSeconds(7);
        }


    }
}
