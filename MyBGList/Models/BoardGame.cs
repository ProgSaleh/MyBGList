using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyBGList.Models
{
    [Table("BoardGames")]
    public class BoardGame
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public int MinPlayers { get; set; }

        [Required]
        public int MaxPlayers { get; set; }

        [Required]
        public int PlayTime { get; set; }

        [Required]
        public int MinAge { get; set; }

        [Required]
        public int UserRated { get; set; }

        [Required]
        [Precision(4, 2)]
        public decimal RatingAverage { get; set; }

        [Required]
        public int BGGRank { get; set; }

        [Required]
        [Precision(4, 2)]
        public decimal ComplexityAverage { get; set; }

        [Required]
        public int OwnedUser { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<BoardGames_Domains>? BoardGames_Domains { get; set; }
        public ICollection<BoardGames_Mechanics>? BoardGames_Mechanics { get; set; }

        [MaxLength(200)]
        public string? AlternateNames { get; set; }

        [MaxLength(200)]
        public string? Designer { get; set; }

        [Required]
        public int Flags { get; set; }

        // foreignKey to reference the current boardGame's publisher.
        // important when searching the db about a specific publisherId using boardgames...
        [Required]
        public int PublisherId { get; set; }

        // For one-to-many rel. Every BoardGame record must have a publisher.
        [Required]
        public Publisher Publisher { get; set; } = null!;

        public ICollection<BoardGames_Categories>? BoardGames_Categories { get; set; }
    }
}
