using AnketToplamaMerkezi.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
    //    IFootballSurveyAnswersRep FootballSurveyAnswersRep { get; }
    //    IHappinessSurveyAnswersRep HappinessSurveyAnswersRep { get; }
    //    ISavedSurveysRep SavedSurveysRep { get; }
        ISurveyInformationBusiness SurveyInformationBusiness { get; }
        ISavedSurveysBusiness SavedSurveysBusiness { get; }
        IFootballSurveyInformationBusiness FootballSurveyInformationBusiness { get; }
        IHappinessSurveyInformationBusiness HappinesSurveyInformationBusiness { get; }
        int Commit();
    }
}
