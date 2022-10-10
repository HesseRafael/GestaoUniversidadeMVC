using GestaoUniversidadeMVC.Models;
using GestaoUniversidadeMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUniversidadeMVC.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public DisciplinasController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }
        public IActionResult Index()
        {
            List<DisciplinaModel> disciplinas = _disciplinaRepository.BuscarTodos();
            return View(disciplinas);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(DisciplinaModel disciplina)
        {
            _disciplinaRepository.Adicionar(disciplina);
            return RedirectToAction("Index");
        }



        public IActionResult Alterar(int id)
        {
            DisciplinaModel disciplina = _disciplinaRepository.ListarDisciplinaPorId(id);
            return View(disciplina);
        }
        [HttpPost]
        public IActionResult Alterar(DisciplinaModel disciplina)
        {
            _disciplinaRepository.Alterar(disciplina);
            return RedirectToAction("Index");
        }
        public IActionResult ExcluirDb(int id)
        {
            _disciplinaRepository.Excluir(id);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int id)
        {
            DisciplinaModel disciplina = _disciplinaRepository.ListarDisciplinaPorId(id);
            return View(disciplina);
        }
    }
}
