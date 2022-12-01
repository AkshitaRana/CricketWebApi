using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Series> Series { get; } = new List<Series>();
}
