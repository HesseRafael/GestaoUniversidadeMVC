using GestaoUniversidadeMVC.Data;
using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly BancoContext _bancoContext;
        public ProfessorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public List<ProfessorModel> BuscarTodos()
        {
            return _bancoContext.Professores.ToList();
        }

        public ProfessorModel Adicionar(ProfessorModel professor)
        {
            _bancoContext.Professores.Add(professor);
            _bancoContext.SaveChanges();
            return professor;
        }

        public ProfessorModel ListarProfessorPorId(int id)
        {
            return _bancoContext.Professores.FirstOrDefault(x => x.Id == id);
        }

        public ProfessorModel Alterar(ProfessorModel Professor)
        {
            ProfessorModel professorDb = ListarProfessorPorId(Professor.Id);

            if (professorDb == null) throw new Exception("Houve um erro na atualização do Professor");

            professorDb.Nome = Professor.Nome;
            professorDb.Email = Professor.Email;
            professorDb.Idade = Professor.Idade;

            _bancoContext.Professores.Update(professorDb);
            _bancoContext.SaveChanges();

            return professorDb;
        }

        public bool Excluir(int id)
        {
            ProfessorModel professorDb = ListarProfessorPorId(id);

            if (professorDb == null) throw new Exception("Houve um erro na deleção do Professor");
            _bancoContext.Professores.Remove(professorDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
