using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
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
    public class SurveyInformationBusiness : ISurveyInformationBusiness
    {
        private SurveyContext _context;
        private readonly SurveyInformationRep _surveyInformationRep;
        private readonly PollsterInformationRep _pollsterInformationRep;
        public SurveyInformationBusiness(SurveyContext context)
        {
            _context = context;
            _surveyInformationRep = new SurveyInformationRep(_context);
            _pollsterInformationRep = new PollsterInformationRep(_context);
        }

        public List<SurveyInformationModel> GetSurveyInformationList()
        {
            List<SurveyInformationModel> list = new List<SurveyInformationModel>();
            var surveys = _surveyInformationRep.List();
            foreach (var survey in surveys)
            {
                SurveyInformationModel model = new SurveyInformationModel();
                model.SurveyType = survey.SurveyType;
                model.SurveyName = survey.SurveyName;
                model.Id = survey.Id;
                list.Add(model);
            }
            return list;
        }
        public SurveyInformation GetSurveyInformationDataWithPollsterInformationById(int surveyId)
        {
            SurveyInformation survey = _surveyInformationRep.Find(surveyId);
            var pollster = _pollsterInformationRep.Find(survey.PollsterId);
            survey.Pollster = pollster;
            return survey;
        }

    }
}
