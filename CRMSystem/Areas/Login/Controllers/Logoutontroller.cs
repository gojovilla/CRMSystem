using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Areas.Login.Controllers
{
    public class Logoutontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
