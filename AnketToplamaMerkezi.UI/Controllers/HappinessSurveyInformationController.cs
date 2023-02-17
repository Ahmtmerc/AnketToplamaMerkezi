using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using AnketToplamaMerkezi.UoW.Abstract;
using AnketToplamaMerkezi.UoW.Concrete;

namespace AnketToplamaMerkezi.UI.Controllers
{
    public class HappinessSurveyInformationController : Controller
    {
        private readonly ILogger<HappinessSurveyInformationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HappinessSurveyInformationController(ILogger<HappinessSurveyInformationController> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(new DAL.SurveyContext());
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OpenSurveyAnswers(int id)
        {
            HappinessSurveyAnswersModel happinessSurveyAnswers = new HappinessSurveyAnswersModel();
            HappinessSurveyAnswers happinessSurveyInformation = _unitOfWork.HappinesSurveyInformationBusiness.GetHappinessSurveyInformationDataWithSurveyInformationDataById(id);
            happinessSurveyAnswers.Id = happinessSurveyInformation.Id;
            happinessSurveyAnswers.SurveyId = happinessSurveyInformation.SurveyId;
            happinessSurveyAnswers.SurveyName = happinessSurveyInformation.Survey.SurveyName;
            happinessSurveyAnswers.PollsterName = happinessSurveyInformation.Survey.Pollster.PollsterName;
            happinessSurveyAnswers.PollsterSurname = happinessSurveyInformation.Survey.Pollster.PollsterSurname;
            happinessSurveyAnswers.PersonName = happinessSurveyInformation.PersonName;
            happinessSurveyAnswers.PersonGender = happinessSurveyInformation.PersonGender;
            happinessSurveyAnswers.PersonSurname = happinessSurveyInformation.PersonSurname;
            happinessSurveyAnswers.PersonBirhDate = happinessSurveyInformation.PersonBirhDate;
            happinessSurveyAnswers.Description = happinessSurveyInformation.Description;
            happinessSurveyAnswers.HappynessRate = happinessSurveyInformation.HappynessRate;
            happinessSurveyAnswers.HappiestThing = happinessSurveyInformation.HappiestThing;
            happinessSurveyAnswers.DisappointingThing = happinessSurveyInformation.DisappointingThing;
            return View(happinessSurveyAnswers);
        }

        [HttpGet]
        public IActionResult AnswerSurvey(int id)
        {
            HappinessSurveyAnswersModel happinessSurveyAnswers = new HappinessSurveyAnswersModel();
            SurveyInformation surveyInformation = _unitOfWork.SurveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(id);
            happinessSurveyAnswers.SurveyName = surveyInformation.SurveyName;
            happinessSurveyAnswers.SurveyId = surveyInformation.Id;
            happinessSurveyAnswers.PollsterName = surveyInformation.Pollster.PollsterName;
            happinessSurveyAnswers.PollsterSurname = surveyInformation.Pollster.PollsterSurname;

            return View(happinessSurveyAnswers);
        }

        [HttpPost]
        public IActionResult AnswerSurvey([FromForm] HappinessSurveyAnswersModel happinessSurveyAnswers)
        {
            var happinessSurveyAnswer = _unitOfWork.HappinesSurveyInformationBusiness.SaveHappinessSurveyInformation(happinessSurveyAnswers);
            _unitOfWork.Commit();
            _unitOfWork.SavedSurveysBusiness.SaveSurveyInformation(new SavedSurveyInformationModel
            {
                SurveyAnswersId = happinessSurveyAnswer.Id,
                SurveyInformationId = happinessSurveyAnswer.SurveyId,
                SurveyType = (int)SurveyType.Happiness,
                SystemDate = DateTime.Now
            });
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
            return RedirectToAction("Index", "SavedSurveyInformation");
        }

        [HttpGet]
        public IActionResult EditSurveyAnswers(int id)
        {
            HappinessSurveyAnswersModel happinessSurveyAnswers = new HappinessSurveyAnswersModel();
            HappinessSurveyAnswers happinessSurveyInformation = _unitOfWork.HappinesSurveyInformationBusiness.GetHappinessSurveyInformationDataWithSurveyInformationDataById(id);
            happinessSurveyAnswers.Id = happinessSurveyInformation.Id;
            happinessSurveyAnswers.SurveyId = happinessSurveyInformation.SurveyId;
            happinessSurveyAnswers.SurveyName = happinessSurveyInformation.Survey.SurveyName;
            happinessSurveyAnswers.PollsterName = happinessSurveyInformation.Survey.Pollster.PollsterName;
            happinessSurveyAnswers.PollsterSurname = happinessSurveyInformation.Survey.Pollster.PollsterSurname;
            happinessSurveyAnswers.PersonName = happinessSurveyInformation.PersonName;
            happinessSurveyAnswers.PersonGender = happinessSurveyInformation.PersonGender;
            happinessSurveyAnswers.PersonSurname = happinessSurveyInformation.PersonSurname;
            happinessSurveyAnswers.PersonBirhDate = happinessSurveyInformation.PersonBirhDate;
            happinessSurveyAnswers.Description = happinessSurveyInformation.Description;
            happinessSurveyAnswers.HappynessRate = happinessSurveyInformation.HappynessRate;
            happinessSurveyAnswers.HappiestThing = happinessSurveyInformation.HappiestThing;
            happinessSurveyAnswers.DisappointingThing = happinessSurveyInformation.DisappointingThing;
            return View(happinessSurveyAnswers);
        }

        [HttpPost]
        public IActionResult EditSurveyAnswers([FromForm] HappinessSurveyAnswersModel happinessSurveyAnswers)
        {
            _unitOfWork.HappinesSurveyInformationBusiness.EditHappinessSurveyInformation(happinessSurveyAnswers);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
            return RedirectToAction("Index", "SavedSurveyInformation");
        }





    }
}
