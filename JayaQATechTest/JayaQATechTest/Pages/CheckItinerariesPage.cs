using JayaTestCases.Helpers;
using OpenQA.Selenium;

namespace JayaTestCases.Pages
{
    public class CheckItinerariesPage : Helper
    {
        private readonly By elementToFocus = By.Id("pdfLink");

        private readonly By ordernarPorSalida  = By.Id("mainContent_GrillaItinerariosIda_GridVuelos_LinkSortHoraSale_0");

        public CheckItinerariesPage(IWebDriver driver) : base(driver)
        {

        }

        public void SwitchToWindowCheckItinerariesAndAssertTitle(string title)
        {
            SwitchToNewWindow(title);
        }

        public void OrderByDepartTime()
        {
            ScrollToElement(elementToFocus);

            ClickElement(ordernarPorSalida);

            WaitSeconds(5);
        }

        public void TakeScreenshot()
        {
            Test_ScreenShotRemoteBrowser();
        }

    }
}
