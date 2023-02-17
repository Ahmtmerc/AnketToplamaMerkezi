using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.UoW.Abstract;
using AnketToplamaMerkezi.UoW.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AnketToplamaMerkezi.UI.Controllers
{
    public class SurveyInformationController : Controller
    {
        private readonly ILogger<SurveyInformationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public SurveyInformationController(ILogger<SurveyInformationController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new DAL.SurveyContext());
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnswerSurvey(int id)
        {
            var surveyInformation = _unitOfWork.SurveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(id);
            if (surveyInformation.SurveyType == (int)SurveyType.Football)
            {
                return RedirectToAction("AnswerSurvey", "FootballSurveyInformation", new { id = surveyInformation.Id });

            }
            else
            {
                return RedirectToAction("AnswerSurvey", "HappinessSurveyInformation", new { id = surveyInformation.Id });

            }
        }
    }
}
