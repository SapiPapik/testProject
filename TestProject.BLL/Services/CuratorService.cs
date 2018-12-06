using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using TestProject.BLL.Contracts.Contracts;
using TestProject.BLL.Contracts.Dtos;
using TestProject.BLL.Exceptions;
using TestProject.DAL.Contract;
using TestProject.Data.Entity;

namespace TestProject.BLL.Services {
    public class CuratorService : BaseService, ICuratorService {

        public CuratorService(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public async Task<IEnumerable<CuratorDto>> GetAllAsync() {
            var curators = await UnitOfWork.GetRepository<Curator>().All().ToListAsync();
            return Mapper.Map<ICollection<CuratorDto>>(curators);
        }

        public async Task<CuratorDto> GetByIdAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var curator = await UnitOfWork.GetRepository<Curator>().FindByIdAsync(id);
            if (curator == null || curator.IsArchive) {
                throw new NotFoundException($"Curator with id = {id} not found.");
            }
            return Mapper.Map<CuratorDto>(curator);
        }

        public async Task AddCuratorToGroup(Guid curatorId, Guid groupId) {
            if (curatorId == Guid.Empty) {
                throw new ArgumentNullException(nameof(curatorId));
            }

            if (groupId == Guid.Empty) {
                throw new ArgumentNullException(nameof(groupId));
            }

            var group = await UnitOfWork.GetRepository<Group>().FindByIdAsync(groupId);
            if (group == null || group.IsArchive) {
                throw new NotFoundException($"Group with id = {groupId} not found.");
            }

            if (!await UnitOfWork.GetRepository<Curator>().AnyAsync(c => c.Id == curatorId)) {
                throw new NotFoundException($"Curator with id = {curatorId} not found.");
            }

            group.CuratorId = curatorId;
            UnitOfWork.GetRepository<Group>().Update(group);
            await UnitOfWork.CommitAsync();
        }

        public async Task AddAsync(CuratorDto curator) {
            if (curator == null) {
                throw new ArgumentNullException(nameof(curator));
            }
            UnitOfWork.GetRepository<Curator>().Add(Mapper.Map<Curator>(curator));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, CuratorDto curator) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            if (curator == null) {
                throw new ArgumentNullException(nameof(curator));
            }

            var entity = await UnitOfWork.GetRepository<Curator>().FindByIdAsync(id);
            if (entity == null || entity.IsArchive) {
                throw new NotFoundException($"Curator with id = {id} not found.");
            }

            entity.FirstName = curator.FirstName;
            entity.Surname = curator.Surname;
            entity.Patronymic = curator.Patronymic;
            UnitOfWork.GetRepository<Curator>().Update(entity);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveCuratorFromGroup(Guid curatorId, Guid groupId) {
            if (curatorId == Guid.Empty) {
                throw new ArgumentNullException(nameof(curatorId));
            }

            if (groupId == Guid.Empty) {
                throw new ArgumentNullException(nameof(groupId));
            }

            var group = await UnitOfWork.GetRepository<Group>().FindByIdAsync(groupId);
            if (group == null || group.IsArchive) {
                throw new NotFoundException($"Group with id = {groupId} not found.");
            }

            if (group.CuratorId != curatorId) {
                throw new Exception($"Group with id = {groupId} does not contain curator with id = {curatorId}.");
            }

            group.CuratorId = null;
            UnitOfWork.GetRepository<Group>().Update(group);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await UnitOfWork.GetRepository<Curator>().FindByIdAsync(id);
            if (entity == null) {
                throw new NotFoundException($"Curator with id = {id} not found.");
            }

            entity.IsArchive = true;
            UnitOfWork.GetRepository<Curator>().Update(entity);
            await UnitOfWork.CommitAsync();
        }
    }
}
