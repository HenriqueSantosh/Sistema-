using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task  AddAsync(TEntity entity);
        void  UpdateAsync(TEntity entity);
        void  DeleteAsync(TEntity entity);
    }
}
