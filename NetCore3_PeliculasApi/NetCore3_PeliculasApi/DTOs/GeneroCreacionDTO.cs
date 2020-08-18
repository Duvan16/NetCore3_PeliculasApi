﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore3_PeliculasApi.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}