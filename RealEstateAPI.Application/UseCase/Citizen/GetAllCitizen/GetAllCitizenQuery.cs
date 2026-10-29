using MediatR;
using RealEstateAPI.Domain.Exceptions;


namespace RealEstateAPI.Application.UseCase.Citizen.GetAllCitizen;

public record GetAllCitizenQuery : IRequest<Result<IReadOnlyList<CitizenListItemDto>>>;
