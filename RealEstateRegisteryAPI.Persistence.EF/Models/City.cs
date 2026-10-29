using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class City
{
    public int CityId { get; set; }

    public int? ParentCityId { get; set; }

    public string CityName { get; set; } = null!;

    public byte CityLevelId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();

    public virtual CityLevel CityLevel { get; set; } = null!;

    public virtual ICollection<Estate> Estates { get; set; } = new List<Estate>();

    public virtual ICollection<City> InverseParentCity { get; set; } = new List<City>();

    public virtual City? ParentCity { get; set; }
}
