using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.BusinessLayer.Concrete;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.UI.Models;
using AnketToplamaMerkezi.UoW.Abstract;
using AnketToplamaMerkezi.UoW.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Diagnostics;

namespace AnketToplamaMerkezi.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new SurveyContext());
        }

        public IActionResult Index()
        {
            List<SurveyInformationModel> surveyInformations = new List<SurveyInformationModel>();
            surveyInformations = _unitOfWork.SurveyInformationBusiness.GetSurveyInformationList();
            return View(surveyInformations);
        }

        public IActionResult AnswerSurvey(int id)
        {
            return RedirectToAction("AnswerSurvey","SurveyInformation", new {id = id });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}