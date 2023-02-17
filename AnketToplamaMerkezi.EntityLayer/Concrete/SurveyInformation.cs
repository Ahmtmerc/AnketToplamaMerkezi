using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class SurveyInformation : BaseEntity
    {
        public string SurveyName { get; set; }

        public int PollsterId { get; set; }


        [ForeignKey("PollsterId")]
        public PollsterInformation Pollster { get; set; }

        public int SurveyType { get; set; }

    }
}
