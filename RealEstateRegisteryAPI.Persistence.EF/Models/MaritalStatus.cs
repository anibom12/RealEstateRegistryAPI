using System;
using System.Collections.Generic;

namespace RealEstateRegisteryAPI.Persistence.EF.Models;

public partial class MaritalStatus
{
    public byte MaritalStatusId { get; set; }

    public string MaritalStatusName { get; set; } = null!;

    public virtual ICollection<Citizen> Citizens { get; set; } = new List<Citizen>();
}
