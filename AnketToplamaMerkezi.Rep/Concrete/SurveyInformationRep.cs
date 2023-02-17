using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.Rep.Abstract;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class SurveyInformationRep : BaseRepository<SurveyInformation>, ISurveyInformationRep
    {
        public SurveyInformationRep(SurveyContext db) : base(db)
        {

        }
    }

}
