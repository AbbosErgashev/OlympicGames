using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface ICompetitionRepository
    {
        IEnumerable<CompetitionViewModel> GetAllCompetitionList();
        CompetitionViewModel GetByIdCompetition(int id);
        Task AddCompetition(CompetitionViewModel model);
        Task UpdateCompetition(CompetitionViewModel model);
        void DeleteCompetition(int id);
    }
}
