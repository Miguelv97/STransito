using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace STransito.DAL.Entidades
{
    public class Matricula
    {
        public Matricula()
        {
        }

      //  public int Id { get; set; }
        [Key]
        public string Numero { set; get; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Conductor> Conductor { get; set; }
    }
}
