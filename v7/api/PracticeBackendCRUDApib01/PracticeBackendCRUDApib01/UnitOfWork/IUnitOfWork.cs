namespace PracticeBackendCRUDApib01.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        Task<bool> SaveAsync();

        Task<int> SaveAsync2();
    }
}
