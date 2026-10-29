

namespace RealEstateAPI.Domain.Exceptions;

public sealed record Error(string status, string? Message = null)
{
}
