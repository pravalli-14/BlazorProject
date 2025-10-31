using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string EmpId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string EmpName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Designation { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string EmpEmail { get; set; }
        [Column(TypeName = "char(10)")]
        public string EmpPhoneNo { get; set; }
    }
}
