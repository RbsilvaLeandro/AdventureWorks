using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Domain.DTO
{
    public class RaceHistoryDTO
    {
        public int Id { get; set; }
        public int CompetitorId { get; set; }
        public int RaceTrackId { get; set; }
        public DateTime DateTrack { get; set; }
        public decimal TimeSpent { get; set; }
        public string CompetitorName { get; set; }
        public string TrackDescription { get; set; }

    }
}
