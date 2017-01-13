using FoodServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodServer.DAO
{
    public class FoodDAO
    {
        /// <summary>
        /// Lấy danh sách các món ăn mới nhất trong 3 ngày
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetNewFood<T>()
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetNewFood<T>();

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Từ danh sách Food. Lấy danh sách DisCount
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetListDisCountFromFood<T>(List<Food> req)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetDiscountFromFood<T>(req);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách các discount hợp lệ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetAllDiscount<T>()
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetAllDiscount<T>();

                return (T)result;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Từ danh sách Discount. Lấy danh sách Food
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetListFoodFromDiscount<T>(List<FoodDiscount> req)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetListFoodFromDiscount<T>(req);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách các discount hợp lệ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetFoodEvaluation<T>(int FoodID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetFoodEvaluation<T>(FoodID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách các discount hợp lệ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetDiscountByID<T>(int FoodID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetDiscountByID<T>(FoodID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy user by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetUserByID<T>(int UserID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetUserByID<T>(UserID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy user by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetFoodByID<T>(int FoodID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetFoodByID<T>(FoodID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy đánh giá
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetUserEval<T>(int UserID, int FoodID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetUserEval<T>(UserID, FoodID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy user comment
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetUserComment<T>(int FoodID)
        {
            try
            {
                object result = null;
                result = Database.Database.GetInstance().GetUserComment<T>(FoodID);

                return (T)result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy user comment
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T UpdateEval<T>(int EvalID, float Point)
        {
            try
            {
                return Database.Database.GetInstance().UpdateTblUserEval<T>(EvalID, Point);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Thêm mới 1 đánh giá vào bảng User Eval
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddUserEval(AddUserEvalREQUEST req)
        {
            try
            {
                return Database.Database.GetInstance().InsertTblUserEval(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lấy user comment
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T UpdateFoodEval<T>(UpdateFoodEvalREQUEST req)
        {
            try
            {
                return Database.Database.GetInstance().UpdateTblFoodEval<T>(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ADD vào bảng Food Eval
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddFoodEval(AddFoodEvalREQUEST req)
        {
            try
            {
                return Database.Database.GetInstance().InsertTblFoodEval(req);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ADD vào bảng User comment
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddUserComment(AddUserCommentREQUEST req)
        {
            try
            {
                return Database.Database.GetInstance().InsertTblComment(req);
            }
            catch
            {
                throw;
            }
        }
    }
}