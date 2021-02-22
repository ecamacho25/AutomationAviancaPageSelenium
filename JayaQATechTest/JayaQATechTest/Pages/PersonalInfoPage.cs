using System;
using JayaTestCases.Helpers;
using OpenQA.Selenium;

namespace JayaTestCases.Pages
{
    public class PersonalInfoPage : Helper
    {

    

        public PersonalInfoPage(IWebDriver driver) : base(driver)
        {

        }

        private readonly By tabPersonalInfo = By.XPath("//div[@role='tablist']//div[@id='mat-tab-label-0-0']");

        private readonly By firstNameField = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@formcontrolname='firstName']");

        private readonly By lastNameField = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@formcontrolname='lastName']");

        private readonly By genderField = By.XPath("//mat-tab-group//mat-select[@formcontrolname='gender']");

        private readonly By countryField = By.XPath("//mat-tab-group//mat-select[@aria-label='Nacionalidad']");

        private readonly By dayField = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@placeholder='Día']");

        private readonly By monthField = By.XPath("//mat-tab-group//mat-select[@aria-label='Mes']");

        private readonly By yearField = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@placeholder='Año']");

        private readonly By buttonInfoContact = By.XPath("//button[text()='Información de Contacto']");
        
        private readonly By tabContacInfo = By.XPath("//div[@role='tablist']//div[@id='mat-tab-label-0-1']");

        private readonly By mailContactField = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@formcontrolname='email']");

        private readonly By phoneContactArea = By.XPath("//div[@class='mat-tab-body-wrapper']//input[@formcontrolname='number']");

        private readonly By buttonSaveInfo = By.XPath("//div[@class='mat-tab-body-wrapper']//button[text()='Guardar y continuar']");

        private readonly By titleAssert = By.XPath("//h1[@class='title' and text()='Datos personales']");

        
        public void ClickTabInfo()
        {
            ScrollToElement(tabPersonalInfo);

            ClickElement(tabPersonalInfo);
        }

        public void InputPersonalInfo(string firstName, string lastName, string gender, string country, string day, string month, string year)
        {
            ScrollToElement(buttonInfoContact);

            AddPersonName(firstName, lastName);

            SelectGender(gender);

            SelectCountry(country);

            AddBirthDay(day, month, year);
        }

        public void InputContactInfo(string email, string phone)
        {
            ScrollToElement(buttonSaveInfo);

            AddEmailInfo(email);

            AddPhone(phone);
        }

        public void AddPersonName(string firstName, string lastName)
        {
            WaitForElementUntilIsVisible(firstNameField);

            ClearFieldAndSentKeys(firstNameField, firstName);

            ClearFieldAndSentKeys(lastNameField, lastName);
        }

        public void SelectGender (string gender)
        {
            ClickElement(genderField);

            By optionToSelect = By.XPath($"//span[text()= ' {gender} ']");

            ClickElement(optionToSelect);
        }

        public void SelectCountry(string country)
        {
            ClickElement(countryField);

            By optionToSelect = By.XPath($"//span[text()= ' {country} ']");

            ClickElement(optionToSelect);
        }

        public void AddBirthDay(string day, string month, string year)
        {
            ClearFieldAndSentKeys(dayField, day);

            ClickElement(monthField);

            By monthToSelect = By.XPath($"//span[text()= ' {month} ']");

            ClickElement(monthToSelect);

            ClearFieldAndSentKeys(yearField, year);
        }

        public void ClickContacInfo()
        {
            ScrollToElement(tabContacInfo);

            ClickElement(tabContacInfo);
        }

        public void AddEmailInfo(string email)
        {
            ClearFieldAndSentKeys(mailContactField, email);
        }

        public void AddPhone(string phone)
        {
            ClearFieldAndSentKeys(phoneContactArea, phone);
        }

        public void ClickSaveInfo()
        {
            ScrollToElement(buttonSaveInfo);

            Scroll(buttonSaveInfo);
            Scroll(buttonSaveInfo);
            Scroll(buttonSaveInfo);

            ClickElement(buttonSaveInfo);
        }

        public void AssertTitleAfterSaveInfo()
        {
            WaitForElementUntilIsVisible(titleAssert);

            SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(titleAssert, "Datos personales");
        }

    }
}
