using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.Rep.Abstract;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class HappinessSurveyAnswersRep: BaseRepository<HappinessSurveyAnswers>, IHappinessSurveyAnswersRep
    {
        public HappinessSurveyAnswersRep(SurveyContext db) : base(db)
        {

        }
    }




}
