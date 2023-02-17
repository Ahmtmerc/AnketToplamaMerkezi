using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.UoW.Abstract;
using AnketToplamaMerkezi.UoW.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AnketToplamaMerkezi.UI.Controllers
{
    public class FootballSurveyInformationController : Controller
    {
        private readonly ILogger<FootballSurveyInformationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public FootballSurveyInformationController(ILogger<FootballSurveyInformationController> logger)
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
            FootballSurveyAnswersModel footballSurveyAnswers = new FootballSurveyAnswersModel();
            FootballSurveyAnswers footballSurveyInformation = _unitOfWork.FootballSurveyInformationBusiness.GetFootballSurveyInformationDataWithSurveyInformationDataById(id);
            footballSurveyAnswers.Id = footballSurveyInformation.Id;
            footballSurveyAnswers.SurveyId = footballSurveyInformation.SurveyId;
            footballSurveyAnswers.SurveyName = footballSurveyInformation.Survey.SurveyName;
            footballSurveyAnswers.PollsterName = footballSurveyInformation.Survey.Pollster.PollsterName;
            footballSurveyAnswers.PollsterSurname = footballSurveyInformation.Survey.Pollster.PollsterSurname;
            footballSurveyAnswers.PersonName = footballSurveyInformation.PersonName;
            footballSurveyAnswers.PersonGender = footballSurveyInformation.PersonGender;
            footballSurveyAnswers.PersonSurname = footballSurveyInformation.PersonSurname;
            footballSurveyAnswers.PersonBirhDate = footballSurveyInformation.PersonBirhDate;
            footballSurveyInformation.Description = footballSurveyInformation.Description;
            footballSurveyAnswers.FavoriteTeam = footballSurveyInformation.FavoriteTeam;
            return View(footballSurveyAnswers);
        }

        [HttpGet]
        public IActionResult AnswerSurvey(int id)
        {
            FootballSurveyAnswersModel footballSurveyAnswers = new FootballSurveyAnswersModel();
            SurveyInformation surveyInformation = _unitOfWork.SurveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(id);
            footballSurveyAnswers.SurveyName = surveyInformation.SurveyName;
            footballSurveyAnswers.SurveyId = surveyInformation.Id;
            footballSurveyAnswers.PollsterName = surveyInformation.Pollster.PollsterName;
            footballSurveyAnswers.PollsterSurname = surveyInformation.Pollster.PollsterSurname;

            return View(footballSurveyAnswers);
        }

        [HttpPost]
        public IActionResult AnswerSurvey([FromForm] FootballSurveyAnswersModel footballSurveyAnswers) 
        {
            var footballSurveyAnswer = _unitOfWork.FootballSurveyInformationBusiness.SaveFootBallSurveyInformation(footballSurveyAnswers);
            _unitOfWork.Commit();
            _unitOfWork.SavedSurveysBusiness.SaveSurveyInformation(new SavedSurveyInformationModel
            {
                SurveyAnswersId = footballSurveyAnswer.Id,
                SurveyInformationId = footballSurveyAnswer.SurveyId,
                SurveyType = (int)SurveyType.Football,
                SystemDate = DateTime.Now
            });
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
            return RedirectToAction("Index", "SavedSurveyInformation");
        }

        [HttpGet]
        public IActionResult EditSurveyAnswers(int id)
        {
            FootballSurveyAnswersModel footballSurveyAnswers = new FootballSurveyAnswersModel();
            FootballSurveyAnswers footballSurveyInformation = _unitOfWork.FootballSurveyInformationBusiness.GetFootballSurveyInformationDataWithSurveyInformationDataById(id);
            footballSurveyAnswers.Id = footballSurveyInformation.Id;
            footballSurveyAnswers.SurveyId = footballSurveyInformation.SurveyId;
            footballSurveyAnswers.SurveyName = footballSurveyInformation.Survey.SurveyName;
            footballSurveyAnswers.PollsterName = footballSurveyInformation.Survey.Pollster.PollsterName;
            footballSurveyAnswers.PollsterSurname = footballSurveyInformation.Survey.Pollster.PollsterSurname;
            footballSurveyAnswers.PersonName = footballSurveyInformation.PersonName;
            footballSurveyAnswers.PersonGender = footballSurveyInformation.PersonGender;
            footballSurveyAnswers.PersonSurname = footballSurveyInformation.PersonSurname;
            footballSurveyAnswers.PersonBirhDate = footballSurveyInformation.PersonBirhDate;
            footballSurveyAnswers.Description = footballSurveyInformation.Description;
            footballSurveyAnswers.FavoriteTeam = footballSurveyInformation.FavoriteTeam;
            return View(footballSurveyAnswers);
        }

        [HttpPost]
        public IActionResult EditSurveyAnswers([FromForm] FootballSurveyAnswersModel footballSurveyAnswers)
        {
            _unitOfWork.FootballSurveyInformationBusiness.EditFootBallSurveyInformation(footballSurveyAnswers);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
            return RedirectToAction("Index", "SavedSurveyInformation");
        }
    }
}
