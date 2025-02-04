using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // For table relations

namespace dotnet_authentication.Models
{
    public class UserTask
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public required string TaskTitle { get; set; } = string.Empty;
        [Required]
        public required string TaskDescription { get; set; } = string.Empty;

        // Foreign key to User
        [Required]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public virtual User? User { get; set; } = null!;
    }
}