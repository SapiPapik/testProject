using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BLL.Contracts.Dtos;

namespace TestProject.BLL.Contracts.Contracts {
    public interface IStudentService {
        Task<ICollection<StudentDto>> GetAllAsync();
        Task<StudentDto> GetByIdAsync(Guid id);
        Task AddAsync(StudentDto group);
        Task UpdateAsync(Guid id, StudentDto group);
        Task RemoveAsync(Guid id);
    }
}
