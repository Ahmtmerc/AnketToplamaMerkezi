namespace AnketToplamaMerkezi.EntityLayer.Abstract
{
    public interface IBaseSurveyInformation : IBaseTable
    {
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int PersonGender { get; set; }
        public DateTime PersonBirhDate { get; set; }
        public string Description { get; set; }

    }
}
