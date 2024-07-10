using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Project_Cecilious.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public int Phone { get; set; }

        public DateTime CreateDate { get; set; }

        public string Gender { get; set; } = null!;

        public string? Avatar { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }

}
