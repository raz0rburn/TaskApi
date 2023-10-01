using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace TaskApi.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        [Required]
        [StringLength(32)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(32)]
        public string LastName { get; set; }
        [Required]
        [StringLength(32)]
        public string Patronymic { get; set; }
        [Required]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [StringLength(32)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
}