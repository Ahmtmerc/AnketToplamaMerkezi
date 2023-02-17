using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.Rep.Abstract;
using AnketToplamaMerkezi.Rep.Concrete;

namespace AnketToplamaMerkezi.BusinessLayer.Concrete
{
    public class HappinessSurveyAnswersBusiness : IHappinessSurveyInformationBusiness
    {
        private SurveyContext _context;
        private readonly SurveyInformationBusiness _surveyInformationBusiness;
        private readonly PollsterInformationRep _pollsterInformationRep;
        private readonly HappinessSurveyAnswersRep _happinessSurveyAnswersRep;
        public HappinessSurveyAnswersBusiness(SurveyContext context)
        {
            _context = context;
            _surveyInformationBusiness = new SurveyInformationBusiness(_context);
            _happinessSurveyAnswersRep = new HappinessSurveyAnswersRep(_context);
            _pollsterInformationRep = new PollsterInformationRep(_context);
        }

        public List<HappinessSurveyAnswers> GetHappinessSurveyInformationList()
        {
            return _happinessSurveyAnswersRep.List();
        }

        public HappinessSurveyAnswers GetHappinessSurveyInformationDataWithSurveyInformationDataById(int happinessSurveyInformationId)
        {
            HappinessSurveyAnswers happinessSurvey = _happinessSurveyAnswersRep.Find(happinessSurveyInformationId);
            var surveyInformation = _surveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(happinessSurvey.SurveyId);
            happinessSurvey.Survey = surveyInformation;
            return happinessSurvey;
        }

        public HappinessSurveyAnswers SaveHappinessSurveyInformation(HappinessSurveyAnswersModel happinessSurveyAnswers)
        {
            HappinessSurveyAnswers happinessSurvey = new HappinessSurveyAnswers();
            happinessSurvey.SurveyId = happinessSurveyAnswers.SurveyId;
            happinessSurvey.Description = happinessSurveyAnswers.Description;
            happinessSurvey.PersonBirhDate = happinessSurveyAnswers.PersonBirhDate;
            happinessSurvey.PersonSurname = happinessSurveyAnswers.PersonSurname;
            happinessSurvey.PersonName = happinessSurveyAnswers.PersonName;
            happinessSurvey.PersonGender = happinessSurveyAnswers.PersonGender;
            happinessSurvey.HappynessRate = happinessSurveyAnswers.HappynessRate;
            happinessSurvey.DisappointingThing = happinessSurveyAnswers.DisappointingThing;
            happinessSurvey.HappiestThing = happinessSurveyAnswers.HappiestThing;
            _happinessSurveyAnswersRep.Add(happinessSurvey);
            return happinessSurvey;
        }

        public HappinessSurveyAnswers EditHappinessSurveyInformation(HappinessSurveyAnswersModel happinessSurvey)
        {
            HappinessSurveyAnswers happinessSurveyAnswers = new HappinessSurveyAnswers();
            happinessSurveyAnswers.Id = happinessSurvey.Id;
            happinessSurveyAnswers.SurveyId = happinessSurvey.SurveyId;
            happinessSurveyAnswers.PersonGender = happinessSurvey.PersonGender;
            happinessSurveyAnswers.PersonSurname = happinessSurvey.PersonSurname;
            happinessSurveyAnswers.PersonBirhDate = happinessSurvey.PersonBirhDate;
            happinessSurveyAnswers.Description = happinessSurvey.Description;
            happinessSurveyAnswers.HappynessRate = happinessSurvey.HappynessRate;
            happinessSurveyAnswers.HappiestThing = happinessSurvey.HappiestThing;
            happinessSurveyAnswers.DisappointingThing = happinessSurvey.DisappointingThing;

            _happinessSurveyAnswersRep.Update(happinessSurveyAnswers);
            return happinessSurveyAnswers;
        }

    }

}
