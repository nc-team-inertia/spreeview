using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Wrappers;
using SpreeviewFrontend.Services.ApiReview;

namespace SpreeviewFrontend.Services.ApiSeries;

public interface IApiSeriesService
{
    Task<ServiceObjectResponse<List<SeriesGetDTO>>> GetTrendingSeries();
    Task<ServiceObjectResponse<List<SeriesGetDTO>>> GetTopRatedSeries();
    Task<ServiceObjectResponse<SeriesGetDTO>> GetSeriesById(int id);
    Task<ServiceObjectResponse<List<SeriesGetDTO>>> FindSeriesByKeyword([FromQuery] string query);
}