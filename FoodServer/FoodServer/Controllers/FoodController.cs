using FoodServer.Models;
using FoodServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodServer.Controllers
{
    public class FoodController : ApiController
    {
        FoodService foodService = new FoodService();
        /// <summary>
        /// Lấy các món ăn mới nhất
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetNewFood")]
        [HttpGet]
        public HttpResponseMessage GetNewFood()
        {
            try
            {
                var result = foodService.GetNewFood();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy các món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetFoodDiscount")]
        [HttpGet]
        public HttpResponseMessage GetFoodDiscount()
        {
            try
            {
                var result = foodService.GetFoodDiscount();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy đánh giá của món ăn
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetFoodEvalution/{FoodID}")]
        [HttpGet]
        public HttpResponseMessage GetFoodEvaluation(int FoodID)
        {
            try
            {
                var result = foodService.GetFoodEvaluation(FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.FoodEvaluation));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetFoodDisCount/{FoodID}")]
        [HttpGet]
        public HttpResponseMessage GetFoodDisCountByID(int FoodID)
        {
            try
            {
                var result = foodService.GetFoodDiscountByID(FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes.ToList().FirstOrDefault()));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetFood/{FoodID}")]
        [HttpGet]
        public HttpResponseMessage GetFoodByID(int FoodID)
        {
            try
            {
                var result = foodService.GetFoodByID(FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes.ToList().FirstOrDefault()));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy thông tin USER
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetUser/{UserID}")]
        [HttpGet]
        public HttpResponseMessage GetUserByID(int UserID)
        {
            try
            {
                if (UserID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetUserByID(UserID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.user));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy thông tin đánh giá của user
        /// Api/Food/v1/GetUserEvaluation?UserID=1&FoodID=2
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetUserEvaluation")]
        [HttpGet]
        public HttpResponseMessage GetUserEvaluation(int UserID, int FoodID)
        {
            try
            {
                if(UserID < 0 || FoodID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetUserEval(UserID, FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userEval));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy comment của user
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetUserComment/{FoodID}")]
        [HttpGet]
        public HttpResponseMessage GetUserComment(int FoodID)
        {
            try
            {
                if (FoodID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetUserComment(FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userComments));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/UpdateEval")]
        [HttpPut]
        public HttpResponseMessage UpdateEval([FromBody] UpdateEvalREQUEST req)
        {
            try
            {
                if (req.EvalID < 0 || req.Point < 0 || req.Point > 10)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.UpdateEval(req.EvalID, req.Point);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userEval));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/AddUserEval")]
        [HttpPost]
        public HttpResponseMessage AddUserEval([FromBody] AddUserEvalREQUEST req)
        {
            try
            {
                if (req.FOOD_ID < 0 || req.EVALUATION < 0 || req.EVALUATION > 10)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.AddUserEval(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userEval));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/UpdateFoodEval")]
        [HttpPut]
        public HttpResponseMessage UpdateEval([FromBody] UpdateFoodEvalREQUEST req)
        {
            try
            {
                if (req.FOOD_ID < 0 || req.AVARAGE_POINT < 0 || req.AVARAGE_POINT > 10)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.UpdateFoodEval(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.foodEval));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/AddFoodEval")]
        [HttpPost]
        public HttpResponseMessage AddFoodEval([FromBody] AddFoodEvalREQUEST req)
        {
            try
            {
                if (req.FOOD_ID < 0 || req.AVARAGE_POINT < 0 || req.AVARAGE_POINT > 10)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.AddFoodEval(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.foodEval));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/AddUserCmt")]
        [HttpPost]
        public HttpResponseMessage AddUserComment([FromBody] AddUserCommentREQUEST req)
        {
            try
            {
                if (req.FOOD_ID < 0 || req.USER_ID < 0 || string.IsNullOrEmpty(req.COMMENT))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.AddUserComment(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userComment));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/AddUserFavoriteFood")]
        [HttpPost]
        public HttpResponseMessage AddUserFavoriteFood([FromBody] AddUserFavoriteREQUEST req)
        {
            try
            {
                if (req.FOOD_ID < 0 || req.USER_ID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.AddUserFavoriteFood(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userFavoriteFood));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy thông tin đánh giá của user
        /// Api/Food/v1/GetUserFavoriteByID?UserID=1&FoodID=2
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetUserFavoriteByID")]
        [HttpGet]
        public HttpResponseMessage GetUserFavoriteByID(int UserID, int FoodID)
        {
            try
            {
                if (UserID < 0 || FoodID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetUserFavoriteByID(UserID, FoodID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.userFavoriteFood));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Delete 1 cart theo id
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/DeleteUserFoodFavorite/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteUserFoodFavorite([FromUri]int id)
        {
            try
            {
                if (id < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest));
                }

                var result = foodService.DeleteUserFoodFavorite(id);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, null));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy thông tin USER
        /// Api/Food/v1/GetUser?token=dasdasy
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetUser")]
        [HttpGet]
        public HttpResponseMessage GetUserByToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetUserByToken(token);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.user));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Update Điểm đánh giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/AddUser")]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] AddUserREQUEST req)
        {
            try
            {
                if (string.IsNullOrEmpty(req.NAME) || string.IsNullOrEmpty(req.TOKEN) || string.IsNullOrEmpty(req.TYPE))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.AddUser(req);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.user));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy comment của user
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v1/GetAllUserFavorite/{UserID}")]
        [HttpGet]
        public HttpResponseMessage GetAllUserFavorite(int UserID)
        {
            try
            {
                if (UserID < 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.BadRequest, null));
                }

                var result = foodService.GetAllUserFavoriteByID(UserID);
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.Data));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }


        //------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Lấy các món ăn mới nhất
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v2/GetNewFood")]
        [HttpGet]
        public HttpResponseMessage GetNewFoodVer2()
        {
            try
            {
                var result = foodService.GetNewFoodVer2();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Lấy các món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        [Route("Api/Food/v2/GetFoodDiscount")]
        [HttpGet]
        public HttpResponseMessage GetFoodDiscountVer2()
        {
            try
            {
                var result = foodService.GetFoodDiscountVer2();
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(result.Code, result.ListFoodRes));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK, ResponseDataFactory.getInstace(ResStatusCode.InternalServerError));
            }
        }
    }
}
