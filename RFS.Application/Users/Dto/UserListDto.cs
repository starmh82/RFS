using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using RFS.Core.Enums;
using RFS.Core.Security;
namespace RFS.Application.Dto
{
    public class UserListDto
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(50)]
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

        public UserListDto()
        {
            CreatedAt = DateTime.Now;
        }
        public UserListDto FromIdentityUser(IdentityUser user)

        {
            return new UserListDto
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                Email = user.Email,
                IsActive = user.IsActive,
                LanguagePreferred = user.LanguagePreferred,
                Mobile = user.Mobile,
                Name = user.Name,
                NationalID = user.NationalID,
                UserName = user.UserName,
                UserType = user.UserType
            };
        }

    }
}
