using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class EmployeeMaster
    {
        [Key]
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string MiddleName { set; get; }
        public string LastName { set; get; }
    }
}
