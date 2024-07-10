using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AccountId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Role { get; set; }

        public int Status { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
