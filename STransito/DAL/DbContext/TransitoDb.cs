namespace STransito.DAL.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using STransito.DAL.Entidades;

    public class TransitoDb : DbContext

    {
        public TransitoDb(DbContextOptions<TransitoDb> options) : base(options)
        {
        }

        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
    }
}
