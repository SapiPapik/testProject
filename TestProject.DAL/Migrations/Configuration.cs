using System.Collections.Generic;
using TestProject.Data.Entity;

namespace TestProject.DAL.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TestProject.DAL.TestProjectDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestProject.DAL.TestProjectDbContext context) {
            if (!context.Groups.Any(x => x.Id == new Guid("484804D1-4EBF-4F5F-8944-FD6139287FAA"))) {
                var testCurator = new Curator() {
                    Id = new Guid("484804D1-4EBF-4F5F-8944-FD6139287FAA"),
                    FirstName = "admin",
                    Surname = "admin",
                    Patronymic = "admin",
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                };

                context.Curators.Add(testCurator);
                context.SaveChanges();

                var testStudent = new Student() {
                    Id = new Guid("484804D1-4EBF-4F5F-8944-FD6139287FAB"),
                    FirstName = "admin",
                    Surname = "admin",
                    Patronymic = "admin",
                    Birthday = DateTime.UtcNow,
                    IsStependint = false,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                };

                context.Students.Add(testStudent);
                context.SaveChanges();

                var testGroup = new Group() {
                    Id = new Guid("484804D1-4EBF-4F5F-8944-FD6139287FAC"),
                    Àbbreviation = "adminGroup",
                    CuratorId = testCurator.Id,
                    Students = new List<Student> { testStudent },
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                };

                context.Groups.Add(testGroup);
                context.SaveChanges();
            }
        }
    }
}
