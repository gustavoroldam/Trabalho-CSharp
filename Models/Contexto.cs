using Microsoft.EntityFrameworkCore;

namespace Trabalho.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Medicamento_Injetaveis> Medicamento_Injetaveis { get; set; }
        public DbSet<Consulta> Consulta { get; set; }

        /*Agrupamento*/
        public DbSet<Trabalho.Models.Agrupamento.ConsultaAgr> ConsultaAgrs { get; set; }
        public DbSet<Trabalho.Models.Pivot.ConsultaPivot> ConsultaPivots { get; set; }
    }
}
