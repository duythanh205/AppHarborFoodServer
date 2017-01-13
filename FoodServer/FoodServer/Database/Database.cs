using FoodServer.Libs;
using FoodServer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FoodServer.Database
{
    public class Database
    {
        private static Database instance { set; get; }
        private static object lockObj = new object();

        private SqlConnection connect { set; get; }
        private Database()
        {
            Init();
        }

        /// <summary>
        /// Create SqlConnection and get ConnectionString
        /// </summary>
        private void Init()
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = ConfigurationManager.ConnectionStrings["sqlString"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sigleton
        /// </summary>
        /// <returns></returns>
        public static Database GetInstance()
        {
            try
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new Database();
                        }
                    }
                }

                return instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call Sql Connection Open
        /// </summary>
        public void SqlConnectionOpen()
        {
            try
            {
                connect.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Call Sql Connection Close
        /// </summary>
        public void SqlConnectionClose()
        {
            try
            {
                connect.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy các food có created_date > 5 (mới nhất trong 5 ngày) 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetNewFood<T>()
        {
            SqlDataReader reader = null;
            List<Food> list = new List<Food>();
            object result = null;
            string query = "select* from FOODS where CREATED_DATE >= @date";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now.AddDays(-5).ToStartDate();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Food()
                        {
                            ID = (int)reader["ID"],
                            ADDRESS = reader["ADDRESS"].ToString().Trim(),
                            AVATAR = reader["AVATAR"].ToString().Trim(),
                            CREATED_DATE = (DateTime)reader["CREATED_DATE"],
                            NAME = reader["NAME"].ToString().Trim(),
                        });
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy các discount theo food
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetDiscountFromFood<T>(List<Food> req)
        {
            SqlDataReader reader = null;
            List<FoodDiscount> list = new List<FoodDiscount>();
            object result = null;
            string query = "select* from FOOD_DISCOUNT where FOOD_ID = @id and STARTS_DATE <= @dt and END_DATE >= @dt";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters.Add("@dt", SqlDbType.DateTime);

                    foreach (var food in req)
                    {
                        cmd.Parameters["@id"].Value = food.ID;
                        cmd.Parameters["@dt"].Value = DateTime.Now;

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(new FoodDiscount()
                            {
                                ID = (int)reader["ID"],
                                FOOD_ID = (int)reader["FOOD_ID"],
                                DISCOUNT_DESCRIPTION = reader["DISCOUNT_DESCRIPTION"].ToString().Trim(),
                                DISCOUNT_PERCENT = (int)reader["DISCOUNT_PERCENT"],
                                END_DATE = (DateTime)reader["END_DATE"],
                                STARTS_DATE = (DateTime)reader["STARTS_DATE"],
                            });
                        }

                        if (reader != null)
                        {
                            reader.Close();
                        }

                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }


        /// <summary>
        /// Lấy các discount hợp lệ 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetAllDiscount<T>()
        {
            SqlDataReader reader = null;
            List<FoodDiscount> list = new List<FoodDiscount>();
            object result = null;
            string query = "select* from FOOD_DISCOUNT where STARTS_DATE <= @dt and END_DATE >= @dt";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@dt", SqlDbType.DateTime).Value = DateTime.Now.ToStartDate();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new FoodDiscount()
                        {
                            ID = (int)reader["ID"],
                            FOOD_ID = (int)reader["FOOD_ID"],
                            DISCOUNT_DESCRIPTION = reader["DISCOUNT_DESCRIPTION"].ToString().Trim(),
                            DISCOUNT_PERCENT = (int)reader["DISCOUNT_PERCENT"],
                            END_DATE = (DateTime)reader["END_DATE"],
                            STARTS_DATE = (DateTime)reader["STARTS_DATE"],
                        });
                    }

                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy các Food theo Discount
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetListFoodFromDiscount<T>(List<FoodDiscount> req)
        {
            SqlDataReader reader = null;
            List<Food> list = new List<Food>();
            object result = null;
            string query = "select* from FOODS where ID = @id_food";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@id_food", SqlDbType.Int);

                    foreach (var discount in req)
                    {
                        cmd.Parameters["@id_food"].Value = discount.FOOD_ID;
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Food()
                            {
                                ID = (int)reader["ID"],
                                ADDRESS = reader["ADDRESS"].ToString().Trim(),
                                AVATAR = reader["AVATAR"].ToString().Trim(),
                                CREATED_DATE = (DateTime)reader["CREATED_DATE"],
                                NAME = reader["NAME"].ToString().Trim(),
                            });
                        }

                        reader.Close();
                    }
                }

                result = list.ToList();
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy các discount hợp lệ 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetFoodEvaluation<T>(int FoodID)
        {
            SqlDataReader reader = null;
            FoodEvaluation foodEvaluation = null;
            object result = null;
            string query = "select* from FOOD_EVALUATION where FOOD_ID = @FoodID";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = FoodID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        foodEvaluation = new FoodEvaluation()
                        {
                            FOOD_ID = (int)reader["FOOD_ID"],
                            ID = (int)reader["ID"],
                            TOTAL_USER = (int)reader["TOTAL_USER"],
                            AVARAGE_POINT = float.Parse(reader["AVARAGE_POINT"].ToString()),
                            TOTAL_POINT = float.Parse(reader["TOTAL_POINT"].ToString()),
                        };
                    }

                }

                result = foodEvaluation;
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy các discount hợp lệ 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetDiscountByID<T>(int FoodID)
        {
            SqlDataReader reader = null;
            FoodDiscount foodDiscount = null;
            object result = null;
            string query = "select* from FOOD_DISCOUNT where STARTS_DATE <= @dt and END_DATE >= @dt and FOOD_ID = @FoodID";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@dt", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = FoodID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        foodDiscount = new FoodDiscount()
                        {
                            ID = (int)reader["ID"],
                            FOOD_ID = (int)reader["FOOD_ID"],
                            DISCOUNT_DESCRIPTION = reader["DISCOUNT_DESCRIPTION"].ToString().Trim(),
                            DISCOUNT_PERCENT = (int)reader["DISCOUNT_PERCENT"],
                            END_DATE = (DateTime)reader["END_DATE"],
                            STARTS_DATE = (DateTime)reader["STARTS_DATE"],
                        };
                    }

                }

                result = foodDiscount;
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy user by id 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetUserByID<T>(int UserID)
        {
            SqlDataReader reader = null;
            User user = null;
            object result = null;
            string query = "SELECT * FROM dbo.USERS WHERE ID = @UserID";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            AVATAR = reader["AVATAR"].ToString().Trim(),
                            ID = (int)reader["ID"],
                            NAME = reader["NAME"].ToString().Trim(),
                        };
                    }

                }

                result = user;
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy user by id 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetUserEval<T>(int UserID, int FoodID)
        {
            SqlDataReader reader = null;
            UserEvaluation userEvaluation = null;
            object result = null;
            string query = "select* from USER_FOOD_EVALUATION where USER_ID = @UserID and FOOD_ID = @FoodID";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = FoodID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userEvaluation = new UserEvaluation()
                        {
                            EVALUATION = (float)reader["EVALUATION"],
                            FOOD_ID = (int)reader["FOOD_ID"],
                            ID = (int)reader["ID"],
                            USER_ID = (int)reader["USER_ID"],
                        };
                    }

                }

                result = userEvaluation;
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Lấy user comment 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetUserComment<T>(int FoodID)
        {
            SqlDataReader reader = null;
            List<UserComment> userComments = null;
            object result = null;
            string query = "select* from USER_FOOD_COMMENT where FOOD_ID = @FoodID";

            try
            {
                connect.Open();
                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add("@FoodID", SqlDbType.Int).Value = FoodID;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userComments.Add(new UserComment()
                        {
                            COMMENT = reader["COMMENT"].ToString().Trim(),
                            FOOD_ID = (int)reader["FOOD_ID"],
                            ID = (int)reader["ID"],
                            USER_ID = (int)reader["USER_ID"]
                        });
                    }

                }

                result = userComments;
                return (T)result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu bảng Evaluation
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T UpdateTblUserEval<T>(int EvalID, float Point)
        {
            int result = -1;
            object res = null;
            string query = "update dbo.USER_FOOD_EVALUATION values (@EVALUATION) where ID = @EvalID";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@EvalID", SqlDbType.Int).Value = EvalID;
                    command.Parameters["@EVALUATION"].Value = Point;

                    result = command.ExecuteNonQuery();
                    if(result > 0)
                    {
                        UserEvaluation eval = new UserEvaluation()
                        {
                            EVALUATION = (float)command.Parameters["@EVALUATION"].Value,
                            FOOD_ID = (int)command.Parameters["@FOOD_ID"].Value,
                            ID = (int)command.Parameters["@ID"].Value,
                            USER_ID = (int)command.Parameters["@USER_ID"].Value
                        };
                        res = eval;
                    }
                }
                
                return (T)res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng UserEval
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblUserEval(AddUserEvalREQUEST req)
        {
            int id = -1;
            string query = "insert into dbo.USER_FOOD_EVALUATION Output Inserted.ID values (@USER_ID, @FOOD_ID, @EVALUATION)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@USER_ID", SqlDbType.Int).Value = req.USER_ID;
                    command.Parameters.Add("@FOOD_ID", SqlDbType.Int).Value = req.FOOD_ID;
                    command.Parameters.Add("@EVALUATION", SqlDbType.Float).Value = req.EVALUATION;

                    id = (int)command.ExecuteScalar();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu bảng Food_Evaluation
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public T UpdateTblFoodEval<T>(UpdateFoodEvalREQUEST req)
        {
            int result = -1;
            object res = null;
            string query = "update dbo.FOOD_EVALUATION values (@FOOD_ID, @AVARAGE_POINT, @TOTAL_POINT, @TOTAL_USER) where ID = @evalID";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@evalID", SqlDbType.Int).Value = req.FOOD_ID;
                    command.Parameters["@FOOD_ID"].Value = req.FOOD_ID;
                    command.Parameters["@AVARAGE_POINT"].Value = req.AVARAGE_POINT;
                    command.Parameters["@TOTAL_POINT"].Value = req.TOTAL_POINT;
                    command.Parameters["@TOTAL_USER"].Value = req.TOTAL_USER;

                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        FoodEvaluation eval = new FoodEvaluation()
                        {
                            AVARAGE_POINT = (float)command.Parameters["@AVARAGE_POINT"].Value,
                            FOOD_ID = (int)command.Parameters["@FOOD_ID"].Value,
                            ID = (int)command.Parameters["@ID"].Value,
                            TOTAL_POINT = (float)command.Parameters["@TOTAL_POINT"].Value,
                            TOTAL_USER = (int)command.Parameters["@TOTAL_USER"].Value
                        };
                        res = eval;
                    }
                }

                return (T)res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng FoodEval
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblFoodEval(AddFoodEvalREQUEST req)
        {
            int id = -1;
            string query = "insert into dbo.FOOD_EVALUATION Output Inserted.ID values (@FOOD_ID, @AVARAGE_POINT, @TOTAL_POINT, @TOTAL_USER)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@FOOD_ID", SqlDbType.Int).Value = req.FOOD_ID;
                    command.Parameters.Add("@AVARAGE_POINT", SqlDbType.Float).Value = req.AVARAGE_POINT;
                    command.Parameters.Add("@TOTAL_POINT", SqlDbType.Float).Value = req.TOTAL_POINT;
                    command.Parameters.Add("@TOTAL_USER", SqlDbType.Int).Value = req.TOTAL_USER;

                    id = (int)command.ExecuteScalar();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// Thêm data vào bảng Comment
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsertTblComment(AddUserCommentREQUEST req)
        {
            int id = -1;
            string query = "insert into dbo.USER_FOOD_COMMENT Output Inserted.ID values (@USER_ID, @FOOD_ID, @COMMENT)";
            try
            {
                connect.Open();
                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.Add("@USER_ID", SqlDbType.Int).Value = req.USER_ID;
                    command.Parameters.Add("@FOOD_ID", SqlDbType.Int).Value = req.FOOD_ID;
                    command.Parameters.Add("@COMMENT", SqlDbType.NVarChar).Value = req.COMMENT;

                    id = (int)command.ExecuteScalar();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
    }
}