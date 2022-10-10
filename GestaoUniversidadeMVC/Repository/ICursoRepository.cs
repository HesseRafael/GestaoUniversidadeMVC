using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public interface ICursoRepository
    {
        CursoModel ListarCursoPorId(int id);
        List<CursoModel> BuscarTodos();
        CursoModel Adicionar(CursoModel curso);
        CursoModel Alterar(CursoModel curso);
        bool Excluir(int id);
    }
}
