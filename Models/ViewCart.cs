using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySpecsProject.Models
{
    public class ViewCart
    {
        public int SPECS_ID { get; set; }
        public string SPECS_NAME { get; set; }
        public int QUANTITY { get; set; }
        public Nullable<double> SPECS_PRICE { get; set; }
    }
}