using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column(TypeName = "VARCHAR(20)")]
        public string UserId { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
