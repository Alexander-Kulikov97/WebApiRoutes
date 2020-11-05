using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiRoutes.Context.Internals;

namespace WebApiRoutes.Context
{
    public class RepositoryBase : IRepository
    {
        #region Private fields

        protected readonly DbContext _context;

        #endregion

        #region Constructor

        public RepositoryBase(DbContext context) => _context = context;

        #endregion

        #region Private methods

        private DbSet<T> DbSet<T>() where T : class => _context.Set<T>();

        #endregion

        #region IInternalRepository

        #region Add

        void IInternalRepository.Add<T>(T entity)
        {
            if (entity == null) throw new Exception("entities cannot be null");
            _context.Add(entity);
        }

        void IInternalRepository.Add<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        void IInternalRepository.Add<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        void IInternalRepository.Add<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.AddRange(entities);
        }

        #endregion

        #region Update

        void IInternalRepository.Update<T>(T entity)
        {
            if (entity == null) throw new Exception("entities cannot be null");
            _context.Update(entity);
        }

        void IInternalRepository.Update<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        void IInternalRepository.Update<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        void IInternalRepository.Update<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.UpdateRange(entities);
        }

        #endregion

        #region Remove

        void IInternalRepository.Remove<T>(T entity)
        {
            if (entity == null) throw new Exception("entity cannot be null");
            _context.Remove(entity);
        }

        void IInternalRepository.Remove<T>(List<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(IEnumerable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(IQueryable<T> entities)
        {
            if (entities == null) throw new Exception("entities cannot be null");
            _context.RemoveRange(entities);
        }

        void IInternalRepository.Remove<T>(int id)
        {
            var entityToRemove = DbSet<T>().Find(id);
            if (entityToRemove == null) return;
            _context.Remove(entityToRemove);
        }

        void IInternalRepository.Remove<T>(Expression<Func<T, bool>> predicate)
        {
            var entitiesToRemove = DbSet<T>().Where(predicate);
            if (!entitiesToRemove.Any()) return;
            _context.RemoveRange(entitiesToRemove);
        }

        #endregion

        #endregion

        #region IUnitOfWork

        int IUnitOfWork.SaveChanges() => _context.SaveChanges();

        Task<int> IUnitOfWork.SaveChangesAsync() => _context.SaveChangesAsync();

        #endregion

        #region IReadOnlyRepository

        T IReadonlyRepository.FirstOrDefault<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.FirstOrDefault(predicate);
        }

        T IReadonlyRepository.Find<T>(int id)
        {
            return DbSet<T>()?.Find(id);
        }

        IEnumerable<T> IReadonlyRepository.AsEnumerable<T>()
        {
            return DbSet<T>()?.AsEnumerable();
        }

        IQueryable<T> IReadonlyRepository.AsQueryable<T>()
        {
            return DbSet<T>()?.AsQueryable();
        }

        List<T> IReadonlyRepository.ToList<T>()
        {
            return DbSet<T>()?.ToList();
        }

        int IReadonlyRepository.Count<T>()
        {
            return DbSet<T>()?.Count() ?? 0;
        }

        bool IReadonlyRepository.Exists<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Any(predicate) ?? false;
        }

        #endregion


        T IReadonlyRepository.FirstOrDefault<T>()
        {
            return DbSet<T>()?.FirstOrDefault();
        }

        IQueryable<T> IReadonlyRepository.Where<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Where(predicate);
        }

        bool IReadonlyRepository.Any<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>().Any(predicate);
        }

        int IReadonlyRepository.Count<T>(Expression<Func<T, bool>> predicate)
        {
            return DbSet<T>()?.Count(predicate) ?? 0;
        }
    }
}
