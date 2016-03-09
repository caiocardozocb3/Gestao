﻿using GestaoDDD.Domain.Entities;
using GestaoDDD.Domain.Interfaces.Repositories;
using GestaoDDD.Infra.Data.Contexto;

namespace GestaoDDD.Infra.Data.Repositories
{
    public class OrcamentoRepository : RepositoryBase<Orcamento>, IOrcamentoRepository
    {
        private readonly GestaoContext _dbContext;
        public OrcamentoRepository(GestaoContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
