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

    public class AddUserFavoriteREQUEST
    {
        public int USER_ID { set; get; }
        public int FOOD_ID { set; get; }
        public string FAVORITE_FOOD_DESCRIPTION { set; get; }
    }

    public class UpdateEvalREQUEST
    {
        public int EvalID { set; get; }
        public float Point { set; get; }
    }

    public class AddUserREQUEST
    {
        public string NAME { set; get; }
        public string AVATAR { set; get; }
        public string TYPE { set; get; }
        public string TOKEN { set; get; }
    }
}