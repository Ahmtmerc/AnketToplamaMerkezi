using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.Rep.Abstract;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class FootballSurveyAnswersRep : BaseRepository<FootballSurveyAnswers>, IFootballSurveyAnswersRep
    {
        public FootballSurveyAnswersRep(SurveyContext db) : base(db)
        {

        }
    }




}
