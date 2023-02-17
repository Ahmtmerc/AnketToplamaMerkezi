using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.EntityLayer.Concrete.Model
{
    public class SavedSurveyInformationModel
    {
        public int Id { get; set; }
        public int SurveyInformationId { get; set; }
        public int SurveyAnswersId { get; set; }
        public string SurveyName { get; set; }
        public int SurveyType { get; set; }

        public DateTime SystemDate { get; set; }
    }
}
