using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.EntityLayer.Concrete.Model;

namespace AnketToplamaMerkezi.BusinessLayer.Abstract
{
    public interface ISavedSurveysBusiness
    {
        public List<SavedSurveyInformationModel> GetSavedSurveyInformationList();
        public List<SavedSurveyInformationModel> GetSurveyWithSurveyInformationList();
        public SavedSurveys GetSurveyDataWithSurveyInformationById(int savedSurveyId);
        public SavedSurveys SaveSurveyInformation(SavedSurveyInformationModel savedSurveyInformationModel);
        public bool DeleteSurveyInformation(int id);

    }


}
