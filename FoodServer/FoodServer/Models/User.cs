using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class User
    {
        public int ID { set; get; }
        public string NAME { set; get; }
        public string AVATAR { set; get; }
        public string TYPE { set; get; }
        public string TOKEN { set; get; }
    }
}