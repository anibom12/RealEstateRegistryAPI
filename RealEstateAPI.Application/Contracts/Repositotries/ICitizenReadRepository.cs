
using RealEstateAPI.Application.UseCase.Citizen.GetAllCitizen;
namespace RealEstateAPI.Application.Contracts.Repositotries;

public interface ICitizenReadRepository
{
    Task<IReadOnlyList<CitizenListItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

}
