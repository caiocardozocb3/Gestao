﻿using System.Collections;
using System.Collections.Generic;
using GestaoDDD.Domain.Entities;
using GestaoDDD.Domain.Interfaces.Repositories;
using GestaoDDD.Infra.Data.Contexto;
using System.Linq;
using System;

namespace GestaoDDD.Infra.Data.Repositories
{
    public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
    {
        private readonly GestaoContext _db;

        public PrestadorRepository(GestaoContext gestaoContexto)
            : base(gestaoContexto)
        {
            _db = new GestaoContext();
        }

        public Prestador GetPorCpf(string cpf)
        {
            return _db.Prestador.FirstOrDefault(s => s.pres_Cpf_Cnpj.Equals(cpf));
        }

        public Prestador GetPorGuid(Guid guid)
        {
            return _db.Prestador.FirstOrDefault(s => s.pres_Id.Equals(guid.ToString()));
        }

        //retorna o prestador atraves do email
        public Prestador GetPorEmail(string email)
        {
            return _db.Prestador.FirstOrDefault(s => s.pres_Email.Equals(email));
        }

        //retorna os pretadores que nao estao ligados ao orçamento selecionado
        public IEnumerable<Prestador> GetPrestadores(int orcamentoId)
        {
            return (from pres in _db.Prestador
                    from orc in pres.OrcamentoFk.Where(p => p.orc_Id != orcamentoId)
                    select pres);
        }

        public IEnumerable<Prestador> GetPrestadoresComServicos()
        {
            return _db.Prestador.Include("ServicoPrestador");
        }
    }
}
