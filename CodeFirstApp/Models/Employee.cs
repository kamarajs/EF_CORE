using Microsoft.AspNetCore.Routing.Matching;

using CodeFirstApp.Data;

using CodeFirstApp.Controllers;

using System.ComponentModel.DataAnnotations;

namespace EF.Models.CodeFirstApp

{

    public class Employees

    {

        [Key]

        public int Id { get; set; }

        [Required]

        public string? Name { get; set; }

        [Required]

        public string? Email { get; set; }

        [Required]

        public long Salary { get; set; }

        [Required]

        public String? DatofBirth { get; set; }

        [Required]

        public string? Department { get; set; }




    }

}