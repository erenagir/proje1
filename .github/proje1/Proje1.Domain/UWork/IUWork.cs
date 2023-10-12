using Proje1.Domain.Common;
using Proje1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Domain.UWork
{
    public interface IUWork:IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> ComitAsync(string mesaage);
    }
}
