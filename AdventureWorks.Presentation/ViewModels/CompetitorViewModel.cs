using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Presentation.ViewModels
{
    public class CompetitorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Body Temperature")]
        public string BodyTemperature { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public bool IsRunner { get; set; }
        [Display(Name = "Average Race")]
        public decimal AverageRace { get; set; }
    }
}
