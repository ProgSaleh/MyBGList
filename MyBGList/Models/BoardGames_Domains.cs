using System.ComponentModel.DataAnnotations;

namespace MyBGList.Models
{
    // Since we have the [Key] annotation on more than one prop,
    // this indicates that we need a composite primary key for this table.
    // This feature is supported in EF Core via the OnModelCreating().. Fluent API
    public class BoardGames_Domains
    {
        [Key]
        [Required]
        public int BoardGameId { get; set; }

        [Key]
        [Required]
        public int DomainId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public BoardGame? BoardGame { get; set; }

        public Domain? Domain { get; set; }
    }
}
