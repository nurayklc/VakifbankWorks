using NLayeredAPI.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace NLayeredAPI.Dto.Dtos
{
    public class AccountDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [EmailAddressAttribute]
        [MaxLength(500)]
        public string Email { get; set; }

        [Required]
        public int Role { get; set; }


        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
