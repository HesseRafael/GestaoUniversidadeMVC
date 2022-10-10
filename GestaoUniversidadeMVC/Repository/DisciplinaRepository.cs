using GestaoUniversidadeMVC.Data;
using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly BancoContext _bancoContext;
        public DisciplinaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public List<DisciplinaModel> BuscarTodos()
        {
            return _bancoContext.Disciplinas.ToList();
        }

        public DisciplinaModel Adicionar(DisciplinaModel disciplina)
        {
            _bancoContext.Disciplinas.Add(disciplina);
            _bancoContext.SaveChanges();
            return disciplina;
        }

        public DisciplinaModel ListarDisciplinaPorId(int id)
        {
            return _bancoContext.Disciplinas.FirstOrDefault(x => x.Id == id);
        }

        public DisciplinaModel Alterar(DisciplinaModel Disciplina)
        {
            DisciplinaModel disciplinaDb = ListarDisciplinaPorId(Disciplina.Id);

            if (disciplinaDb == null) throw new Exception("Houve um erro na atualização da Disciplina");

            disciplinaDb.Nome = Disciplina.Nome;
            disciplinaDb.Professor = Disciplina.Professor;

            _bancoContext.Disciplinas.Update(disciplinaDb);
            _bancoContext.SaveChanges();

            return disciplinaDb;
        }

        public bool Excluir(int id)
        {
            DisciplinaModel disciplinaDb = ListarDisciplinaPorId(id);

            if (disciplinaDb == null) throw new Exception("Houve um erro na deleção da Disciplina");
            _bancoContext.Disciplinas.Remove(disciplinaDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
