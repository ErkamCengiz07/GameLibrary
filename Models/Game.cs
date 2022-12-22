using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [DisplayName("Game Name")]
        [Required]
        [MaxLength(200)]
        public string GameName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Game Type")]
        [Required]
        [MaxLength(100)]
        public string GameType { get; set; }

        public Double Price { get; set; }

        public DateTime CreateDate { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string GameImage { get; set; }
    }
}
