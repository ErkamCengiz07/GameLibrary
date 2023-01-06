using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Models
{
    public class GameSale
    {
        [Key]
        public int GameSaleId { get; set; }
        public int CustomerId { get; set; }
        public int GameId { get; set; }
        public DateTime DateOfSell { get; set; }
    }
}
