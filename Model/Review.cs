using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_Cecilious.Model
{
    public class Review
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Restaurant")]

        public int RestaurantId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public float Rating { get; set; }

        public DateOnly CreateTime { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual Restaurant Restaurant { get; set; } = null!;

       
    }
}
