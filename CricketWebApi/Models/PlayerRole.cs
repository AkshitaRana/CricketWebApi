using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class PlayerRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public virtual ICollection<Team1> Team1s { get; } = new List<Team1>();

    public virtual ICollection<Team2> Team2s { get; } = new List<Team2>();
}
