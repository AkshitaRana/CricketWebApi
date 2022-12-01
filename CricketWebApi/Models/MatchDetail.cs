using System;
using System.Collections.Generic;

namespace CricketWebApi.Models;

public partial class MatchDetail
{
    public int Id { get; set; }

    public int? Team1Id { get; set; }

    public int? Team2Id { get; set; }

    public int? StadiumId { get; set; }

    public int? SeriesId { get; set; }

    public int? TossId { get; set; }

    public int? UmpireRoleId { get; set; }

    public virtual Series? Series { get; set; }

    public virtual Stadium? Stadium { get; set; }

    public virtual Team1? Team1 { get; set; }

    public virtual Team2? Team2 { get; set; }

    public virtual Toss? Toss { get; set; }

    public virtual UmpireRole? UmpireRole { get; set; }
}
