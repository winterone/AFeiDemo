using AFeiDemo.BLL;
using AFeiDemo.Common;
using AFeiDemo.Model;
using System;
using System.Web.Mvc;

namespace AFeiDemo.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 处理登录的信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="CookieExpires">cookie有效期</param>
        /// <returns></returns>
        public ActionResult CheckUserLogin(UserModel userInfo, string CookieExpires)
        {
            try
            {
                UserModel currentUser = new UserBLL().UserLogin(userInfo.AccountName, Md5.GetMD5String(userInfo.Password));
                if (currentUser != null)
                {
                    if (currentUser.IsAble == false)
                    {
                        return Content("用户已被禁用，请您联系管理员");
                    }
                    //记录登录cookie
                    CookiesHelper.SetCookie("UserID", AES.EncryptStr(currentUser.ID.ToString()));
                    //记录用户登录所在IP
                    LoginIpLogModel logEntity = new LoginIpLogModel();
                    string ip = Comm.Get_ClientIP();
                    if (string.IsNullOrEmpty(ip))
                    {
                        logEntity.IpAddress = "localhost";
                    }
                    else
                    {
                        logEntity.IpAddress = ip;
                    }
                    logEntity.CreateBy = currentUser.AccountName;
                    logEntity.CreateTime = DateTime.Now;
                    logEntity.UpdateBy = currentUser.AccountName;
                    logEntity.UpdateTime = DateTime.Now;
                    new LoginIpLogBLL().Add(logEntity);
                    return Content("OK");
                }
                else
                {
                    return Content("用户名密码错误，请您检查");
                }
            }
            catch (Exception ex)
            {
                return Content("登录异常," + ex.Message);
            }
        }

        public ActionResult UserLoginOut()
        {
            //清空cookie
            CookiesHelper.AddCookie("UserID", System.DateTime.Now.AddDays(-1));
            return Content("{\"msg\":\"退出成功！\",\"success\":true}");
        }

        public ActionResult GetValidatorGraphics()
        {
            string code = new ValidatorCode().NewValidateCode();
            //采用cookie
            CookiesHelper.SetCookie("ValidatorCode", code);
            byte[] graphic = new ValidatorCode().NewValidateCodeGraphic(code);
            return File(graphic, @"image/jpeg");
        }
    }
}