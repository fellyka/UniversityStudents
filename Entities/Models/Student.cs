

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Student
    {
        [Column("StudentId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Student name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field")]
        public int Age { get; set; }

        // Navigational properties
        [ForeignKey(nameof(Faculty))]
        public Guid FacultyId { get; set; }
        public Faculty? Faculty { get; set; }


    }
}
