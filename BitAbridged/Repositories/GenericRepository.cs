using BitAbridged.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;

namespace BitAbridged.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _dataContext = new ApplicationDbContext();

        /// <summary>
        /// Generic query method
        /// </summary>
        public IQueryable<T> Query<T>() where T : class
        {
            //Test jfizzys branch
            return _dataContext.Set<T>().AsQueryable();
        }


        /// <summary>
        /// Non Generic query method
        /// Use model type name instead of model type
        /// </summary>
        public IQueryable Query(string entityTypeName)
        {
            var entityType = Type.GetType(entityTypeName);
            return _dataContext.Set(entityType).AsQueryable();
        }


        /// <summary>
        /// Find row by id
        /// </summary>
        public T Find<T>(params object[] keyValues) where T : class
        {
            return _dataContext.Set<T>().Find(keyValues);
        }


        /// <summary>
        /// Add new entity
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class
        {
            _dataContext.Set<T>().Add(entityToCreate);
        }


        public void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = Find<T>(keyValues);
            _dataContext.Set<T>().Remove(entity);
        }


        /// <summary>
        /// Save changes and throw validation exceptions
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _dataContext.SaveChanges();
            }
            catch (DbEntityValidationException dbVal)
            {
                var firstError = dbVal.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }


        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return _dataContext.Database.SqlQuery<T>(sql, parameters);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
