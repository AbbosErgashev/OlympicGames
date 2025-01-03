using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Web.Controllers
{
    public class AthleteController : Controller
    {
        private IAthleteRepository _athleteRepository;
        private ICountryRepository _countryRepository;
        private IGameRepository _gameRepository;

        public AthleteController(
            IAthleteRepository athleteRepository,
            ICountryRepository countryRepository,
            IGameRepository gameRepository)
        {
            _athleteRepository = athleteRepository;
            _countryRepository = countryRepository;
            _gameRepository = gameRepository;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var get = _athleteRepository.GetAll(pageNumber, pageSize);
            return View(get);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            ViewBag.Game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _athleteRepository.GetByIdAthlete(id);

            if(model is null) return NotFound();
            AthleteViewModel vm = new()
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                CountryId = model.CountryId,
                GameId = model.GameId,
                ProfileImage = model.ProfileImage,
                Country = model.Country,
                Game = model.Game,
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AthleteViewModel vm)
        {
            await _athleteRepository.UpdateAthlete(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            ViewBag.Game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AthleteViewModel vm)
        {
            await _athleteRepository.AddAthlete(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _athleteRepository.DeleteAthlete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Country = new SelectList(_countryRepository.GetAll(1, 10).Data, "Id", "Name");
            ViewBag.Game = new SelectList(_gameRepository.GetAll(1, 10).Data, "Id", "Name");
            var model = _athleteRepository.GetByIdAthlete(id);
            return View(model);
        }
    }
}
