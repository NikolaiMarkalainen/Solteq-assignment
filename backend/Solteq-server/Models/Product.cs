using System.ComponentModel.DataAnnotations.Schema;

namespace Solteq_server.models
{
    public class Product 
    {
        [Column("id")]
        public required long Id { get; set; }
        [Column("product_name")]
        public required string ProductName { get; set;  }
        [Column("custom_text")]
        public required string CustomText { get; set;  }
        [Column("weight")]
        public required string Weight { get; set;  }
        [Column("warning")]
        public required string Warning { get; set;  }
        [Column("ingredients")]
        public required string Ingredients { get; set; }
        [Column("product_contains")]
        public required string ProductContains { get; set; }
        [Column("product_does_not_contain")]
        public required string ProductDoesNotContain { get; set; }

        public NutritionalDetails? NutritionalDetails { get; set; }
    }    
}
