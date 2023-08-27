using Microsoft.AspNetCore.Mvc;

namespace ITI.WebApplication.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Remote("IsNameValid", "Department",AdditionalFields = nameof(Id), ErrorMessage = "Name already exists")]
        public string Name { get; set; }

        public string? Notes { get; set; }

        public List<Student>? Students { get; set; }
    }
}
