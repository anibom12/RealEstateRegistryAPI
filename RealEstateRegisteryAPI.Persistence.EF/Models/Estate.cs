using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class Estate
{
    public int EstateId { get; set; }

    public int CityId { get; set; }

    public int CategoryId { get; set; }

    public int UsageId { get; set; }

    public string ZipCode { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string DeedPlaque { get; set; } = null!;

    public short? FloorNumber { get; set; }

    public short? ConstructionYear { get; set; }

    public decimal AreaSqm { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public bool IsActive { get; set; }

    public virtual UnitCategory Category { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Occupancy> Occupancies { get; set; } = new List<Occupancy>();

    public virtual UsageKind Usage { get; set; } = null!;
}
