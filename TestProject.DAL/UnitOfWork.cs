using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestPrject.DAL.Contract;
using TestProject.DAL.Contracts;
using TestProject.DAL.Repository;

namespace TestProject.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private readonly List<object> _repositories = new List<object>();

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _context.Configuration.AutoDetectChangesEnabled = true;
            _context.Configuration.LazyLoadingEnabled = true;
        }

        public IGlobalRepository<T> GetRepository<T>() where T : class
        {
            var repo = (IGlobalRepository<T>)_repositories.SingleOrDefault(r => r is IGlobalRepository<T>);
            if (repo == null)
            {
                _repositories.Add(repo = new GlobalRepository<T>(_context));
            }
            return repo;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public bool AutoDetectChanges
        {
            get { return _context.Configuration.AutoDetectChangesEnabled; }
            set { _context.Configuration.AutoDetectChangesEnabled = value; }
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            }
            _disposed = true;
        }     
        #endregion
    }
}