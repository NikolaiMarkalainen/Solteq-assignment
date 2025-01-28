

using System.ComponentModel.DataAnnotations.Schema;

namespace Solteq_server.models
{
    public class NutritionalDetails
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("product_id")]
        public required long ProductId { get; set; }
        [Column("calories")]
        public required string Calories { get; set;  }
        [Column("fat")]
        public required string Fat { get; set;  }
        [Column("saturated_fat")]
        public required string SaturatedFat { get; set; }
        [Column("carbohydrates")]
        public required string Carbohydrates { get; set;  }
        [Column("sugars")]
        public required string Sugars { get; set; }
        [Column("polyols")]
        public required string Polyols { get; set; }
        [Column("protein")]
        public required string Protein { get; set; }
        [Column("salt")]
        public required string Salt { get; set;  }
    }
}
