using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class FoodDiscount
    {
        public int ID { set; get; }
        public int FOOD_ID { set; get; }
        public int DISCOUNT_PERCENT { set; get; }
        public DateTime START_DATE { set; get; }
        public DateTime END_DATE { set; get; }
        public string DISCOUNT_DESCRIPTION { set; get; }

        public FoodDiscount() { }
        public FoodDiscount(FoodDiscount foodDiscount)
        {
            this.DISCOUNT_DESCRIPTION = foodDiscount.DISCOUNT_DESCRIPTION;
            this.DISCOUNT_PERCENT = foodDiscount.DISCOUNT_PERCENT;
            this.END_DATE = foodDiscount.END_DATE;
            this.FOOD_ID = foodDiscount.FOOD_ID;
            this.ID = foodDiscount.ID;
            this.START_DATE = foodDiscount.START_DATE;

        }
    }
}