using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    public class StatusValidation
    {
        public static ValidationResult IsValidStatus(string status)
        {
            if (status == "C" || status == "I")
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid Status");
        }
    }
    [Table("Trainee")]
    [PrimaryKey("TrainingId", "EmpId")]
    public class Trainee
    {
        [ForeignKey("Training")]
        [Column(TypeName = "char(6)")]
        public string TrainingId { get; set; }
        [ForeignKey("Employee")]
        [Column(TypeName = "char(6)")]
        public string EmpId { get; set; }
        [Column(TypeName = "char(1)")]
        [CustomValidation(typeof(StatusValidation), "IsValidStatus")]
        public string Status { get; set; }
        public virtual Training? Training { get; set; }
        public virtual Employee? Employee { get; set; }
    }

}
