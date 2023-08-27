using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ITI.WebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Remote("IsNameValid", "Student", AdditionalFields = nameof(Id), ErrorMessage = "Name already exists")]
        public string Name { get; set; }

        public int Age { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
