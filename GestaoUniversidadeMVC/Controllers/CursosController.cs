using GestaoUniversidadeMVC.Models;
using GestaoUniversidadeMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUniversidadeMVC.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursoRepository _cursoRepository;
        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public IActionResult Index()
        {
            List<CursoModel> cursos = _cursoRepository.BuscarTodos();
            return View(cursos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adicionar(CursoModel curso)
        {
            _cursoRepository.Adicionar(curso);
            return RedirectToAction("Index");
        }



        public IActionResult Alterar(int id)
        {
            CursoModel curso = _cursoRepository.ListarCursoPorId(id);
            return View(curso);
        }
        [HttpPost]
        public IActionResult Alterar(CursoModel curso)
        {
            _cursoRepository.Alterar(curso);
            return RedirectToAction("Index");
        }
        public IActionResult ExcluirDb(int id)
        {
            _cursoRepository.Excluir(id);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int id)
        {
            CursoModel curso = _cursoRepository.ListarCursoPorId(id);
            return View(curso);
        }
    }
}
