using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using OpenQA.Selenium;

namespace PageInteraction
{
    public class WebSite
    {
        IWebDriver driver;
        public WebSite(IWebDriver driver)
        {
            this.driver = driver;
        }

        public DealDTO[] ReadPageData()
        {
            var container = driver.FindElement(By.ClassName("ag-body-container"));

            var rows = container.FindElements(By.ClassName("ag-row"));

            DealDTO[] deals = new DealDTO[rows.Count-2];

            for (int i = 0; i < deals.Length; i++)
            {
                var dealInfo = rows[i].FindElements(By.ClassName("ag-cell"));

                string declaration = dealInfo[0].Text;
                string seller = dealInfo[1].Text;
                string sellerInn = dealInfo[2].Text;
                string buyer = dealInfo[3].Text;
                string buyerInn = dealInfo[4].Text;
                DateTime dealDate = DateTime.Parse(dealInfo[5].Text);
                string volume = dealInfo[6].Text;

                deals[i] = new DealDTO(declaration, seller, sellerInn, buyer, buyerInn, dealDate, volume);
            }

            return deals;
        }
        public void NextPageClick()
        {
            var button = driver.FindElement(By.ClassName("x-tbar-page-next"));

            button.Click();
        }
    }
}
