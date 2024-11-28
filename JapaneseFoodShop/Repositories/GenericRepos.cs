using System.Linq.Expressions;
using JapaneseFoodShop.Data;
using JapaneseFoodShop.DTOs;
using JapaneseFoodShop.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace JapaneseFoodShop.Repositories
{
    public class GenericRepos<TEntity, TKey> : IGenericRepos<TEntity, TKey>
        where TEntity : class
    {
        public readonly AppDbContext _db;

        public GenericRepos(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> CreateMultipleAsync(IEnumerable<TEntity> entities)
        {
            await _db.Set<TEntity>().AddRangeAsync(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task UpdateMultipleAsync(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().UpdateRange(entities);
            await _db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task DeleteMultipleAsync(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
            await _db.SaveChangesAsync();
        }


        public virtual async Task<TEntity> FindByIdAsync(TKey id)
        {
            var result = await _db.Set<TEntity>().FindAsync(id);
            return result ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _db.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return result ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            List<TEntity> data;
            if (predicate == null)
            {
                data = await _db.Set<TEntity>().ToListAsync();
            }
            else
            {
                data = await _db.Set<TEntity>().Where(predicate).ToListAsync();
            }
            return data ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }

        public virtual async Task<PaginingResult<TEntity>> GetAllAsync(int pageSize = 10, int pageNum = 1, Expression<Func<TEntity, bool>> predicate = null!)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var totalItems = await query.CountAsync();

            var data = await query
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return new PaginingResult<TEntity>
            {
                Data = data,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            } ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }
    }
}
