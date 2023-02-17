using AnketToplamaMerkezi.DAL;
using AnketToplamaMerkezi.Rep.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.Rep.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        SurveyContext _db;
        public BaseRepository(SurveyContext db)
        {
            _db = db;
        }
        public T Add(T entity)
        {

            try
            {
                Set().Add(entity);
                return entity;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                //var ent = Find(Id);
                //Set().Remove(ent);
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string Id)
        {
            try
            {
                //var ent = Find(Id);
                //Set().Remove(ent);
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(string Id)
        {
            return Set().Find(Id);
        }
        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public T Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return entity;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }

}
