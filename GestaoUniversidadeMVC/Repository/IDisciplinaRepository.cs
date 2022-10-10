using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public interface IDisciplinaRepository
    {
        DisciplinaModel ListarDisciplinaPorId(int id);
        List<DisciplinaModel> BuscarTodos();
        DisciplinaModel Adicionar(DisciplinaModel Aluno);
        DisciplinaModel Alterar(DisciplinaModel Aluno);
        bool Excluir(int id);
    }
}
