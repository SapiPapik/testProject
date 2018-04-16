using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.DAL.Contracts;

namespace TestPrject.DAL.Contract
{
    public interface IUnitOfWork
    {
        IGlobalRepository<T> GetRepository<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
        bool AutoDetectChanges { get; set; }
    }
}
