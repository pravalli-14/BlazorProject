using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPortalBlazorApp.Models
{
    public class Employee
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPhoneNo { get; set; }
    }
}
