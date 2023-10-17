using System.ComponentModel.DataAnnotations;

namespace Authentication.DomainLayer.Entities
{
    public class UserRole : EntityBase
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string? Name { get; set; }
        public UserRole(string name) => Name = name;
    }
}
