using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuySpecsProject.Models
{
    public class OrderModel
    {
        public int ORDER_ID { get; set; }
        public Nullable<int> SPECS_ID { get; set; }
        public string SPECS_NAME { get; set; }
        public string FRAME_TYPE { get; set; }
        public Nullable<double> LEFT_EYEPOWER { get; set; }
        public Nullable<double> RIGHT_EYEPOWER { get; set; }
        public Nullable<double> SPECS_PRICE { get; set; }
        public string EMAILID { get; set; }
    }
}