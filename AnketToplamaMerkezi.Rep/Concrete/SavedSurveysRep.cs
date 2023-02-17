using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.Rep.Abstract;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class SavedSurveysRep: BaseRepository<SavedSurveys>, ISavedSurveysRep
    {
        public SavedSurveysRep(SurveyContext db) : base(db)
        {

        }

    }

}
