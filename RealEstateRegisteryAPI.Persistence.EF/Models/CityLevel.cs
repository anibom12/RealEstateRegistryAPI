using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class CityLevel
{
    public byte CityLevelId { get; set; }

    public string CityLevelName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
