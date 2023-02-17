using AnketToplamaMerkezi.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class PollsterInformation : BaseEntity
    {
        public string PollsterName { get; set; }
        public string PollsterSurname { get; set; }

        public ICollection<SurveyInformation> Surveys { get; set; }

    }

}

