using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class Food
    {
        public int ID { set; get; }
        public string NAME { set; get; }
        public string ADDRESS { set; get; }
        public string AVATAR { set; get; }
        public DateTime CREATED_DATE { set; get; }
    }
}