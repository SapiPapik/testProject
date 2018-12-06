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
    public class StudentService : BaseService, IStudentService {

        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork) {
        }

        public async Task<ICollection<StudentDto>> GetAllAsync() {
            var students = await UnitOfWork.GetRepository<Student>().AllIncluding(s => s.Group).Where(s => !s.IsArchive).ToListAsync();
            return Mapper.Map<ICollection<StudentDto>>(students);
        }

        public async Task<StudentDto> GetByIdAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var student = await UnitOfWork.GetRepository<Student>().FindByIdAsync(id);
            if (student == null || student.IsArchive) {
                throw new NotFoundException($"Student with id = {id} not found.");
            }

            return Mapper.Map<StudentDto>(student);
        }

        public async Task AddAsync(StudentDto student) {
            if (student == null) {
                throw new ArgumentNullException(nameof(student));
            }

            UnitOfWork.GetRepository<Student>().Add(Mapper.Map<Student>(student));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid id, StudentDto student) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            if (student == null) {
                throw new ArgumentNullException(nameof(student));
            }

            var entity = await UnitOfWork.GetRepository<Student>().FindByIdAsync(id);
            if (entity == null || entity.IsArchive) {
                throw new NotFoundException($"Student with id = {id} not found.");
            }

            entity.FirstName = string.IsNullOrEmpty(student.FirstName) ? entity.FirstName : student.FirstName;
            entity.Surname = string.IsNullOrEmpty(student.FirstName) ? entity.Surname : student.Surname;
            entity.Patronymic = string.IsNullOrEmpty(student.Patronymic) ? entity.Patronymic : student.Patronymic;
            entity.Birthday = student.Birthday == DateTime.MinValue ? entity.Birthday : student.Birthday;
            entity.IsStependint = student.IsStependint != null ? student.IsStependint : entity.IsStependint;

            UnitOfWork.GetRepository<Student>().Update(entity);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Guid id) {
            if (id == Guid.Empty) {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await UnitOfWork.GetRepository<Student>().FindByIdAsync(id);
            if (entity == null) {
                throw new NotFoundException($"Student with id = {id} not found.");
            }

            entity.IsArchive = true;
            UnitOfWork.GetRepository<Student>().Update(entity);
            await UnitOfWork.CommitAsync();
        }
    }
}
