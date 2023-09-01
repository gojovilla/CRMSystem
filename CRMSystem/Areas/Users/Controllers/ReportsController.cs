using CRMSystem.DataAccess.Repository.IRepository;
using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CRMSystem.Areas.Users.Controllers
{
    [Area("Users")]
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult UserReport()
        {
            IEnumerable<User> objUserList = _unitOfWork.User.GetAll();
            return View(objUserList);
        }
        public IActionResult UserReportDownload()
        {
            IEnumerable<User> objUserList = _unitOfWork.User.GetAll();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Id, Name, Email"); // Add header row
            foreach (User user in objUserList)
            {
                sb.AppendLine($"{user.Id}, {user.UserName}, {user.Email}"); // Add data rows
            }
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            MemoryStream stream = new MemoryStream(bytes);
            return new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "UserReport.csv"
            };
        }
        [Area("Users")]
        public IActionResult CriminalReport()
        {
            IEnumerable<Criminal> objCriminalList = _unitOfWork.Criminal.GetAll();
            return View(objCriminalList);
        }
        public IActionResult CriminalReportDownload()
        {
            IEnumerable<Criminal> objCriminalList = _unitOfWork.Criminal.GetAll();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name,Last Name,Mobile Number,Age,LocationOfIncident,DateTimeOfReported,IncidentDateTime,TypeOfIncident"); // Add header row
            foreach (Criminal criminal in objCriminalList)
            {
                sb.AppendLine($"{criminal.FirstName}, {criminal.LastName},  {criminal.ContactNumber}, {criminal.Age}, {criminal.LocationOfIncident}, {criminal.DateTimeReported}, {criminal.IncidentDateTime}, {criminal.TypeOfIncident}"); // Add data rows
            }
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            MemoryStream stream = new MemoryStream(bytes);
            return new FileStreamResult(stream, "text/csv")
            {
                FileDownloadName = "CriminalReport.csv"
            };
        }
    }
}
