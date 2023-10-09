using Proje1.Domain.Common;
using Proje1.Domain.Entities;
using Proje1.Domain.Repositories;
using Proje1.Domain.Services.Abstraction;
using Proje1.Domain.UWork;
using Proje1.Persistence.Context;
using Proje1.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.UWork
{
    public class UWork : IUWork
    {
        private Dictionary<Type, object> _repository;
        private readonly ProjeContext _context;
        private readonly ILoggedUserService _loggedService;


        public UWork(ProjeContext projeContext, ILoggedUserService loggedService)
        {
            _repository = new Dictionary<Type, object>();
            _context = projeContext;
            _loggedService = loggedService;
        }

        public async Task<bool> ComitAsync(string mesaage)
        {
            var reportEntity = new Report
            {
                Date = DateTime.Now,
                PersonID = (int)_loggedService.UserId,
                DepartmentId = (int)_loggedService.DepartmentId,
                detail = mesaage,

            };

           // _repository.Add(typeof(IRepository<Report>), new Repository<Report>(_context));
            GetRepository<Report>().Add(reportEntity);

            

            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {


                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    await transaction.RollbackAsync();

                    throw;
                }

            }
            return result;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repository.ContainsKey(typeof(IRepository<T>)))
                return (IRepository<T>)_repository[typeof(IRepository<T>)];

            var repository = new Repository<T>(_context);

            _repository.Add(typeof(IRepository<T>), repository);
            return repository;

        }



        #region Dispose

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                //.Net objelerini kaldır.
                _context.Dispose();
            }

            //Kullanılan harici dil kütüphaneleri (.Net ile yazılmamış external kütüphaneler)

            _disposed = true;
        }

        #endregion
    }
}
