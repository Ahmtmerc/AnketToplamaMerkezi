using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketToplamaMerkezi.Rep.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T> List();

        public T Find(int Id);

        public T Find(string Id);

        public T Update(T entity);

        public bool Delete(int Id);

        public bool Delete(string Id);

        public T Add(T entity);

        public DbSet<T> Set();
    }


}
