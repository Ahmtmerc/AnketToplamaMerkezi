using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.EntityLayer.Concrete.Model
{
    public  class SurveyInformationDTO
    {
        public List<SurveyInformationModel> SurveyInformations { get; set; }
        public SurveyStatisticsModel SurveyStatistics { get; set; }
    }
}
