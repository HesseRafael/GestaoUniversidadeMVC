using GestaoUniversidadeMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoUniversidadeMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<DisciplinaModel> Disciplinas { get; set; }
        public DbSet<ProfessorModel> Professores { get; set; }
    }
}
