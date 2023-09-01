using CRMSystem.DataAccess.Repository.IRepository;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
      
        private readonly IUnitOfWork _unitOfWork;
        /// </summary>
        /// <param name="db"></param>
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objCategoryList = _unitOfWork.User.GetAll();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            int isAdmin = Convert.ToInt32(HttpContext.Session.GetInt32("IsAdmin"));
            if (isAdmin == 0)
            {
                TempData["error"] = "Only admin user allow to edit";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(User user)
        {
            


            if (ModelState.IsValid)
            {
                _unitOfWork.User.Add(user);
                _unitOfWork.Save();
                TempData["success"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            return View(user);

        }
        public IActionResult Edit(int? id)
        {
            int isAdmin = Convert.ToInt32(HttpContext.Session.GetInt32("IsAdmin"));
            if (isAdmin == 0)
            {
                TempData["error"] = "Only admin user allow to edit";
                return RedirectToAction("Index");
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var userFirstOrDefault = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            
            if (userFirstOrDefault == null)
            {
                return NotFound();
            }

            return View(userFirstOrDefault);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(User user)
        {
            

            if (ModelState.IsValid)
            {
                _unitOfWork.User.Update(user);
                _unitOfWork.Save();
                TempData["success"] = "User Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(user);

        }

        public IActionResult Delete(int? id)
        {
            int isAdmin = Convert.ToInt32(HttpContext.Session.GetInt32("IsAdmin"));
            if (isAdmin == 0)
            {
                TempData["error"] = "Only admin user allow to edit";
                return RedirectToAction("Index");
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var userFromDbFirst = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            
            if (userFromDbFirst == null)
            {
                return NotFound();
            }

            return View(userFromDbFirst);
        }



        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.User.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult DeletePost1(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.User.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
