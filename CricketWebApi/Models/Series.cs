using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Series
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; } = new List<MatchDetail>();
}
