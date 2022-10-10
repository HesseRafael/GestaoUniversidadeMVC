using GestaoUniversidadeMVC.Models;
using GestaoUniversidadeMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUniversidadeMVC.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        public IActionResult Index()
        {
            List<ProfessorModel> professores = _professorRepository.BuscarTodos();
            return View(professores);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(ProfessorModel professor)
        {
            _professorRepository.Adicionar(professor);
            return RedirectToAction("Index");
        }



        public IActionResult Alterar(int id)
        {
            ProfessorModel professor = _professorRepository.ListarProfessorPorId(id);
            return View(professor);
        }
        [HttpPost]
        public IActionResult Alterar(ProfessorModel professor)
        {
            _professorRepository.Alterar(professor);
            return RedirectToAction("Index");
        }
        public IActionResult ExcluirDb(int id)
        {
            _professorRepository.Excluir(id);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int id)
        {
            ProfessorModel professor = _professorRepository.ListarProfessorPorId(id);
            return View(professor);
        }
    }
}
