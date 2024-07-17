using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Project_Cecilious.Model
{
    [PrimaryKey(nameof(ReviewId))]
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Restaurant")]

        public int RestaurantId { get; set; }

        public string Description { get; set; } = null!;

        public string? Image { get; set; } = null!;

        public float Rating { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual Restaurant Restaurant { get; set; } = null!;

       
    }
}
