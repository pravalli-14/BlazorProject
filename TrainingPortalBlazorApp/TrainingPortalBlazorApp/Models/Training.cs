using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPortalBlazorApp.Models
{
    public class Training
    {
        public string TrainingId { get; set; }
        public string TrainerId { get; set; }
        public string TechnologyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
