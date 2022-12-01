using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class UmpireRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UmpireId { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; } = new List<MatchDetail>();

    public virtual Umpire? Umpire { get; set; }
}
