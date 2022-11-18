using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STransito.DAL.Entidades
{
    public class Conductor
    {
        public Conductor()
        {
        }
       // public int Id { get; set; }
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public  DateTime FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public string? IdMAtricula { get; set; }
        [ForeignKey("IdMAtricula")]

        //public virtual Sanciones Sanciones { get; set; }
        public virtual Matricula Matricula { get; set; }
    }
}
