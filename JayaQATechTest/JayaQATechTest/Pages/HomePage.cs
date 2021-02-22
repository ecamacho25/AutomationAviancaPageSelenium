using System;
using JayaTestCases.Helpers;
using OpenQA.Selenium;

namespace JayaTestCases.Pages
{
    public class HomePage : Helper
    {
        private readonly string urlHomePage = "https://www.avianca.com/co/es/";

        private readonly By footerHomePage = By.XPath("//div[@class='footer-cont container']");

        private readonly By coockiesButton = By.Name("cookies-confirm");

        private readonly By reservaTuVueloLink = By.Id("reservatuvuelo");

        private readonly By vueloIdaYVueltaLink = By.XPath("//a[@role='presentation' and contains(@aria-controls, 'ida_regreso')]");

        private readonly By desdeTextBox = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@data-name='pbOrigen']");

        private readonly By haciaTextBox = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@data-name='pbDestino']");

        private readonly By fechaIdaTextBox = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@name='pbFechaIda']");

        private readonly By fechaRegresoTextBox = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@name='pbFechaRegreso']");

        private readonly By pasajeroTextBox = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@name='pbPasajeros']");

        private readonly By claseEconoLink = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//input[@name='clase' and @class='btt1']/parent::label");

        private readonly By plusAdultControl = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//div[@class='controls adults']//div[@class='plus control']");

        private readonly By adultQuantity = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//div[@class='controls adults']//div[@class='value']");

        private readonly By cerrarControlButton = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//div[@class='controls adults']//div[@class='value']");

        private readonly By buscarVuelosButton = By.XPath("//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//button[@title='Buscar vuelos']");

        private readonly By continuarWarningModal = By.XPath("//div[@id='modal-warning']//button[@class='btn primary continue pull-right']");

        private readonly By hamburgerButton = By.XPath("//div[@class='icon-menu']");

        private readonly By linkHorariosVuelo = By.XPath("//div[@class='container-links-menu-desktop visible-lg visible-md']//a[@href='/co/es/tu-reserva/consulta-itinerarios/']");
        

        public HomePage(IWebDriver driver) : base(driver)
        {

        }


        public void OpenHomePage()
        {
            OpenPage(urlHomePage);

            if (IsElementVisible(coockiesButton))
            {
                ClickElement(coockiesButton);
            }

        }
        
        public bool IsHomePageLoaded()
        {
            return IsElementVisible(footerHomePage);
        }
        
        public void ClickReservaTuVueloLink()
        {
            ClickElement(reservaTuVueloLink);

            WaitForElementUntilIsVisible(vueloIdaYVueltaLink);
        }

        public void ClickIdaYVueltaLink()
        {
            ClickElement(vueloIdaYVueltaLink);

            WaitForElementUntilIsVisible(desdeTextBox);
        }

        public void AddFromCity (string cityName, string cityCode)
        {
            ClearFieldAndSentKeys(desdeTextBox, cityName);

            var cityDropdownElement = (By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//div[@class='bs-list-countries']" +
                $"/ul/li[@class='item' and @data-city='{cityCode}']"));

            ClickElement(cityDropdownElement);

            WaitForElementUntilIsVisible(By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//span[@class='text airport-text' and contains(text(), '{cityCode}')]"));
        }

        public void AddToCity(string cityName, string cityCode)
        {
            ClearFieldAndSentKeys(haciaTextBox, cityName);

            var cityDropdownElement = (By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//div[@class='bs-list-countries']" +
                $"/ul/li[@class='item' and @data-city='{cityCode}']"));

            ClickElement(cityDropdownElement);

            WaitForElementUntilIsVisible(By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//span[@class='text airport-text' and contains(text(), '{cityCode}')]"));
        }

        public void SelectDepartureDate()
        {
            var tomorrowDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            By todayOnCalendar = By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//td[@class='cal1']//td[@data-date='{tomorrowDate}']");

            ClickElement(fechaIdaTextBox);

            ClickElement(todayOnCalendar);

        }

        public void SelectReturnDate()
        {
            var nextMonth = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");

            By NextMonthOnCalendar = By.XPath($"//div[@role='tabpanel'and contains(@id, 'ida_regreso')]//td[@class='cal2']//td[@data-date='{nextMonth}']");

            ClickElement(fechaRegresoTextBox);

            ClickElement(NextMonthOnCalendar);
        }

        public void AddPassengerToEconomicClass()
        {
            ClickElement(pasajeroTextBox);

            ClickElement(claseEconoLink);

            if (GetElementText(adultQuantity) != "1")
            {
                ClickElement(plusAdultControl);
            }
            
            ClickElement(cerrarControlButton);

        }

        public void ClickSearchFlightButton()
        {
            ClickElement(buscarVuelosButton);
        }

        public void CloseWarningModal()
        {
            ClickElement(continuarWarningModal);
        }

        public void ClickAndOpenMenu()
        {
            ClickElement(hamburgerButton);
        }

        public void ClicklinkHorariosVuelo()
        {
            ClickElement(linkHorariosVuelo);
        }


    }
}
