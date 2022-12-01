using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Toss
{
    public int Id { get; set; }

    public string? Winner { get; set; }

    public string? Decision { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; } = new List<MatchDetail>();
}
