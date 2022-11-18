using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.DTO
{
    public class DTOMatricula
    {
        public string Numero { set; get; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool Activo { get; set; }
    }
}
