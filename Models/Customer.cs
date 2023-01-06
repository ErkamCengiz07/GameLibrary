using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibrary.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }
    }
}
