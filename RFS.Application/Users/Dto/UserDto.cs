using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using RFS.Core.Enums;
using RFS.Core.Security;
namespace RFS.Application.Dto
{
    public class UserDto
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
        [StringLength(50)]
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
        public UserDto FromIdentityUser(IdentityUser user)

        {
            return new UserDto
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                Email = user.Email,
                IsActive = user.IsActive,
                LanguagePreferred = user.LanguagePreferred,
                Mobile = user.Mobile,
                Name = user.Name,
                NationalID = user.NationalID,
                Title = user.Title,
                UserName = user.UserName,
                UserType = user.UserType,
                CreatedAt = user.CreatedAt
                
            };
        }

        public IdentityUser ToIdentityUser()
        {
            return new IdentityUser
            {
                Id = this.Id,
                CompanyName = this.CompanyName,
                Email = this.Email,
                IsActive = this.IsActive,
                LanguagePreferred = this.LanguagePreferred,
                Mobile = this.Mobile,
                Name = this.Name,
                NationalID = this.NationalID,
                UserName = this.UserName,
                UserType = this.UserType,
                Title = this.Title            
            };

        }

        public IdentityUser UpdateIdentityUser(IdentityUser user)
        {
            user.CompanyName = this.CompanyName;
            user.Email = this.Email;
            user.IsActive = this.IsActive;
            //user.LanguagePreferred = this.LanguagePreferred;
            user.Mobile = this.Mobile;
            user.Name = this.Name;
            user.NationalID = this.NationalID;
            user.UserName = this.UserName;
            //user.UserType = this.UserType;
            user.Title = this.Title;

            return user;
        }
    }
}
