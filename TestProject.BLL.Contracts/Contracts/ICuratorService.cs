using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.Contracts.Dtos;

namespace TestProject.BLL.Contracts.Contracts {
    public interface ICuratorService {
        Task<IEnumerable<CuratorDto>> GetAllAsync();
        Task<CuratorDto> GetByIdAsync(Guid id);
        Task AddCuratorToGroup(Guid curatorId, Guid groupId);
        Task AddAsync(CuratorDto group);
        Task UpdateAsync(Guid id, CuratorDto group);
        Task RemoveCuratorFromGroup(Guid curatorId, Guid groupId);
        Task RemoveAsync(Guid id);
    }
}
