using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;

namespace AnketToplamaMerkezi.BusinessLayer.Abstract
{
    public interface IFootballSurveyInformationBusiness
    {
        public List<FootballSurveyAnswers> GetFootballSurveyInformationList();
        public FootballSurveyAnswers GetFootballSurveyInformationDataWithSurveyInformationDataById(int footballSurveyInformationId);
        public FootballSurveyAnswers SaveFootBallSurveyInformation(FootballSurveyAnswersModel footballSurveyAnswers);
        public FootballSurveyAnswers EditFootBallSurveyInformation(FootballSurveyAnswersModel footballSurvey);
    }

}
