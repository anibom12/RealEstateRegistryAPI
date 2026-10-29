using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class Occupancy
{
    public int OccupancyId { get; set; }

    public int CitizenId { get; set; }

    public int EstateId { get; set; }

    public byte ContractTypeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Citizen Citizen { get; set; } = null!;

    public virtual ContractType ContractType { get; set; } = null!;

    public virtual Estate Estate { get; set; } = null!;
}
