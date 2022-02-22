using Microsoft.EntityFrameworkCore;

namespace BeYouCRUD.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<cadastroParceiros> CadastroParceiros { get; set; }
        public DbSet<cadastroVagasEmprego> CadastroVagasEmprego { get; set; }
        public DbSet<cadastroVoluntarios> CadastroVoluntarios { get; set; }
        public DbSet<casasAcolhimento> casasAcolhimentos { get; set; }
        public DbSet<cadastroCursos> CadastroCursos { get; set; }
        public DbSet<cadastroAdmin> cadastroAdmins { get; set; }
    }
}
