using System;
using System.Collections.Generic;
using MyFlyer.Model.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace MyFlyer.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int Count(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        List<T> GetByCondition(Expression<Func<T, bool>> condition);        
    }
}