using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.BusinessLayer.Abstract
{
    public interface ISurveyInformationBusiness
    {
        public List<SurveyInformationModel> GetSurveyInformationList();
        public SurveyInformation GetSurveyInformationDataWithPollsterInformationById(int surveyId);
    }


}
