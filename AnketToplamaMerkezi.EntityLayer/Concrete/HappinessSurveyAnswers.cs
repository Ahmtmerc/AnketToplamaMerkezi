using System.ComponentModel.DataAnnotations.Schema;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class HappinessSurveyAnswers: BaseSurveyInformation
    {
        public int HappynessRate { get; set; }
        public string HappiestThing { get; set; }
        public string DisappointingThing { get; set; }
        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public SurveyInformation Survey { get; set; }

    }
}

