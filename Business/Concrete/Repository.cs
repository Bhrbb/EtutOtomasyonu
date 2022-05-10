using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;
using Business.Abstract;

namespace Business.Concrete
{
    public class Repository<T> : IRepository<T> where T:class,IEntity
        ,new()
    {
         private DataContext context;
         private DbSet<T> _objectset;
        public Repository()
        {
            if (context==null)
            {
                context = new DataContext();
                _objectset=context.Set<T>();
            }
        }
        public int Add(T entity)
        {
            _objectset.Add(entity);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            _objectset.Remove(Get(id));
            return context.SaveChanges();

        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return _objectset.FirstOrDefault(expression);
        }

        public T Get(int id)
        {
            return _objectset.Find(id);
        }

        public List<T> GetAll()
        {
            return _objectset.ToList();
        }

        public List<T> GetAll1(Expression<Func<T, bool>> expression)
        {
            return _objectset.Where(expression).ToList();
        }

        public int Update(T entity)
        {
            _objectset.AddOrUpdate(entity);
            return context.SaveChanges();
        }
    }
}
