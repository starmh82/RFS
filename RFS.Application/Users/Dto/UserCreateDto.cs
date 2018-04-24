using RFS.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
namespace RFS.Application.Dto
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public virtual string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?:.*[a-z]){2,}$", ErrorMessage = "Name length must be greater than or equal 2 characters.")]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(10)]
        public virtual string NationalID { get; set; }
        [Required]
        [StringLength(10)]
        public virtual string Mobile { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string CompanyName { get; set; }
        public Langauge LanguagePreferred { get; set; }
        public bool IsActive { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; protected set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm not equal")]
        public string ConfirmPassword { get; set; }

        public UserCreateDto()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
