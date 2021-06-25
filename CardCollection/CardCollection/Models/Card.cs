using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Card
    {
        [Column("Id")]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        
        public string SetId { get; set; }

        [Required]
        public string Rarity { get; set; }

        [Required]
        public int NumberInSet { get; set; }

        [Required]
        public string Illustrator { get; set; }

        [Required]
        public string Image { get; set; }

        // Variations of price: High, low, mid, market
        [Column(TypeName = "decimal(8,2)")]
        public Decimal Price { get; set; }

        [Required]
        public int ReleaseYear { get; set; }
    }
}
