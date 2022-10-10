using GestaoUniversidadeMVC.Data;
using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly BancoContext _bancoContext;
        public AlunoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public List<AlunoModel> BuscarTodos()
        {
            return _bancoContext.Alunos.ToList();
        }

        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();
            return aluno;
        }

        public AlunoModel ListarAlunoPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }

        public AlunoModel Alterar(AlunoModel Aluno)
        {
            AlunoModel alunoDb = ListarAlunoPorId(Aluno.Id);

            if (alunoDb == null) throw new Exception("Houve um erro na atualização do aluno");

            alunoDb.Nome = Aluno.Nome;
            alunoDb.Email = Aluno.Email;
            alunoDb.Idade = Aluno.Idade;

            _bancoContext.Alunos.Update(alunoDb);
            _bancoContext.SaveChanges();

            return alunoDb;
        }

        public bool Excluir(int id)
        {
            AlunoModel alunoDb = ListarAlunoPorId(id);

            if (alunoDb == null) throw new Exception("Houve um erro na deleção do aluno");
            _bancoContext.Alunos.Remove(alunoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
