using System;
using System.Collections.Generic;

namespace AdventureWorks.Domain.Entities
{
    public class RaceHistory : BaseEntity
    {
        public int CompetitorId { get; set; }
        public int RaceTrackId { get; set; }
        public DateTime DateTrack { get; set; }
        public decimal TimeSpent { get; set; }

        public IList<Competitors> competitors { get; set; }
        public IList<RaceTrack> raceTracks { get; set; }
    }
}
