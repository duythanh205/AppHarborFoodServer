using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class FoodEvaluation
    {
        public int ID { set; get; }
        public int FOOD_ID { set; get; }
        public float AVARAGE_POINT { set; get; }
        public float TOTAL_POINT { set; get; }
        public int TOTAL_USER { set; get; }
    }
}