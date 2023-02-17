using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.UoW.Abstract;
using AnketToplamaMerkezi.UoW.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AnketToplamaMerkezi.UI.Controllers
{
    public class SavedSurveyInformationController : Controller
    {
        private readonly ILogger<SavedSurveyInformationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public SavedSurveyInformationController(ILogger<SavedSurveyInformationController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new DAL.SurveyContext());
        }

        public IActionResult Index()
        {
            var savedSurveyList = _unitOfWork.SavedSurveysBusiness.GetSurveyWithSurveyInformationList();
            return View(savedSurveyList);
        }


        public IActionResult EditSurveyAnswers(int id)
        {
            var savedSurvey = _unitOfWork.SavedSurveysBusiness.GetSurveyDataWithSurveyInformationById(id);
            if (savedSurvey.SurveyType == (int)SurveyType.Football)
            {
                return RedirectToAction("EditSurveyAnswers", "FootballSurveyInformation", new { id = savedSurvey.SurveyAnswersId });

            }
            else
            {
                return RedirectToAction("EditSurveyAnswers", "HappinessSurveyInformation", new { id = savedSurvey.SurveyAnswersId });

            }
        }
        public IActionResult OpenSurveyAnswers(int id)
        {
            var savedSurvey = _unitOfWork.SavedSurveysBusiness.GetSurveyDataWithSurveyInformationById(id);
            if (savedSurvey.SurveyType == (int)SurveyType.Football)
            {
                return RedirectToAction("OpenSurveyAnswers", "FootballSurveyInformation", new { id = savedSurvey.SurveyAnswersId });

            }
            else
            {
                return RedirectToAction("OpenSurveyAnswers", "HappinessSurveyInformation", new { id = savedSurvey.SurveyAnswersId });

            }
        }

        public IActionResult DeleteSurvey(int id)
        {
            _unitOfWork.SavedSurveysBusiness.DeleteSurveyInformation(id);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
            return RedirectToAction("Index", "SavedSurveyInformation");
        }
    }
}
