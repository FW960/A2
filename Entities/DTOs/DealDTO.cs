using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DealDTO
    {
        public string declaration { get; set; }
        public string seller { get; set; }
        public string sellerInn { get; set; }
        public string buyer { get; set; }
        public string buyerInn { get; set; }
        public DateTime dealDate { get; set; }
        public string volume { get; set; }

        public DealDTO(string declaration, string seller, string sellerInn, string buyer, string buyerInn, DateTime dealDate, string volume)
        {
            this.declaration = declaration;
            this.seller = seller;
            this.sellerInn = sellerInn;
            this.buyer = buyer;
            this.buyerInn = buyerInn;
            this.dealDate = dealDate;
            this.volume = volume;
        }
    }
}
