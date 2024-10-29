using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questioner.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
