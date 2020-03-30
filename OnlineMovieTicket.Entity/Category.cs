using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicket.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        public ICollection<Movie> Movies { get; set; }

    }
}
