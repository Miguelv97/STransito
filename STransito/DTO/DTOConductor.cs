using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STransito.DTO
{
    public class DTOConductor
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public string? IdMAtricula { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
    }
}
