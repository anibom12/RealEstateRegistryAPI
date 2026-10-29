using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class Citizen
{
    public int CitizenId { get; set; }

    public string NationalCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ParentName { get; set; }

    public byte GenderId { get; set; }

    public int? OccupationId { get; set; }

    public int BirthCityId { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly? DeathDate { get; set; }

    public string? Mobile { get; set; }

    public byte? MaritalStatusId { get; set; }

    public virtual City BirthCity { get; set; } = null!;

    public virtual GenderType Gender { get; set; } = null!;

    public virtual MaritalStatus? MaritalStatus { get; set; }

    public virtual ICollection<Occupancy> Occupancies { get; set; } = new List<Occupancy>();

    public virtual Occupation? Occupation { get; set; }
}
