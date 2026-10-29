using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class Occupation
{
    public int OccupationId { get; set; }

    public string OccupationName { get; set; } = null!;

    public virtual ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();
}
