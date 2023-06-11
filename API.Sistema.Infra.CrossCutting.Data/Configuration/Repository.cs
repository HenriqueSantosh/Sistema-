using API.Sistema.Domain.Core.Interfaces;
using API.Sistema.Infra.CrossCutting.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Infra.CrossCutting.Data.Configuration
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CadastroContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(CadastroContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void  UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
