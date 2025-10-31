using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary.Models
{
    public class TrainerTypeValidation
    {
        public static ValidationResult IsValidTrainerType(string trainertype)
        {
            if (trainertype == "I" || trainertype == "E")
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid Trainer Type");
        }
    }
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string TrainerId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string TrainerName { get; set; }
        [Column(TypeName = "char(1)")]
        [CustomValidation(typeof(TrainerTypeValidation), "IsValidTrainerType")]
        public string TrainerType { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string TrainerEmail { get; set; }
        [Column(TypeName = "char(10)")]
        public string TrainerPhoneNo { get; set; }
    }
}
