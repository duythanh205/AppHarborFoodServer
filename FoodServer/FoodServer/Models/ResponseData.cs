using FoodServer.Libs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodServer.Models
{
    public class ResponseData
    {
        public ResStatusCode Code { set; get; }
        public string Message { set; get; }
        public object Data { set; get; }

        public ResponseData()
        {

        }
    }

    public enum ResStatusCode
    {
        Success = 200,

        InternalServerError = 500,

        BadRequest = 400,


        UNKNOW = -99999,
    }

    public class ResponseDataFactory
    {
        private ResponseDataFactory() { }

        private static Dictionary<ResStatusCode, string> dicMessageModel = new Dictionary<ResStatusCode, string>();
        private static Dictionary<ResStatusCode, string> DicMessageModel
        {
            set
            {
                dicMessageModel = value;
            }
            get
            {
                try
                {
                    if (dicMessageModel == null || dicMessageModel.Count == 0)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Message.json");
                        var data = File.ReadAllText(filePath);
                        dicMessageModel = string.IsNullOrEmpty(data) ? null : data.FromJson<Dictionary<ResStatusCode, string>>(true);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dicMessageModel;
            }
        }

        public static ResponseData getInstace(ResStatusCode type, object data)
        {
            try
            {
                if (DicMessageModel.ContainsKey(type))
                {
                    return new ResponseData()
                    {
                        Code = type,
                        Data = data,
                        Message = DicMessageModel[type]
                    };
                }
                else
                {
                    return new ResponseData()
                    {
                        Code = type,
                        Data = data,
                        Message = DicMessageModel[ResStatusCode.UNKNOW]
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Code = type,
                    Data = data,
                    Message = DicMessageModel[ResStatusCode.UNKNOW]
                };
            }
        }

        public static ResponseData getInstace(ResStatusCode type)
        {
            return getInstace(type, null);
        }
    }
}