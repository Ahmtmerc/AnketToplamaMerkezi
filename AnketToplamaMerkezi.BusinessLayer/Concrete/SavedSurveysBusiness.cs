using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.Rep.Abstract;
using AnketToplamaMerkezi.Rep.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace AnketToplamaMerkezi.BusinessLayer.Concrete
{
    public class SavedSurveysBusiness : ISavedSurveysBusiness
    {
        private SurveyContext _context;
        private readonly SavedSurveysRep _savedSurveyRep;
        private readonly SurveyInformationBusiness _surveyInformationBusiness;
        private readonly FootballSurveyAnswersBusiness _footballSurveyAnswersBusiness;
        private readonly HappinessSurveyAnswersBusiness _happinessSurveyAnswersBusiness;
        public SavedSurveysBusiness(SurveyContext context)
        {
            _context = context;
            _savedSurveyRep = new SavedSurveysRep(_context);
            _surveyInformationBusiness = new SurveyInformationBusiness(_context);
            _footballSurveyAnswersBusiness = new FootballSurveyAnswersBusiness(_context);
            _happinessSurveyAnswersBusiness = new HappinessSurveyAnswersBusiness(_context);
        }

        public List<SavedSurveyInformationModel> GetSavedSurveyInformationList()
        {
            List<SavedSurveyInformationModel> list = new List<SavedSurveyInformationModel>();
            var surveys = _savedSurveyRep.List();
            foreach (var survey in surveys)
            {
                SavedSurveyInformationModel model = new SavedSurveyInformationModel();
                model.SurveyType = survey.SurveyType;
                //model.SurveyName = survey.SurveyName;
                model.Id = survey.Id;
                model.SystemDate = survey.SystemDate;
                list.Add(model);
            }
            return list;
        }

        public SavedSurveys GetSurveyDataWithSurveyInformationById(int savedSurveyId)
        {
            return _savedSurveyRep.Find(savedSurveyId);
        }

        public SavedSurveys SaveSurveyInformation(SavedSurveyInformationModel savedSurveyInformationModel)
        {
            SavedSurveys savedSurveys = new SavedSurveys();
            savedSurveys.SurveyInformationId = savedSurveyInformationModel.SurveyInformationId;
            savedSurveys.SurveyAnswersId = savedSurveyInformationModel.SurveyAnswersId;
            savedSurveys.SurveyType = savedSurveyInformationModel.SurveyType;
            savedSurveys.SystemDate = savedSurveyInformationModel.SystemDate;
            _savedSurveyRep.Add(savedSurveys);
            return savedSurveys;
        }

        public bool DeleteSurveyInformation(int id)
        {
            return _savedSurveyRep.Delete(id);
        }

        public List<SavedSurveyInformationModel> GetSurveyWithSurveyInformationList()
        {
            List<SavedSurveyInformationModel> savedSurveyInformations = new List<SavedSurveyInformationModel>();
            List<SavedSurveys> savedSurveys = _savedSurveyRep.List();
            foreach (SavedSurveys survey in savedSurveys)
            {
                SavedSurveyInformationModel savedSurveyInformationModel = new SavedSurveyInformationModel();
                savedSurveyInformationModel.Id = survey.Id;
                savedSurveyInformationModel.SurveyAnswersId = survey.SurveyAnswersId;
                savedSurveyInformationModel.SurveyInformationId = survey.SurveyInformationId;
                savedSurveyInformationModel.SystemDate = survey.SystemDate;
                savedSurveyInformationModel.SurveyType = survey.SurveyType;
                savedSurveyInformationModel.SurveyName = _surveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(survey.SurveyInformationId).SurveyName;
                savedSurveyInformations.Add(savedSurveyInformationModel);
            }
            return savedSurveyInformations;
          
        }
    }
}
