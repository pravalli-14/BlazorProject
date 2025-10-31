using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPortalBlazorApp.Models
{
    public class Trainer
    {
        public string TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerType { get; set; }
        public string TrainerEmail { get; set; }
        public string TrainerPhoneNo { get; set; }
    }
}
