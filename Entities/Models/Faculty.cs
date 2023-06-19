
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Faculty
    {
        [Column("FacultyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Faculty name is a required field.")]
        [MaxLength(30, ErrorMessage ="Maximum length for faculty name is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Faculty building's name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for faculty building's name is 30 characters.")]
        public string? BuildingName { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
