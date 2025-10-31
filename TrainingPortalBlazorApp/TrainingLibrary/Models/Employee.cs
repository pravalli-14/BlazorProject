using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string EmpId { get; set; }
        public virtual ICollection<Trainee>? TrainingsAttended { get; set; } = new List<Trainee>();
    }
}
