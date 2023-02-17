using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.EntityLayer.Concrete.Model
{
    public class SurveyStatisticsModel
    {
        public List<SurveyAnswersStatisticsModel> FootBallSurveyAnswersStatistics { get; set; }
        public List<SurveyAnswersStatisticsModel> HappinessSurveyAnswersStatistics { get; set; }
    }
}
