using CommonLibrary.DataClasses.SeasonModel;

namespace SpreeviewAPI.Services.Interfaces
{
    public interface ISeasonService
    {
        Task<Season?> FindSeasonByIds(int seriesId, int seasonNumber);
    }
}