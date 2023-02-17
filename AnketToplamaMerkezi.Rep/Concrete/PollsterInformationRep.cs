using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.Rep.Abstract;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class PollsterInformationRep : BaseRepository<PollsterInformation>, IPollsterInformationRep
    {
        public PollsterInformationRep(SurveyContext db) : base(db)
        {

        }

    }

}
