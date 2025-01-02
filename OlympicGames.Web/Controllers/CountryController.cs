using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Web.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var get = _countryRepository.GetAll(pageNumber, pageSize);
            return View(get);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            var viewModel = _countryRepository.GetByIdCountry(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModel vm)
        {
            await _countryRepository.UpdateCountry(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryViewModel vm)
        {
            await _countryRepository.AddCountry(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _countryRepository.DeleteCountry(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _countryRepository.GetByIdCountry(id);
            return View(model);
        }
    }
}
