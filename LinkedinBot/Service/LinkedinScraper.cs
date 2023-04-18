using LinkedinBot.DTO;
using LinkedinBot.Models;
using NuGet.Versioning;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Xml.Linq;

namespace LinkedinBot.Service
{
    public class LinkedinScraper : ILinkedinScraper
    {
        private readonly IConfiguration configuration;

        public LinkedinScraper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void LetsDoItHardWork(RequestParams requestParams)
        {
            var options = new ChromeOptions() { AcceptInsecureCertificates = true };
            options.AddArgument("--profile-directory=Default");
            //options.AddArgument("--profile-directory=Default");

            using IWebDriver driver = new ChromeDriver(chromeDriverDirectory: "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", options);

            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            //login
            driver.FindElement(By.Id("session_key")).SendKeys(configuration?.GetSection("LinkedinProfile")["Email"]);
            driver.FindElement(By.Id("session_password")).SendKeys(configuration?.GetSection("LinkedinProfile")["Password"]);
            driver.FindElement(By.LinkText("Entrar")).Click();
            Thread.Sleep(5000);

            driver.Navigate().GoToUrl(requestParams.LinkToSearchRecruiters);
            Thread.Sleep(5000);

            Console.Clear();

            var results = driver.FindElements(By.ClassName("reusable-search__result-container"));
            foreach (var result in results)
            {
                var name = result.FindElement(By.ClassName("entity-result__title-text"))
                    .FindElement(By.CssSelector("span > a > span > span:nth-child(1)"))
                    .Text.Trim();
                Console.WriteLine(name);

                var country = result.FindElement(By.ClassName("entity-result__secondary-subtitle")).Text.Trim();
                var description = result.FindElement(By.ClassName("entity-result__primary-subtitle")).Text.Trim();

                var recruiter = new Recruiter()
                {
                    Name = name,
                    ConectedProfile = false,
                    Country = country,
                    Description = description,
                    FirstMessageSended = false,
                    IsPrivateProfile = false
                };
                //TODO Save this recruiter on database
            }
        }
    }
}
