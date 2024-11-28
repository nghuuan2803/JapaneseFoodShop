using System.Linq.Expressions;
using JapaneseFoodShop.Entities;
using JapaneseFoodShop.DTOs;

namespace JapaneseFoodShop.Repositories.Abstracts
{
    public interface IGenericRepos<TEntity, TKey>
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> CreateMultipleAsync(IEnumerable<TEntity> entities);
        Task UpdateMultipleAsync(IEnumerable<TEntity> entities);
        Task DeleteMultipleAsync(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null!);
        Task<PaginingResult<TEntity>> GetAllAsync(int pageSize = 10, int pageNum = 1, Expression<Func<TEntity, bool>> predicate = null!);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByIdAsync(TKey id);
    }
}
