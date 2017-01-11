using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{

    public class AddUserEvalREQUEST
    {
        public int USER_ID { set; get; }
        public int FOOD_ID { set; get; }
        public float EVALUATION { set; get; }
    }

    public class UpdateFoodEvalREQUEST
    {
        public int FOOD_ID { set; get; }
        public float AVARAGE_POINT { set; get; }
        public float TOTAL_POINT { set; get; }
        public int TOTAL_USER { set; get; }
    }

    public class AddFoodEvalREQUEST
    {
        public int FOOD_ID { set; get; }
        public float AVARAGE_POINT { set; get; }
        public float TOTAL_POINT { set; get; }
        public int TOTAL_USER { set; get; }
    }

    public class AddUserCommentREQUEST
    {
        public int FOOD_ID { set; get; }
        public int USER_ID { set; get; }
        public string COMMENT { set; get; }
    }
}