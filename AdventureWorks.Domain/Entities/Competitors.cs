using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Domain.Entities
{
    public class Competitors : BaseEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}", ApplyFormatInEditMode = true)]
        public decimal BodyTemperature { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool IsRunner { get; set; }
        public decimal AverageRace { get; set; }
    }
}
