﻿using GestaoDDD.Application.Interface;
using GestaoDDD.Domain.Entities;
using GestaoDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace GestaoDDD.Application.Services
{
    public class ServicoPrestadorAppService : AppServiceBase<ServicoPrestador>, IServicoPrestadorAppService
    {
        private readonly IServicoPrestadorService _servicoPresService;
        public ServicoPrestadorAppService(IServicoPrestadorService servicoPrestService)
            : base(servicoPrestService)
        {
            _servicoPresService = servicoPrestService;
        }

        public void SalvarServicosPrestador(IEnumerable<Servico> checkboxes, Prestador prestador) 
        {
            _servicoPresService.SalvarServicosPrestador(checkboxes, prestador);
        }


        public IEnumerable<ServicoPrestador> GetServicoPorPrestadorId(string prestadorId)
        {
            return _servicoPresService.GetServicoPorPrestadorId(prestadorId);
        }

        public IEnumerable<ServicoPrestador> GetByServicoId(int servicoId)
        {
            return _servicoPresService.GetByServicoId(servicoId);
        }

        public IEnumerable<Guid> PrestadoresOferecemServico(int servicoId)
        {
           return _servicoPresService.PrestadoresOferecemServico(servicoId);
        }
    }
}
