﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDDD.Domain.Entities
{
    public class Usuario : Entidade
    {
        public int usu_Id { get; set; }
        public string usu_endereco { get; set; }
        public string usu_email { get; set; }
    }

 
}

 
