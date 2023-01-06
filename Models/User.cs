using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }
        public int Rank { get; set; }
    }
}
