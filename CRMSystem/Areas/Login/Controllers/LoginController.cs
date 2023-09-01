using CRMSystem.DataAccess.Repository.IRepository;
using CRMSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRMSystem.Areas.Login.Controllers
{

    public class Test
    {
        public string EmailId = "";
        public string Password = "";
    }
    public class Response
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }

    [Area("Login")]

    public class LoginController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        /// </summary>
        /// <param name="db"></param>
        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            SessionNull();
            return View();
        }

        [HttpPost]
        //[AutoValidateAntiforgeryToken]

        public JsonResult LoginPost(string un, string pwd) // here data received from jqury
        {
            Response res = new Response();
            try
            {
                //var EmailVerify = "/^\\w+([\\.-]?\\w+)*@\\w+([\\.-]?\\w+)*(\\.\\w{2,3})+$/";
                //if(!EmailVerify.Contains(un))
                //{
                //    res.Message = "Wrong Email Format";
                //    return Json(res);
                //}


                if (string.IsNullOrEmpty(un))
                {
                    res.Message = "Empty Entry";
                    return Json(res);
                }
                if (!string.IsNullOrEmpty(un))
                {
                    if (un.Length < 15 || un.Length >= 50)
                    {
                        res.Message = "Username length should be between 15 and 50";
                        return Json(res);
                    }
                }
                if (string.IsNullOrEmpty(pwd))
                {
                    res.Message = "Please provide password";
                    return Json(res);
                }
                if (!string.IsNullOrEmpty(pwd))
                {
                    if (pwd.Length < 6 || pwd.Length >= 15) // 123
                    {
                        res.Message = "Password length should be between 6 and 15";
                        return Json(res);
                    }
                }

                if (pwd == "")
                {
                    res.Message = "Please provide password";
                    return Json(res);
                }
                var userFirstOrDefault = _unitOfWork.User.GetFirstOrDefault(u => u.Email == un); // fetching data based on email id
                if (userFirstOrDefault != null) // if data received
                {
                    if (userFirstOrDefault.Password == pwd) // now checking password
                    {
                        res.Status = true;
                        //set useid id into session
                        //use session here to store userid and username 
                        // here success
                        int Userid = userFirstOrDefault.Id;
                        int IsAdmin = userFirstOrDefault.IsAdmin;
                        string UserName = Convert.ToString(userFirstOrDefault.UserName);

                        HttpContext.Session.SetInt32("UserId", Userid);
                        HttpContext.Session.SetInt32("IsAdmin", IsAdmin);
                        HttpContext.Session.SetString("UserName", UserName);
                        return Json(res);
                    }
                    else
                    {
                        res.Message = "Invalid password";
                        return Json(res);
                    }

                }
                else
                {
                    res.Status = false;
                    res.Message = "Invalid Username";
                    return Json(res);
                }

            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = "Something went wrong";
                return Json(res);
            }
        }

        [HttpPost]
        public JsonResult Logout()
        {
           
            Response res = new Response();
            try
            {
                HttpContext.Session.Clear();
                Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                Response.Headers.Add("Expires", "-1");
                Response.Headers.Add("Pragma", "no-cache");
                res.Status = true;
                res.Message = "Logout successful";
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = "Error while logout";
            }
            return Json(res);
        }

        private void SessionNull()
        {
            try
            {
                HttpContext.Session.SetString("UserId", null);
                HttpContext.Session.SetString("UserName", null);
            }
            catch (Exception ex)
            {
               
            }

        }
    }
}
