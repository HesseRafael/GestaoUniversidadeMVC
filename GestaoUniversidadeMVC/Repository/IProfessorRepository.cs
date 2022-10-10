using GestaoUniversidadeMVC.Models;

namespace GestaoUniversidadeMVC.Repository
{
    public interface IProfessorRepository
    {
        ProfessorModel ListarProfessorPorId(int id);
        List<ProfessorModel> BuscarTodos();
        ProfessorModel Adicionar(ProfessorModel Professor);
        ProfessorModel Alterar(ProfessorModel Professor);
        bool Excluir(int id);
    }
}
