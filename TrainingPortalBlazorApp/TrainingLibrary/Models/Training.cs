using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Training")]
    public class Training
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string TrainingId { get; set; }
        [ForeignKey("Trainer")]
        [Column(TypeName = "char(6)")]
        public string TrainerId { get; set; }
        [ForeignKey("Technology")]
        [Column(TypeName = "char(6)")]
        public string TechnologyId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime EndDate { get; set; }
        public virtual Trainer? Trainer { get; set; }
        public virtual Technology? Technology { get; set; }

        public virtual ICollection<Trainee>? Trainees { get; set; } = new List<Trainee>();
    }
}
