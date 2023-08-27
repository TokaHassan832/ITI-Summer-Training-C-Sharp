using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(30,MinimumLength =3)]
        [Required]
        public string Name { get; set; }

        [Range(10,20)]
        public int? Age { get; set; }

        [RegularExpression(@"[a-zA-Z0-9_]+@[A-Za-z]+.[a-zA-Z]{2,4}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [DataType(DataType.Password)]
        [Display(Name = "Student Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

        public int? DeptNo { get; set; }

        [ForeignKey("DeptNo")]
        public Department Department { get; set; }

   
    }
}
