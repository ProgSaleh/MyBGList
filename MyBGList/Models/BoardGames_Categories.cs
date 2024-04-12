using System.ComponentModel.DataAnnotations;

namespace MyBGList.Models
{
    public class BoardGames_Categories
    {
        [Key]
        [Required]
        public int BoardGameId { get; set; }

        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        public BoardGame? BoardGame { get; set; }

        public Category? Category { get; set; }
    }
}
