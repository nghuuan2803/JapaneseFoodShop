using JapaneseFoodShop.Data;
using JapaneseFoodShop.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace JapaneseFoodShop.Repositories
{
    public class UnitOfWork(AppDbContext _db) : IUnitOfWork
    {
        private IDbContextTransaction _transaction = null!;

        public async Task BeginAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
            DisposeTransaction();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null!;
            }
        }
        public void Dispose()
        {
            DisposeTransaction();
            _db.Dispose();
        }
    }
}
