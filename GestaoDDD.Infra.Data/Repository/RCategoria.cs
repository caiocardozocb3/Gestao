﻿using GestaoDDD.Domain.Entities;
using GestaoDDD.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDDD.Infra.Data.Repository
{
    public class RCategoria : BaseDao<Categoria>, ICategoriaRepositorio
    {
    }
}
