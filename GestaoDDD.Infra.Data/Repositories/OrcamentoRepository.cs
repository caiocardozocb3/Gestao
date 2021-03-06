﻿using System;
using System.Collections.Generic;
using System.Linq;
using GestaoDDD.Domain.Entities;
using GestaoDDD.Domain.Entities.NoSql;
using GestaoDDD.Domain.Interfaces.Repositories;
using GestaoDDD.Infra.Data.Contexto;
using GestaoDDD.Infra.Data.DataLayerDAO;

namespace GestaoDDD.Infra.Data.Repositories
{
  public class OrcamentoRepository : RepositoryBase<Orcamento>, IOrcamentoRepository
  {
    private readonly GestaoContext _dbContext;
    private readonly ConnectionDAO _dao;
    public OrcamentoRepository(GestaoContext dbContext)
        : base(dbContext)
    {
      _dbContext = dbContext;
      _dao = new ConnectionDAO();
    }

    public IEnumerable<Orcamento> RetornaOrcamentosPagos(int servico, string cidade, EnumEstados estado, string usuarioId)
    {
      return _db.Orcamento.Where(o => o.serv_Id == servico &&
          o.orc_estado == estado &&
          o.orc_cidade.Equals(cidade) &&
          o.Status == EnumStatusOrcamento.Aberto &&
          o.PrestadorFk.Any(p => p.pres_Id == usuarioId));
    }

    //retorna os orcamentos 
    public IEnumerable<Orcamento> RetornaOrcamentos(int servico, string cidade, EnumEstados estado)
    {
      return _db.Orcamento.Where(o => o.serv_Id == servico &&
          o.orc_estado == estado &&
          o.orc_cidade.Trim().Equals(cidade) &&
          o.Status == EnumStatusOrcamento.Aberto);
    }


    public IEnumerable<Orcamento> RetornaOrcamentosAbertos()
    {
      return _db.Orcamento.Where(o => o.Status == EnumStatusOrcamento.Aberto);
    }

    public IEnumerable<Orcamento> GetOrcamentoPagosPeloPrestador(string usuarioId)
    {
      return _db.Orcamento.Where(o => o.PrestadorFk.Any(p => p.pres_Id == usuarioId));
    }

    public Orcamento RetornaOrcamentoPorId(int id)
    {
      return _db.Orcamento.SingleOrDefault(o => o.orc_Id == id);
    }

    public bool PegarQuantidadeOrcamentosPorPrestador(int orcamentoId)
    {
      return _dao.PegarQuantidadeOrcamentosPorPrestador(orcamentoId);
    }
  }
}
