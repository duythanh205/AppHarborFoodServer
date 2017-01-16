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
        public List<UserCommentRESPONSE> userComments { set; get; }
        public ResStatusCode Code { set; get; }
    }

    public class UserCommentRESPONSE
    {
        public int ID { set; get; }
        public int FOOD_ID { set; get; }
        public int USER_ID { set; get; }
        public string COMMENT { set; get; }
        public string USER_NAME { set; get; }
        public string USER_AVATAR { set; get; }
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

    public class AddUserFavoriteFoodRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public UserFavoriteFood userFavoriteFood { set; get; }
    }

    public class GetUserFavoriteRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public UserFavoriteFood userFavoriteFood { set; get; }
    }

    public class DeleteUserFavoriteFoodRESPONSE
    {
        public ResStatusCode Code { set; get; }
    }

    public class AddUserRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public User user { set; get; }
    }

    public class GetAllUserFavoriteRESPONSE
    {
        public ResStatusCode Code { set; get; }
        public List<UserFavoriteResponseBE> Data { set; get; }
    }

    public class UserFavoriteResponseBE
    {
        public int USER_FAVORITE_FOOD_ID { set; get; }
        public int USER_ID { set; get; }
        public int FOOD_ID { set; get; }
        public string FAVORITE_FOOD_DESCRIPTION { set; get; }

        public string FOOD_NAME { set; get; }
        public string FOOD_ADDRESS { set; get; }
        public string FOOD_AVATAR { set; get; }
        public DateTime FOOD_CREATED_DATE { set; get; }
        public string FOOD_PHONE { set; get; }
        public string FOOD_FACEBOOK { set; get; }
        public string FOOD_PRICE { set; get; }
    }

}