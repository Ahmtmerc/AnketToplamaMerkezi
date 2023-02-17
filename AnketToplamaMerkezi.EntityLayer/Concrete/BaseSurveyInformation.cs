using AnketToplamaMerkezi.EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AnketToplamaMerkezi.EntityLayer.Concrete
{
    public class BaseSurveyInformation : IBaseSurveyInformation
    {
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int PersonGender { get; set; }
        public DateTime PersonBirhDate { get; set; }
        public string Description { get; set; }
    }
}

