using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPortalBlazorApp.Models
{
    public class Trainee
    {
        public string TrainingId { get; set; }
        public string EmpId { get; set; }
        public string Status { get; set; }
    }
}
