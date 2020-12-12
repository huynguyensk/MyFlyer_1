using Microsoft.EntityFrameworkCore;
using MyFlyer.Data;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyFlyer.Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            if (entity.Id == 0)
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
            }
            return entity;
        }
        public void Update(T entity)
        {
            var existingEntity = _dbContext.Set<T>().Find(entity.Id);
            if (existingEntity == null)
            {
                Add(entity);
            }
            else
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public bool Any(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Any(where);
        }
        public int Count(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).Count();
        }
        public List<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return _dbContext.Set<T>().Where(condition).ToList();
        }

        public bool IsExist(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Any(where);
        }
    }
}
