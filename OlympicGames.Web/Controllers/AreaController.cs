using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Web.Controllers
{
    public class AreaController : Controller
    {
        private IAreaRepository _areaRepository;
        private ICountryRepository _countryRepository;

        public AreaController(IAreaRepository areaRepository, ICountryRepository countryRepository)
        {
            _areaRepository = areaRepository;
            _countryRepository = countryRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var get = _areaRepository.GetAll(pageNumber, pageSize);
            return View(get);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            var viewModel = _areaRepository.GetByIdArea(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AreaViewModel vm)
        {
            await _areaRepository.UpdateArea(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AreaViewModel vm)
        {
            await _areaRepository.AddArea(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _areaRepository.DeleteArea(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _areaRepository.GetByIdArea(id);
            return View(model);
        }
    }
}
