using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Web.Controllers
{
    public class YearController : Controller
    {
        private IYearRepository _yearRepository;

        public YearController(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var get = _yearRepository.GetAll(pageNumber, pageSize);
            return View(get);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.year = new SelectList(_yearRepository.GetAll(1, 10).Data, "Id", "Name");
            var viewModel = _yearRepository.GetByIdYear(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(YearViewModel vm)
        {
            await _yearRepository.UpdateYear(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital = new SelectList(_yearRepository.GetAll(1, 10).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(YearViewModel vm)
        {
            await _yearRepository.AddYear(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _yearRepository.DeleteYear(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.hospital = new SelectList(_yearRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _yearRepository.GetByIdYear(id);
            return View(model);
        }
    }
}
