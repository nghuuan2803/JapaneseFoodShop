namespace JapaneseFoodShop.Repositories.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollBackAsync();
        Task SaveChangesAsync();
    }
}
