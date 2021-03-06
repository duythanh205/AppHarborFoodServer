﻿using FoodServer.DAO;
using FoodServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.Service
{
    public class FoodService
    {
        FoodDAO foodDAO = new FoodDAO();

        /// <summary>
        /// Lấy tất cả món ăn mới nhất trong 5 ngày
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSE GetNewFood()
        {
            try
            {
                var ListFood = foodDAO.GetNewFood<List<Food>>();
                if (ListFood != null && ListFood.Count > 0)
                {
                    var ListDiscount = foodDAO.GetListDisCountFromFood<List<FoodDiscount>>(ListFood);
                    List<FoodRESPONSE> res = new List<FoodRESPONSE>();
                    ListFood.ForEach(f =>
                    {
                        var discount = ListDiscount.FirstOrDefault(w => w.FOOD_ID == f.ID);
                        res.Add(new FoodRESPONSE()
                        {
                            Food = f,
                            FoodDiscount = discount
                        });
                    });

                    return new GetFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = res
                    };
                }

                return new GetFoodRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = new List<FoodRESPONSE>()
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSE GetFoodDiscount()
        {
            try
            {
                var ListDiscount = foodDAO.GetAllDiscount<List<FoodDiscount>>();
                if (ListDiscount != null && ListDiscount.Count > 0)
                {
                    var ListFood = foodDAO.GetListFoodFromDiscount<List<Food>>(ListDiscount);
                    List<FoodRESPONSE> res = new List<FoodRESPONSE>();
                    ListFood.ForEach(f =>
                    {
                        var discount = ListDiscount.FirstOrDefault(w => w.FOOD_ID == f.ID);
                        res.Add(new FoodRESPONSE()
                        {
                            Food = f,
                            FoodDiscount = discount
                        });
                    });

                    return new GetFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = res
                    };
                }

                return new GetFoodRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        public FoodEvalutionRESPONSE GetFoodEvaluation(int FoodID)
        {
            try
            {
                var foodEvaluation = foodDAO.GetFoodEvaluation<FoodEvaluation>(FoodID);
                return new FoodEvalutionRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    FoodEvaluation = foodEvaluation
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSE GetFoodDiscountByID(int FoodID)
        {
            try
            {
                var FoodDiscount = foodDAO.GetDiscountByID<FoodDiscount>(FoodID);
                if (FoodDiscount != null)
                {
                    var ListFood = foodDAO.GetListFoodFromDiscount<List<Food>>(new List<FoodDiscount>() { new FoodDiscount(FoodDiscount) });

                    return new GetFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = new List<FoodRESPONSE>()
                        {
                            new FoodRESPONSE()
                            {
                                Food = ListFood.ToList().FirstOrDefault(),
                                FoodDiscount = FoodDiscount,
                            }
                        }
                    };
                }

                return new GetFoodRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = new List<FoodRESPONSE>()
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy user by id
        /// </summary>
        /// <returns></returns>
        public GetUserRESPONSE GetUserByID(int UserID)
        {
            try
            {
                var user = foodDAO.GetUserByID<User>(UserID);
                if (user != null)
                {

                    return new GetUserRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        user = user
                    };
                }

                return new GetUserRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    user = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy user by id
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSE GetFoodByID(int FoodID)
        {
            try
            {
                var food = foodDAO.GetFoodByID<Food>(FoodID);
                if(food != null)
                {
                    var FoodDiscount = foodDAO.GetDiscountByID<FoodDiscount>(FoodID);
                    return new GetFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = new List<FoodRESPONSE>()
                        {
                            new FoodRESPONSE()
                            {
                                Food = food,
                                FoodDiscount = FoodDiscount,
                            }
                        }
                    };
                }

                return new GetFoodRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = null
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy đánh giá
        /// </summary>
        /// <returns></returns>
        public GetUserEvalRESPONSE GetUserEval(int UserID, int FoodID)
        {
            try
            {
                var result = foodDAO.GetUserEval<UserEvaluation>(UserID, FoodID);
                if (result != null)
                {

                    return new GetUserEvalRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userEval = result
                    };
                }

                return new GetUserEvalRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userEval = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy đánh giá
        /// </summary>
        /// <returns></returns>
        public GetUserComment GetUserComment(int FoodID)
        {
            try
            {
                var result = foodDAO.GetUserComment<List<UserCommentRESPONSE>>(FoodID);
                if (result != null)
                {

                    return new GetUserComment()
                    {
                        Code = ResStatusCode.Success,
                        userComments = result
                    };
                }

                return new GetUserComment()
                {
                    Code = ResStatusCode.Success,
                    userComments = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cấp nhật điểm đánh giá
        /// </summary>
        /// <returns></returns>
        public UpdateEvalRESPONSE UpdateEval(int EvalID, float Point)
        {
            try
            {
                var result = foodDAO.UpdateEval<UserEvaluation>(EvalID, Point);
                if (result != null)
                {

                    return new UpdateEvalRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userEval = result
                    };
                }

                return new UpdateEvalRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userEval = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddUserEvalRESPONSE AddUserEval(AddUserEvalREQUEST req)
        {
            try
            {
                int ID = foodDAO.AddUserEval(req);
                if (ID > 0)
                {
                    return new AddUserEvalRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userEval = new UserEvaluation()
                        {
                            ID = ID,
                            EVALUATION = req.EVALUATION,
                            FOOD_ID = req.FOOD_ID,
                            USER_ID = req.USER_ID
                        }
                    };


                }

                return new AddUserEvalRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userEval = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cấp nhật foodEval
        /// </summary>
        /// <returns></returns>
        public UpdateFoodEvalRESPONSE UpdateFoodEval(UpdateFoodEvalREQUEST req)
        {
            try
            {
                var result = foodDAO.UpdateFoodEval<FoodEvaluation>(req);
                if (result != null)
                {

                    return new UpdateFoodEvalRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        foodEval = result
                    };
                }

                return new UpdateFoodEvalRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    foodEval = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddFoodEvalRESPONSE AddFoodEval(AddFoodEvalREQUEST req)
        {
            try
            {
                int ID = foodDAO.AddFoodEval(req);
                if (ID > 0)
                {
                    return new AddFoodEvalRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        foodEval = new FoodEvaluation()
                        {
                            ID = ID,
                            AVARAGE_POINT = req.AVARAGE_POINT,
                            TOTAL_POINT = req.TOTAL_POINT,
                            FOOD_ID = req.FOOD_ID,
                            TOTAL_USER = req.TOTAL_USER
                        }
                    };


                }

                return new AddFoodEvalRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    foodEval = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddUserCommentRESPONSE AddUserComment(AddUserCommentREQUEST req)
        {
            try
            {
                int ID = foodDAO.AddUserComment(req);
                if (ID > 0)
                {
                    return new AddUserCommentRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userComment = new UserComment()
                        {
                            ID = ID,
                            COMMENT = req.COMMENT,
                            USER_ID = req.USER_ID
                        }
                    };
                }

                return new AddUserCommentRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userComment = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddUserFavoriteFoodRESPONSE AddUserFavoriteFood(AddUserFavoriteREQUEST req)
        {
            try
            {
                int ID = foodDAO.AddUserFavoriteFood(req);
                if (ID > 0)
                {
                    return new AddUserFavoriteFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userFavoriteFood = new UserFavoriteFood()
                        {
                            ID = ID,
                            FAVORITE_FOOD_DESCRIPTION = req.FAVORITE_FOOD_DESCRIPTION,
                            USER_ID = req.USER_ID,
                            FOOD_ID = req.FOOD_ID
                        }
                    };
                }

                return new AddUserFavoriteFoodRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userFavoriteFood = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy 
        /// </summary>
        /// <returns></returns>
        public GetUserFavoriteRESPONSE GetUserFavoriteByID(int UserID, int FoodID)
        {
            try
            {
                var result = foodDAO.GetUserFavoriteByID<UserFavoriteFood>(UserID, FoodID);
                if (result != null)
                {

                    return new GetUserFavoriteRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        userFavoriteFood = result
                    };
                }

                return new GetUserFavoriteRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    userFavoriteFood = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy cart theo id
        /// </summary>
        /// <returns></returns>
        public DeleteUserFavoriteFoodRESPONSE DeleteUserFoodFavorite(int id)
        {
            try
            {
                int res = foodDAO.DeleteUserFoodFavorite(id);
                if (res > 0)
                {
                    return new DeleteUserFavoriteFoodRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                    };
                }

                return new DeleteUserFavoriteFoodRESPONSE()
                {
                    Code = ResStatusCode.InternalServerError,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy user by id
        /// </summary>
        /// <returns></returns>
        public GetUserRESPONSE GetUserByToken(string Token)
        {
            try
            {
                var user = foodDAO.GetUserByToken<User>(Token);
                if (user != null)
                {

                    return new GetUserRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        user = user
                    };
                }

                return new GetUserRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    user = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Thêm 1 sản phẩm vào database
        /// </summary>
        /// <returns></returns>
        public AddUserRESPONSE AddUser(AddUserREQUEST req)
        {
            try
            {
                int ID = foodDAO.AddUser(req);
                if (ID > 0)
                {
                    return new AddUserRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        user = new User()
                        {
                            ID = ID,
                            AVATAR = req.AVATAR,
                            NAME = req.NAME ,
                            TOKEN = req.TOKEN,
                            TYPE = req.TYPE
                        }
                    };
                }

                return new AddUserRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    user = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Lấy đánh giá
        /// </summary>
        /// <returns></returns>
        public GetAllUserFavoriteRESPONSE GetAllUserFavoriteByID(int UserID)
        {
            try
            {
                var result = foodDAO.GetAllUserFavoriteByID<List<UserFavoriteResponseBE>>(UserID);
                if (result != null)
                {

                    return new GetAllUserFavoriteRESPONSE()
                    {
                        Code = ResStatusCode.Success,
                        Data = result
                    };
                }

                return new GetAllUserFavoriteRESPONSE()
                {
                    Code = ResStatusCode.Success,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //------------------------------------------------------------------------------//

        /// <summary>
        /// Lấy tất cả món ăn mới nhất trong 5 ngày
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSEVer2 GetNewFoodVer2()
        {
            try
            {
                var ListFood = foodDAO.GetNewFood<List<Food>>();
                if (ListFood != null && ListFood.Count > 0)
                {
                    var ListDiscount = foodDAO.GetListDisCountFromFood<List<FoodDiscount>>(ListFood);
                    var ListFoodEval = foodDAO.GetListFoodEvalFromFood<List<FoodEvaluation>>(ListFood);
                    List<FoodRESPONSEVer2> res = new List<FoodRESPONSEVer2>();
                    int i = 0;
                    ListFood.ForEach(f =>
                    {
                        var discount = ListDiscount.FirstOrDefault(w => w.FOOD_ID == f.ID);
                        res.Add(new FoodRESPONSEVer2()
                        {
                            Food = f,
                            FoodDiscount = discount,
                            FoodEvalution = ListFoodEval[i++]
                        });
                    });

                    return new GetFoodRESPONSEVer2()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = res
                    };
                }

                return new GetFoodRESPONSEVer2()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = new List<FoodRESPONSEVer2>()
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy tất cả món ăn giảm giá
        /// </summary>
        /// <returns></returns>
        public GetFoodRESPONSEVer2 GetFoodDiscountVer2()
        {
            try
            {
                var ListDiscount = foodDAO.GetAllDiscount<List<FoodDiscount>>();
                if (ListDiscount != null && ListDiscount.Count > 0)
                {
                    var ListFood = foodDAO.GetListFoodFromDiscount<List<Food>>(ListDiscount);
                    var ListFoodEval = foodDAO.GetListFoodEvalFromFood<List<FoodEvaluation>>(ListFood);
                    int i = 0;
                    List<FoodRESPONSEVer2> res = new List<FoodRESPONSEVer2>();
                    ListFood.ForEach(f =>
                    {
                        var discount = ListDiscount.FirstOrDefault(w => w.FOOD_ID == f.ID);
                        res.Add(new FoodRESPONSEVer2()
                        {
                            Food = f,
                            FoodDiscount = discount,
                            FoodEvalution = ListFoodEval[i++]
                        });
                    });

                    return new GetFoodRESPONSEVer2()
                    {
                        Code = ResStatusCode.Success,
                        ListFoodRes = res
                    };
                }

                return new GetFoodRESPONSEVer2()
                {
                    Code = ResStatusCode.Success,
                    ListFoodRes = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy đánh giá
        /// </summary>
        /// <returns></returns>
        public GetUserCommentVer2 GetUserCommentVer2(int FoodID, int UserID)
        {
            try
            {
                // Đã lấy dc danh sách comment
                var result = foodDAO.GetUserComment<List<UserCommentRESPONSE>>(FoodID);
                if (result != null)
                {
                    // Lấy tiếp user favorite và User Eval
                    UserFavEvalBE dataRes = Database.Database.GetInstance().GetUserFavoriteByIDVer2<UserFavEvalBE>(UserID, FoodID);


                    return new GetUserCommentVer2()
                    {
                        Code = ResStatusCode.Success,
                        Data = new GetUserCmtDataVer2()
                        {
                            userComments = result,
                            userEval = dataRes.userEval,
                            userFavorite = dataRes.userFavorite
                        }
                    };
                }

                return new GetUserCommentVer2()
                {
                    Code = ResStatusCode.Success,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}