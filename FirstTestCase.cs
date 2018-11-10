using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IFCDATA
{
    class FirstTestCase
    {
        static void Main(string[] args)
        {
            int[] AddressCollections = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Hello World!");
            var NotRegisteredAddress = "";
            var RegisteredAddress = "";
            IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            // Open the website.
            driver.Url = "https://awesomefiber.com/awesome-fiber-address-search/";
            for( int j = 1; j <= AddressCollections.Length; j++)
            {
                IWebElement houseNumberElement = driver.FindElement(By.Id("chkpt-lookup-house-number"));
                houseNumberElement.Clear();
                houseNumberElement.SendKeys(j.ToString());
                IWebElement zipCodeElement = driver.FindElement(By.Id("chkpt-lookup-zip-code"));
                zipCodeElement.Clear();
                zipCodeElement.SendKeys("0");
                IWebElement lookUpButton = driver.FindElement(By.ClassName("uk-button"));
                lookUpButton.Click();

                System.Threading.Thread.Sleep(5000);
                bool FoundAddressSelectList = false;
                // IWebElement addressSelectList = driver.FindElement(By.ClassName("uk-select"));
                try
                {
                    driver.FindElement(By.ClassName("uk-select"));
                    FoundAddressSelectList = true;
                }
                catch (NoSuchElementException)
                {
                    FoundAddressSelectList = false;
                }

                if (FoundAddressSelectList != false)
                {
                    bool foundRecord = false;
                    SelectElement oSelect = new SelectElement(driver.FindElement(By.ClassName("uk-select")));

                    for (int i = 0; i < oSelect.Options.Count; i++)
                    {
                        oSelect.SelectByIndex(i);
                        String sValue = oSelect.SelectedOption.Text;
                        Console.Write(sValue);
                        try
                        {
                            driver.FindElement(By.Id("chkpt-address-confirm"));
                            foundRecord = true;
                        }
                        catch (NoSuchElementException)
                        {
                            foundRecord = false;
                        }

                        if (foundRecord == true)
                        {
                            NotRegisteredAddress += sValue + ", ";
                        }
                        else
                        {
                            RegisteredAddress += sValue + ", ";
                        }
                    }
                    Console.Write("Not Registered Addresses: ");
                    Console.Write(NotRegisteredAddress);
                    Console.Write("\n");
                    Console.Write("Registered Addresses");
                    Console.Write(RegisteredAddress);
                    Console.Write("\n");
                }
            }
            // Close the website
            // driver.Close();
        }
    }
}
