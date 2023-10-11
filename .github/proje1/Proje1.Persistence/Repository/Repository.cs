
using Microsoft.EntityFrameworkCore;
using Proje1.Domain.Common;
using Proje1.Domain.Repositories;
using Proje1.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public Repository(ProjeContext context)
        {
            _dbSet= context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAllAsync(params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;
            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)              
                {
                    query = _dbSet.Include(includeColumn);
                }
            }
            return await Task.FromResult(query);
        }

        public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;
            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = _dbSet.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<T> GetById(object id)
        {

            var item =await _dbSet.FindAsync(id);
            return item;
        }

        public async Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;
            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = _dbSet.Include(includeColumn);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }



        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
        }

        
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
