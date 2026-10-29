using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class GenderType
{
    public byte GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();
}
