using RFS.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using RFS.Core.Security;
namespace RFS.Application.Dto
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public virtual string Title { get; set; }
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

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm not equal")]
        public string ConfirmPassword { get; set; }

        public IdentityUser ToIdentityUser()
        {
            return new IdentityUser
            {
                CompanyName = this.CompanyName,
                Email = this.Email,
                IsActive = this.IsActive,
                LanguagePreferred = this.LanguagePreferred,
                Mobile = this.Mobile,
                Name = this.Name,
                NationalID = this.NationalID,
                Password = this.Password,
                Title = this.Title,
                UserType = this.UserType,
                UserName = this.UserName
            };
        }
    }
}
