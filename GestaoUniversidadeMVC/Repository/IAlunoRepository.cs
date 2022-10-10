using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public interface IAlunoRepository
    {
        AlunoModel ListarAlunoPorId(int id);
        List<AlunoModel> BuscarTodos();
        AlunoModel Adicionar(AlunoModel Aluno);
        AlunoModel Alterar(AlunoModel Aluno);
        bool Excluir(int id);
    }
}
