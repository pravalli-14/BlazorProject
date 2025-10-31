using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Technology")]
    public class Technology
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string TechnologyId { get; set; }
        public virtual ICollection<Training>? Trainings { get; set; } = new List<Training>();
    }
}
