using OlympicGames.Infrastructure.ViewModels;

namespace OlympicGames.Infrastructure.IRepositories
{
    public interface IOlympicEventRepository
    {
        IEnumerable<OlympicEventViewModel> GetAllOlympicEventList();
        OlympicEventViewModel GetByIdOlympicEvent(int id);
        Task AddOlympicEvent(OlympicEventViewModel model);
        Task UpdateOlympicEvent(OlympicEventViewModel model);
        void DeleteOlympicEvent(int id);
    }
}
