using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;

namespace AnketToplamaMerkezi.BusinessLayer.Abstract
{
    public interface IHappinessSurveyInformationBusiness
    {
        public List<HappinessSurveyAnswers> GetHappinessSurveyInformationList();
        public HappinessSurveyAnswers GetHappinessSurveyInformationDataWithSurveyInformationDataById(int happinessSurveyInformationId);
        public HappinessSurveyAnswers SaveHappinessSurveyInformation(HappinessSurveyAnswersModel happinessSurveyAnswers);
        public HappinessSurveyAnswers EditHappinessSurveyInformation(HappinessSurveyAnswersModel happinessSurvey);
    }

}
