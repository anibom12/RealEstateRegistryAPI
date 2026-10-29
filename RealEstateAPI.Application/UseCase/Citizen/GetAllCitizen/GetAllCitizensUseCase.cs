
using MediatR;
using RealEstateAPI.Application.Contracts.Repositotries;
using RealEstateAPI.Domain.Exceptions;

namespace RealEstateAPI.Application.UseCase.Citizen.GetAllCitizen;

public class GetAllCitizensUseCase : IRequestHandler<GetAllCitizenQuery, Result<IReadOnlyList<CitizenListItemDto>>>
{
    private readonly ICitizenReadRepository _citizenReadRepository;
    public GetAllCitizensUseCase(ICitizenReadRepository citizenReadRepository) 
    {
        _citizenReadRepository=citizenReadRepository;
    }

  

    public async Task<Result<IReadOnlyList<CitizenListItemDto>>> Handle(GetAllCitizenQuery request,CancellationToken cancellationToken)
    {
        var citizens = await _citizenReadRepository.GetAllAsync(cancellationToken);
        return Result<IReadOnlyList<CitizenListItemDto>>.Success(citizens);
    }
}

