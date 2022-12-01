using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Team2
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PlayerId { get; set; }

    public int? PlayerRoleId { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; } = new List<MatchDetail>();

    public virtual Player? Player { get; set; }

    public virtual PlayerRole? PlayerRole { get; set; }
}
