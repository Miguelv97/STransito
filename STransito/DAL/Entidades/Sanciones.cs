using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STransito.DAL.Entidades
{
    public class Sanciones
    {
        public Sanciones()
        {
        }

        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string ConductorId { get; set; }
        [ForeignKey("Indentificacion")]
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }

        public virtual Conductor Conductor { get; set; }
        
    }
}
