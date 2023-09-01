using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Email Id")]
        //[Range(1, 100, ErrorMessage = "Emaid Id should be  between 1 & 100")]
        public string? Email { get; set; }
        
        [Required]
        [DisplayName("Password")]
       // [Range(1, 15, ErrorMessage = "Password should be  between 1 & 15")]
        public string? Password { get; set; }

        [Required]
        [DisplayName("Username")]
        //[Range(1, 15, ErrorMessage = "User Name should be between 1 & 15")]
        public string? UserName { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        public string? Mobile { get; set; }
        [Required]
        [DisplayName("Designation")]
        public string? Designation { get; set; }
        public int IsAdmin { get; set; } = 0; // 0 means not admin and 1 means admin

        [Required]
        [DisplayName("Confirm Password")]
        //[Range(1, 15, ErrorMessage = "Password should be between 1 & 15")]
        public string? ConfirmPassword { get; set; }
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
