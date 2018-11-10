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
            Console.WriteLine("Hello World!");
            var NotRegisteredAddress = "";
            var RegisteredAddress = "";
            IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            // Open the website.
            driver.Url = "https://awesomefiber.com/awesome-fiber-address-search/";

            IWebElement houseNumberElement = driver.FindElement(By.Id("chkpt-lookup-house-number"));
            houseNumberElement.SendKeys("1");
            IWebElement zipCodeElement = driver.FindElement(By.Id("chkpt-lookup-zip-code"));
            zipCodeElement.SendKeys("1");
            IWebElement lookUpButton = driver.FindElement(By.ClassName("uk-button"));
            lookUpButton.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement addressSelectList = driver.FindElement(By.ClassName("uk-select"));

            if (addressSelectList != null)
            {
                SelectElement oSelect = new SelectElement(driver.FindElement(By.ClassName("uk-select")));
                
                for (int i = 0; i < oSelect.Options.Count; i++)
                {
                    oSelect.SelectByIndex(i);
                    String sValue = oSelect.SelectedOption.Text;
                    Console.Write(sValue);
                    //document.getElementById("chkpt-address-confirm") != null ? true : false;
                    var NextButtonExist = driver.FindElement(By.Id("chkpt-address-confirm"));
                    if (NextButtonExist != null)
                    {
                        NotRegisteredAddress += sValue + ", ";
                    } else
                    {
                        RegisteredAddress += sValue + ", ";
                    }
                    // Console.Write(driver.FindElement(By.ClassName("uk-select")).Text);
                    //Console.Write();
                }
                Console.Write("Not Registered Addresses: ");
                Console.Write(NotRegisteredAddress);
                Console.Write("/n");
                Console.Write("Registered Addresses");
                Console.Write(RegisteredAddress);
                Console.Write("/n");
            }

            


            // Close the website
            // driver.Close();
        }
    }
}
