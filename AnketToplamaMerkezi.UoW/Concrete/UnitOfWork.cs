using AnketToplamaMerkezi.BusinessLayer.Abstract;
using AnketToplamaMerkezi.BusinessLayer.Concrete;
using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.EntityLayer.Concrete;
using AnketToplamaMerkezi.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.UoW.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private SurveyContext context;
        public UnitOfWork(SurveyContext context)
        {
            this.context = context;
            SurveyInformationBusiness = new SurveyInformationBusiness(this.context);
            FootballSurveyInformationBusiness = new FootballSurveyAnswersBusiness(this.context);
            HappinesSurveyInformationBusiness = new HappinessSurveyAnswersBusiness(this.context);
            SavedSurveysBusiness = new SavedSurveysBusiness(this.context);
        }

        public ISurveyInformationBusiness SurveyInformationBusiness { get; private set; }

        public IFootballSurveyInformationBusiness FootballSurveyInformationBusiness { get; private set; }

        public ISavedSurveysBusiness SavedSurveysBusiness { get; private set; }

        public IHappinessSurveyInformationBusiness HappinesSurveyInformationBusiness { get; private set; }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
