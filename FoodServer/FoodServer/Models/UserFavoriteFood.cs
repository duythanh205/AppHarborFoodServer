using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class UserFavoriteFood
    {
        public int ID { set; get; }
        public int USER_ID { set; get; }
        public int FOOD_ID { set; get; }
        public string FAVORITE_FOOD_DESCRIPTION { set; get; }
    }
}