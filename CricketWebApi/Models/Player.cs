using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Player
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Team1> Team1s { get; } = new List<Team1>();

    public virtual ICollection<Team2> Team2s { get; } = new List<Team2>();
}
