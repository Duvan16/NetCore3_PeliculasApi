using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore3_PeliculasApi.DTOs
{
    public class SalaDeCineCercanoDTO: SalaDeCineDTO
    {
        public double DistanciaEnMetros { get; set; }
    }
}
