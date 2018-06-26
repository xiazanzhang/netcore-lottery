using Microsoft.AspNetCore.Mvc;

namespace Lottery.Api.Controllers
{
    public class ResultModel
    {
        public ResultCode Code { get; set; }

        public string Msg { get; set; }

        public dynamic Data { get; set; }

    }

    public enum ResultCode
    {
        ok = 200,
        info = 300,
        error = 500,
        notLogin = 600
    }

    public class BaseController : Controller
    {
        public static JsonResult Result()
        {
            return new JsonResult(new
            {
                Code = ResultCode.ok,
                Msg = "成功"
            });
        }

        public static JsonResult Result(ResultCode resultCode, string msg)
        {
            return new JsonResult(new
            {
                Code = resultCode,
                Msg = msg
            });
        }

        public static JsonResult Result(ResultCode resultCode, object obj)
        {
            return new JsonResult(new
            {
                Code = resultCode,
                Data = obj
            });
        }
    }
}