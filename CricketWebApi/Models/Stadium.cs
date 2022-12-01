using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class Stadium
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public TimeSpan? Timezone { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<MatchDetail> MatchDetails { get; } = new List<MatchDetail>();
}
