using CLIMFinders.Application.DTOs;

namespace CLIMFinders.Application.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<VehicleListDto> GetSearchResult(string VIN);
    }
}
