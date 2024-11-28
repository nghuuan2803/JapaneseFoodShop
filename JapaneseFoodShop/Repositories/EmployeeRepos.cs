using System.Linq;
using System.Linq.Expressions;
using JapaneseFoodShop.Data;
using JapaneseFoodShop.Entities;
using JapaneseFoodShop.DTOs;
using JapaneseFoodShop.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace JapaneseFoodShop.Repositories
{
    public class EmployeeRepos : GenericRepos<Employee, string>, IEmployeeRepos
    {
        public EmployeeRepos(AppDbContext db) : base(db)
        {
        }

        public override async Task<Employee> GetAsync(Expression<Func<Employee, bool>> predicate)
        {
            var result = await _db.Set<Employee>().Include(p => p.User).FirstOrDefaultAsync(predicate);
            return result ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }

        public async override Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> predicate = null!)
        {
            List<Employee> data;
            if (predicate == null)
            {
                data = await _db.Set<Employee>().Include(p => p.User).ToListAsync();
            }
            else
            {
                data = await _db.Set<Employee>().Where(predicate).Include(p => p.User).ToListAsync();
            }
            return data ?? throw new KeyNotFoundException("Không tìm thấy kết quả");

        }

        public async override Task<PaginingResult<Employee>> GetAllAsync(int pageSize = 10, int pageNum = 1, Expression<Func<Employee, bool>> predicate = null!)
        {
            var query = _db.Set<Employee>().AsQueryable().Include(p => p.User);
            if (predicate != null)
            {
                query = query.Where(predicate).Include(p => p.User);
            }
            var totalItems = await query.CountAsync();

            var data = await query
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return new PaginingResult<Employee>
            {
                Data = data,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            } ?? throw new KeyNotFoundException("Không tìm thấy kết quả");
        }
    }
}
