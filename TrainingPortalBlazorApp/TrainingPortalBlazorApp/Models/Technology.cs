using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPortalBlazorApp.Models
{
    public class Technology
    {
        public string TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string Level { get; set; }
        public int Duration { get; set; }
    }
}
