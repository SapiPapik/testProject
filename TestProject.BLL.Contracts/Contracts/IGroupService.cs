using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.Contracts.Dtos;

namespace TestProject.BLL.Contracts.Contracts {
    public interface IGroupService {
        Task<ICollection<GroupDto>> GetAllAsync();
        Task<GroupDto> GetByIdAsync(Guid id);
        Task AddStudentToGroup(Guid groupId, StudentDto student);
        Task AddAsync(GroupDto group);
        Task UpdateAsync(Guid id, GroupDto group);
        Task RemoveStudentFromGroup(Guid groupId, Guid studentId);
        Task RemoveAsync(Guid id);
    }
}
