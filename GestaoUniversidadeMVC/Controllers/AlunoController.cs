using GestaoUniversidadeMVC.Models;
using GestaoUniversidadeMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUniversidadeMVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public IActionResult Index()
        {
            List<AlunoModel> alunos = _alunoRepository.BuscarTodos();
            return View(alunos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(AlunoModel aluno)
        {
            _alunoRepository.Adicionar(aluno);
            return RedirectToAction("Index");
        }



        public IActionResult Alterar(int id)
        {
            AlunoModel aluno = _alunoRepository.ListarAlunoPorId(id);
            return View(aluno);
        }
        [HttpPost]
        public IActionResult Alterar(AlunoModel aluno)
        {
            _alunoRepository.Alterar(aluno);
            return RedirectToAction("Index");
        }
        public IActionResult ExcluirDb(int id)
        {
            _alunoRepository.Excluir(id);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int id)
        {
            AlunoModel aluno = _alunoRepository.ListarAlunoPorId(id);
            return View(aluno);
        }
    }
}
