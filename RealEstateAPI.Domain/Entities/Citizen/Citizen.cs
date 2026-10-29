
using RealEstateAPI.Domain.Common;
using RealEstateAPI.Domain.ValueObjects.Citizen;

namespace RealEstateAPI.Domain.Entities.Citizen;

public class Citizen:BaseEntity<long>
{
    public NationalCode NationalCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ParentName { get; set; }

    private Citizen()
    {
    }
    public Citizen(NationalCode nationalCode, string firstName, string lastName , string parentName)
    {
        NationalCode = nationalCode;
        FirstName = firstName;
        LastName = lastName;
        ParentName = parentName;

    }

}

