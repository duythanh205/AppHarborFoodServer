using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class UserComment
    {
        public int ID { set; get; }
        public int FOOD_ID { set; get; }
        public int USER_ID { set; get; }
        public string COMMENT { set; get; }
    }
}