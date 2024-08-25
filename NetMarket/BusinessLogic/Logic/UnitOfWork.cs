using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;

        private readonly MarketDbContext _context;

        public UnitOfWork(MarketDbContext context)
        {
            _context = context;
        }

        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : ClaseBase
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type)) {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = 
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];

        }
    }
}
