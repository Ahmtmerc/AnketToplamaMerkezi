using System.ComponentModel.DataAnnotations.Schema;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class FootballSurveyAnswers: BaseSurveyInformation
    {
        public int FavoriteTeam { get; set; }
        public int SurveyId { get; set; }


        [ForeignKey("SurveyId")]
        public SurveyInformation Survey { get; set; }
    }
}

