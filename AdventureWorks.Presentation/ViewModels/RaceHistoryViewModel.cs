using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Presentation.ViewModels
{
    public class RaceHistoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Competitor Id")]
        public int CompetitorId { get; set; }
        [Display(Name = "Race Track Id")]
        public int RaceTrackId { get; set; }
        [Display(Name = "Date Track")]
        public DateTime DateTrack { get; set; }
        [Display(Name = "Time Spent")]
        public string TimeSpent { get; set; }
        [Display(Name = "Competitor Name")]
        public string CompetitorName { get; set; }
        [Display(Name = "Track Description")]
        public string TrackDescription { get; set; }
    }
}
