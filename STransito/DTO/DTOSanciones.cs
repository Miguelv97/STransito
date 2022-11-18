using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.DTO
{
    public class DTOSanciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaActual { get; set; }
        public string ConductorId { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }
    }
}
