using System;
using JayaTestCases.Helpers;
using OpenQA.Selenium;

namespace JayaTestCases.TestCases
{
    public class SelectFlightPage: Helper
    {

        private readonly By anyDepartureFlight = By.XPath("//h1[text()='Selecciona tu vuelo de ida']/ancestor::air-calendar-cont/following-sibling::avail-list-pres//button[@class='select-cabin-button']");

        private readonly By anyReturnFlight = By.XPath("//h1[text()='Selecciona tu vuelo de regreso']/ancestor::air-calendar-cont/following-sibling::avail-list-pres//button[@class='select-cabin-button']");

        private readonly By continuarButton = By.Id("continue-btn-footer-static");

        public SelectFlightPage(IWebDriver driver) : base(driver)
        {

        }

        public void SelectDepartureFlightOnTheList()
        {
            WaitForElementUntilIsClickable(anyDepartureFlight, 40);

            Scroll(anyDepartureFlight);

            ClickElement(anyDepartureFlight);
        }

        public void SelectReturnFlightOnTheList()
        {
            WaitForElementUntilIsClickable(anyReturnFlight, 40);

            Scroll(anyReturnFlight);
            Scroll(anyReturnFlight);
            Scroll(anyReturnFlight);

            ClickElement(anyReturnFlight);
        }

        public void ClickContinueButton()
        {
            ClickElement(continuarButton);
        }

    }

    
}
