using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Solteq_server.models
{
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("username")]
        public required string Username { get; set; }
        [Column("password")]
        public required string Password { get; set; }
    }
}