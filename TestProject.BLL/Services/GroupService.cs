using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestProject.DAL.Contract;
using TestProject.BLL.Contracts.Contracts;
using TestProject.BLL.Contracts.Dtos;
using TestProject.BLL.Exceptions;
using TestProject.Data.Entity;

namespace TestProject.BLL.Services {
    public class GroupService : BaseService, IGroupService {

        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public async Task<ICollection<GroupDto>> GetAllAsync() {
            var groups = await UnitOfWork.GetRepository<Group>().AllIncluding(g => g.Curator, g => g.Students).Where(g => !g.IsArchive).ToListAsync();
            return Mapper.Map<ICollection<GroupDto>>(groups);
        }

        public async Task<GroupDto> GetByIdAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var group = await UnitOfWork.GetRepository<Group>().FindByIdAsync(id);
            if (group == null || group.IsArchive) {
                throw new NotFoundException($"Group with id = {id} not found.");
            }

            return Mapper.Map<GroupDto>(group);
        }

        public async Task AddStudentToGroup(Guid groupId, StudentDto student) {
            if (groupId == Guid.Empty) {
                throw new ArgumentNullException(nameof(groupId));
            }

            if (student == null) {
                throw new ArgumentNullException(nameof(student));
            }

            var entity = await UnitOfWork.GetRepository<Student>().FindByIdAsync(student.Id);
            if (entity != null && !entity.IsArchive) {
                entity.GroupId = groupId;
                UnitOfWork.GetRepository<Student>().Update(entity);
            }
            else {
                entity = Mapper.Map<Student>(student);
                entity.GroupId = groupId;
                UnitOfWork.GetRepository<Student>().Add(entity);
            }

            await UnitOfWork.CommitAsync();
        }

        public async Task AddAsync(GroupDto group) {
            if (group == null) {
                throw new ArgumentNullException(nameof(group));
            }

            UnitOfWork.GetRepository<Group>().Add(Mapper.Map<Group>(group));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, GroupDto group) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            if (group == null) {
                throw new ArgumentNullException(nameof(group));
            }

            var entity = await UnitOfWork.GetRepository<Group>().FindByIdAsync(id);
            if (entity == null || entity.IsArchive) {
                throw new NotFoundException($"Group with id = {id} not found.");
            }

            entity.Аbbreviation = group.Аbbreviation;
            UnitOfWork.GetRepository<Group>().Update(entity);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveStudentFromGroup(Guid groupId, Guid studentId) {
            if (groupId == Guid.Empty) {
                throw new ArgumentNullException(nameof(groupId));
            }

            if (studentId == Guid.Empty) {
                throw new ArgumentNullException(nameof(studentId));
            }

            var entity = await UnitOfWork.GetRepository<Student>().FindByIdAsync(studentId);
            if (entity == null || entity.IsArchive) {
                throw new NotFoundException($"Student with id = {studentId} not found.");
            }

            entity.GroupId = null;
            UnitOfWork.GetRepository<Student>().Update(entity);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await UnitOfWork.GetRepository<Group>().FindByIdAsync(id);
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.IsArchive = true;
            UnitOfWork.GetRepository<Group>().Update(entity);
            await UnitOfWork.CommitAsync();
        }
    }
}
