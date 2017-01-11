using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{

    public class FoodRESPONSE
    {
        public Food Food { set; get; }
        public FoodDiscount FoodDiscount { set; get; }

        public FoodRESPONSE()
        {
            Food = new Food();
            FoodDiscount = new FoodDiscount();
        }
    }

    public class GetFoodRESPONSE
    {
        public List<FoodRESPONSE> ListFoodRes { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class FoodEvalutionRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public FoodEvaluation FoodEvaluation { set; get; }
    }

    public class GetUserRESPONSE
    {
        public User user { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class GetUserEvalRESPONSE
    {
        public UserEvaluation userEval { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class GetUserComment
    {
        public List<UserComment> userComments { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class UpdateEvalRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public UserEvaluation userEval { set; get; }
    }

    public class AddUserEvalRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public UserEvaluation userEval { set; get; }
    }

    public class AddFoodEvalRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public FoodEvaluation foodEval { set; get; }
    }

    public class AddUserCommentRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public UserComment userComment { set; get; }
    }

    public class UpdateFoodEvalRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public FoodEvaluation foodEval { set; get; }
    }
}