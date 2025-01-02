using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Web.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var get = _gameRepository.GetAll(pageNumber, pageSize);
            return View(get);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            var viewModel = _gameRepository.GetByIdGame(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel vm)
        {
            await _gameRepository.UpdateGame(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameViewModel vm)
        {
            await _gameRepository.AddGame(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _gameRepository.DeleteGame(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _gameRepository.GetByIdGame(id);
            return View(model);
        }
    }
}
