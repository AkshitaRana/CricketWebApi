using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Player> Players { get; } = new List<Player>();

    public virtual ICollection<Stadium> Stadia { get; } = new List<Stadium>();

    public virtual ICollection<Umpire> Umpires { get; } = new List<Umpire>();
}
