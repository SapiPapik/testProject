using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.DAL.Contract {
    public interface IUnitOfWork {
        IBaseRepository<T> GetRepository<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();
        bool AutoDetectChanges { get; set; }
        List<T> ExecuteStoredProcedure<T>(string procedureName);
    }
}
