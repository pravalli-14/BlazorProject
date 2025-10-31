using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyLibrary.Models
{
    public class LevelValidation
    {
        public static ValidationResult IsValidLevel(string level)
        {
            if (level == "B" || level == "I" || level == "A")
                return ValidationResult.Success;
            else
                return new ValidationResult("Invalid Technology Level");
        }
    }
    [Table("Technology")]
    public class Technology
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string TechnologyId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string TechnologyName { get; set; }
        [Column(TypeName = "char(1)")]
        [CustomValidation(typeof(LevelValidation), "IsValidLevel")]
        public string Level { get; set; }
        public int Duration { get; set; }
    }
}
