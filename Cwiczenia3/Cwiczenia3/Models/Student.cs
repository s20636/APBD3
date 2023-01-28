using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Cwiczenia3.Models
{
    public class Student
    {
        [Required]
        [Index(0)]
        public string FirstName { get; set; }
        [Required]
        [Index(1)]
        public string LastName { get; set; }
        [RegularExpression(@"s\d+")]
        [Required]
        [Index(2)]
        public string IndexNumber { get; set; }
        [Required]
        [Index(3)]
        public string BirthDate { get; set; }
        [Required]
        [Index(4)]
        public string Studies { get; set; }
        [Required]
        [Index(5)]
        public string Mode { get; set; }
        [Required]
        [EmailAddress]
        [Index(6)]
        public string Email { get; set; }
        [Required]
        [Index(7)]
        public string MothersName { get; set; }
        [Required]
        [Index(8)]
        public string FathersName { get; set; }
    }
}
