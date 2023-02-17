using AnketToplamaMerkezi.EntityLayer.Concrete.Enum;

namespace AnketToplamaMerkezi.EntityLayer.Concrete.Model
{
    public class FootballSurveyAnswersModel
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int PersonGender { get; set; }
        public DateTime PersonBirhDate { get; set; }
        public string Description { get; set; }
        public int FavoriteTeam { get; set; }
        public string PollsterName { get; set; }
        public string PollsterSurname { get; set; }

    }
}
