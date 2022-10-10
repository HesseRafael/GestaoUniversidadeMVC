using GestaoUniversidadeMVC.Data;
using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly BancoContext _bancoContext;
        public CursoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public List<CursoModel> BuscarTodos()
        {
            return _bancoContext.Cursos.ToList();
        }

        public CursoModel Adicionar(CursoModel curso)
        {
            _bancoContext.Cursos.Add(curso);
            _bancoContext.SaveChanges();
            return curso;
        }

        public CursoModel ListarCursoPorId(int id)
        {
            return _bancoContext.Cursos.FirstOrDefault(x => x.Id == id);
        }

        public CursoModel Alterar(CursoModel Curso)
        {
            CursoModel cursoDb = ListarCursoPorId(Curso.Id);

            if (cursoDb == null) throw new Exception("Houve um erro na atualização do curso");

            cursoDb.Nome = Curso.Nome;
            cursoDb.Local = Curso.Local;

            _bancoContext.Cursos.Update(cursoDb);
            _bancoContext.SaveChanges();

            return cursoDb;
        }

        public bool Excluir(int id)
        {
            CursoModel cursoDb = ListarCursoPorId(id);

            if (cursoDb == null) throw new Exception("Houve um erro na deleção do curso");
            _bancoContext.Cursos.Remove(cursoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
