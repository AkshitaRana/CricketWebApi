using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Umpire
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<UmpireRole> UmpireRoles { get; } = new List<UmpireRole>();
}
