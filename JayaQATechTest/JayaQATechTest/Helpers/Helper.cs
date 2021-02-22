using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.IO;

namespace JayaTestCases.Helpers
{
    public class Helper
    {
        private readonly IWebDriver _driver;

        public Helper(IWebDriver driver)
        {
            _driver = driver;

        }

        protected bool IsElementVisible(By locator)
        {
            var isVisible = false;
            try
            {
                isVisible = WaitForElementUntilIsVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                isVisible = false;
            }
            catch (Exception e)
            {
                isVisible = false;
            }
            return isVisible;
        }

        protected IWebElement WaitForElementUntilIsVisible(By locator, int seconds=10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        protected IWebElement WaitForElementUntilIsClickable(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        protected void WaitSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        protected void ScrollToElement(By locator)
        {
            var element = _driver.FindElement(locator);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        protected void Scroll(By locator)
        {
            _driver.FindElement(locator).SendKeys(Keys.ArrowDown);
        }

        protected void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);

            _driver.Manage().Window.Maximize();
        }

        protected void ClickElement(By locator)
        {
            WaitForElementUntilIsVisible(locator);

            ScrollToElement(locator);

            _driver.FindElement(locator).Click();
        }

        protected void ClearFieldAndSentKeys (By locator, string text)
        {
            WaitForElementUntilIsVisible(locator);

            _driver.FindElement(locator).Click();

            _driver.FindElement(locator).SendKeys(Keys.Delete);

            _driver.FindElement(locator).SendKeys(text);

        }

        protected string GetElementText (By locator)
        {
            string value = _driver.FindElement(locator).Text;

            return value;
        }

        protected void SwitchToNewWindow(string title)
        {
            var newWindowHandle = _driver.WindowHandles[1];

            _driver.SwitchTo().Window(newWindowHandle);

            SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(title);
        }

        protected void Test_ScreenShotRemoteBrowser()
        {
            String dir = AppDomain.CurrentDomain.BaseDirectory;

            FileInfo fileInfo = new FileInfo(dir);

            System.IO.DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;

            string parentDirName = currentDir.FullName;

            string now = DateTime.Now.ToString("yyyyMMddhhmmss");

            Screenshot image = ((ITakesScreenshot)_driver).GetScreenshot();

            image.SaveAsFile(parentDirName + "\\screenshots\\" + $"screenshot{now}.png", ScreenshotImageFormat.Png); 
        }
    }
}
