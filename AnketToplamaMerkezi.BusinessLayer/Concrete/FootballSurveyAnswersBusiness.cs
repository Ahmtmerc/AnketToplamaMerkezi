using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using AnketToplamaMerkezi.Rep.Abstract;
using AnketToplamaMerkezi.Rep.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.BusinessLayer.Concrete
{
    public class FootballSurveyAnswersBusiness : IFootballSurveyInformationBusiness
    {
        private SurveyContext _context;
        private readonly SurveyInformationBusiness _surveyInformationBusiness;
        private readonly PollsterInformationRep _pollsterInformationRep;
        private readonly FootballSurveyAnswersRep _footballSurveyAnswersRep;
        private readonly SavedSurveysBusiness _savedSurveysBusiness;
        public FootballSurveyAnswersBusiness(SurveyContext context)
        {
            _context = context;
            _surveyInformationBusiness = new SurveyInformationBusiness(_context);
            _savedSurveysBusiness = new SavedSurveysBusiness(_context);
            _footballSurveyAnswersRep = new FootballSurveyAnswersRep(_context);
            _pollsterInformationRep = new PollsterInformationRep(_context);
        }

        public List<FootballSurveyAnswers> GetFootballSurveyInformationList()
        {
            return _footballSurveyAnswersRep.List();
        }

        public FootballSurveyAnswers GetFootballSurveyInformationDataWithSurveyInformationDataById(int footballSurveyInformationId)
        {
            FootballSurveyAnswers footballSurvey = _footballSurveyAnswersRep.Find(footballSurveyInformationId);
            var surveyInformation = _surveyInformationBusiness.GetSurveyInformationDataWithPollsterInformationById(footballSurvey.SurveyId);
            footballSurvey.Survey = surveyInformation;
            return footballSurvey;
        }

        public FootballSurveyAnswers SaveFootBallSurveyInformation(FootballSurveyAnswersModel footballSurveyAnswers)
        {
            FootballSurveyAnswers footballSurvey = new FootballSurveyAnswers();
            footballSurvey.SurveyId = footballSurveyAnswers.SurveyId;
            footballSurvey.Description = footballSurveyAnswers.Description;
            footballSurvey.PersonBirhDate = footballSurveyAnswers.PersonBirhDate;
            footballSurvey.PersonSurname = footballSurveyAnswers.PersonSurname;
            footballSurvey.PersonName = footballSurveyAnswers.PersonName;
            footballSurvey.PersonGender = footballSurveyAnswers.PersonGender;
            footballSurvey.FavoriteTeam = footballSurveyAnswers.FavoriteTeam;
            _footballSurveyAnswersRep.Add(footballSurvey);
            return footballSurvey;
        }

        public FootballSurveyAnswers EditFootBallSurveyInformation(FootballSurveyAnswersModel footballSurvey)
        {
            FootballSurveyAnswers footballSurveyAnswers = new FootballSurveyAnswers();
            footballSurveyAnswers.Id = footballSurvey.Id;
            footballSurveyAnswers.SurveyId = footballSurvey.SurveyId;
            footballSurveyAnswers.PersonName = footballSurvey.PersonName;
            footballSurveyAnswers.PersonGender = footballSurvey.PersonGender;
            footballSurveyAnswers.PersonSurname = footballSurvey.PersonSurname;
            footballSurveyAnswers.PersonBirhDate = footballSurvey.PersonBirhDate;
            footballSurveyAnswers.Description = footballSurvey.Description;
            footballSurveyAnswers.FavoriteTeam = footballSurveyAnswers.FavoriteTeam;

            _footballSurveyAnswersRep.Update(footballSurveyAnswers);
            return footballSurveyAnswers;
        }
    }
}

