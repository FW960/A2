using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Entities;
using System.Threading;
using PageInteraction;
using Repo;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.lesegais.ru/open-area/deal");

            Thread.Sleep(6000); // Время для того чтобы страница успела подгрузится.

            WebSite website = new WebSite(driver);

            Run(website);
        }
        static void Run(WebSite website)
        {
            bool started = true;

            DbRepository repo = new DbRepository();

            while (true)
            {
                if (started == true)
                {
                    started = false;
                }
                else
                {
                    Thread.Sleep(600000);
                }

                DealDTO[] deals = website.ReadPageData();

                website.NextPageClick();

                for (int i = 0; i < deals.Length; i++)
                {
                    repo.Create(deals[i]);
                }

            }

        }
    }
}
