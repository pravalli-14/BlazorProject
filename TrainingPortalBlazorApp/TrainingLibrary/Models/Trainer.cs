using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string TrainerId { get; set; }
        public virtual ICollection<Training>? Trainings { get; set; } = new List<Training>();
    }
}
