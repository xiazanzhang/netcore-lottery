using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lottery.Model;
using Lottery.Service;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Lottery.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly UserService userService = new UserService();

        public JsonResult GetUserInfo()
        {
            var info = HttpContext.Session.GetString("login");

            if (info == null)
            {
                return Result(ResultCode.notLogin, "当前会话已过期，请重新登录");
            }

            var model = JsonConvert.DeserializeObject(info);

            return Result(ResultCode.ok, model);
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody]User user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.CardSalt = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return Result(ResultCode.info, "参数不合法");
            }

            var model = userService.GetUserByAccount(user.Account);

            if (model != null)
            {
                return Result(ResultCode.info, "当前帐号已被注册，请更改用户名后重新注册");
            }

            bool status = await userService.Register(user);

            if (status)
            {
                return Result();
            }
            else
            {
                return Result(ResultCode.error, "注册失败");
            }
        }

        [HttpPost]
        public JsonResult Login([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Result(ResultCode.info, "参数不合法");
            }

            var model = userService.Login(userViewModel.Account, userViewModel.Password);


            if (model == null)
            {
                return Result(ResultCode.info, "帐号或密码错误");
            }


            if (model.Status == 2)
            {
                return Result(ResultCode.info, "当前帐号已被锁定，无法登陆");
            }

            var resultModel = new
            {
                model.Id,
                model.Account,
                model.Mobile,
                model.Realname,
                Status = 1
            };

            HttpContext.Session.SetString("login", JsonConvert.SerializeObject(resultModel));

            return Result(ResultCode.ok, resultModel);
        }
    }

    public class UserViewModel
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}