using OlympicGames.Infrastructure.IRepositories;
using OlympicGames.Infrastructure.IRepositories.Base;
using OlympicGames.Infrastructure.ViewModels;
using OlympicGames.Model.Entity;

namespace OlympicGames.Infrastructure.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompetitionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddCompetition(CompetitionViewModel model)
        {
            var add = new CompetitionViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Competition>().Add(add);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public void DeleteCompetition(int id)
        {
            var delete = _unitOfWork.GenericRepository<Competition>().GetById(id);
            _unitOfWork.GenericRepository<Competition>().Delete(delete);
            _unitOfWork.Save();
        }

        public IEnumerable<CompetitionViewModel> GetAllCompetitionList()
        {
            var getAll = _unitOfWork.GenericRepository<Competition>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(getAll);
            return vmList;
        }

        public CompetitionViewModel GetByIdCompetition(int id)
        {
            var getById = _unitOfWork.GenericRepository<Competition>().GetById(id);
            var cmId = new CompetitionViewModel(getById);
            return cmId;
        }

        public Task UpdateCompetition(CompetitionViewModel model)
        {
            var update = new CompetitionViewModel().ConvertViewModel(model);
            var convert = _unitOfWork.GenericRepository<Competition>().GetById(model.Id);
            convert.Id = model.Id;
            convert.Game = model.Game;
            convert.StartDateTime = model.StartDateTime;
            convert.OlympicEvent = model.OlympicEvent;
            convert.Area = model.Area;
            convert.Athlete = model.Athlete;
            convert.Medal = model.Medal;
            convert.Image = model.Image;
            convert.Video = model.Video;
            convert.GameId = model.GameId;
            convert.OlympicEventId = model.OlympicEventId;
            convert.AreaId = model.AreaId;
            convert.AthleteId = model.AthleteId;
            convert.MeladId = model.MedalId;

            _unitOfWork.GenericRepository<Competition>().Update(convert);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        private List<CompetitionViewModel> ConvertModelToViewModelList(List<Competition> list)
        {
            var model = list.Select(list => new CompetitionViewModel(list)).ToList();
            return model;
        }
    }
}
