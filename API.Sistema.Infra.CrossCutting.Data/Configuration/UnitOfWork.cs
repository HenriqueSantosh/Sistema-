using API.Sistema.Domain.Interfaces;
using API.Sistema.Infra.CrossCutting.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Sistema.Infra.CrossCutting.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadastroContext _cadastroContext;

        public UnitOfWork(CadastroContext cadastroContext)
        {
            _cadastroContext = cadastroContext;
        }

        public async Task<bool> Commit()
        {
            int rows = await _cadastroContext.SaveChangesAsync();
            return rows > 0;
        }

        public void Dispose()
        {
            _cadastroContext.Dispose();
        }
    }
}
