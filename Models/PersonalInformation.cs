using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class PersonalInformation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Forename { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Zip code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip code must be exactly 5 digits.")]
        public string ZipCode { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        [Display(Name = "Email address")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$", ErrorMessage = "Invalid email format.")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Type of training")]
        public String TypeOfTraining { get; set; }

        [Required]
        [Display(Name = "Formation Cobol")]
        public String CobolReview { get; set; }
        [Required]
        [Display(Name = "Formation C#")]
        public String CsharpReview { get; set; }

    }
}
