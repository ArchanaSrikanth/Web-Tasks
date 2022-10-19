using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Selenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-extensions");
            options.AddArgument("--safebrowsing-disable-download-protection");
            options.AddArguments("no-sandbox");
            options.AddArgument("enable-automation");
            options.AddArgument("test-type=browser");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing", "enabled");
            options.AddUserProfilePreference("disable-popup-blocking", false);
            options.AddArguments("disable-infobars");


            options.AddArgument("--headless");

            var driver = new ChromeDriver(
                Directory.GetCurrentDirectory(),
                options,
                TimeSpan.FromSeconds(30));

            



            Console.WriteLine("Starting Test");
            driver.Navigate().GoToUrl("https://emsisoft.com/en/anti-malware-home");
            IWebElement element = driver.FindElement(By.XPath("//a[@href = 'https://help.emsisoft.com/en/1597/download-installation/']"));
                element.Click();
            
            IWebElement downloadelement = driver.FindElement(By.XPath("//a[@href = 'https://dl.emsisoft.com/EmsisoftAntiMalwareWebSetup.exe']"));
            downloadelement.Click();






            Assert.IsTrue(File.Exists(@"C :/Downloads/EmsisoftAntiMalwareWebSetup"));

            Console.WriteLine("Ending Test");








        }


    }
    }

