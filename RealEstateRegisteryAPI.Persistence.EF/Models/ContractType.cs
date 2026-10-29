using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class ContractType
{
    public byte ContractTypeId { get; set; }

    public string ContractTypeName { get; set; } = null!;

    public virtual ICollection<Occupancy> Occupancies { get; set; } = new List<Occupancy>();
}
