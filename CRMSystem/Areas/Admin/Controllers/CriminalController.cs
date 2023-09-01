using CRMSystem.DataAccess.Repository.IRepository;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CRMSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CriminalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        /// </summary>
        /// <param name="db"></param>
        public CriminalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()//v
        {
            //session usernamr == null ... login
            IEnumerable<Criminal> objCategoryList = _unitOfWork.Criminal.GetAll();
            return View(objCategoryList);
        }

     

        public IActionResult Create() //v
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Criminal criminal)
        {
            criminal.CreatedByUserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            criminal.CreatedByUserName = Convert.ToString(HttpContext.Session.GetInt32("UserName"));
            // criminal.ModifiedByByUserName = Convert.ToString(HttpContext.Session.GetInt32("UserName"));

            if (ModelState.IsValid)
            {
               

                //int isAdmin = Convert.ToInt32(HttpContext.Session.GetInt32("IsAdmin"));
                //if(isAdmin == 0)
                //{
                //    TempData["error"] = "Only admin user allow this";
                //    return RedirectToAction("Index");
                //}

                _unitOfWork.Criminal.Add(criminal);
                _unitOfWork.Save();
                TempData["success"] = "Criminal Created Successfully";
                return RedirectToAction("Index");
            }
            return View(criminal);

        }
        public IActionResult Edit(int? id)//v
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

            var userFirstOrDefault = _unitOfWork.Criminal.GetFirstOrDefault(u => u.Id == id);

            if (userFirstOrDefault == null)
            {
                return NotFound();
            }

            return View(userFirstOrDefault);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Criminal criminal)
        {

            if (ModelState.IsValid)
            {
                int isAdmin = Convert.ToInt32(HttpContext.Session.GetInt32("IsAdmin"));
                if (isAdmin == 0)
                {
                    TempData["error"] = "Only admin user allow to edit";
                    return RedirectToAction("Index");
                }

                //criminal.ModifiedByUserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                _unitOfWork.Criminal.Update(criminal);
                _unitOfWork.Save();
                TempData["success"] = "Criminal Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(criminal);

        }

        public IActionResult Delete(int? id)//v
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

            var criminalFromDbFirst = _unitOfWork.Criminal.GetFirstOrDefault(u => u.Id == id);

            if (criminalFromDbFirst == null)
            {
                return NotFound();
            }

            return View(criminalFromDbFirst);
        }



        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _unitOfWork.Criminal.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Criminal.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Criminal Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
