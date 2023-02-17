using AnketToplamaMerkezi.EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class SavedSurveys : BaseEntity
    {
        public int SurveyInformationId { get; set; }
        public int SurveyAnswersId { get; set; }
        public int SurveyType { get; set; }
        public DateTime SystemDate { get; set; }
    }
}

