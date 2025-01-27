
namespace Solteq_server.models
{
    public class Product 
    {
        public required int Id { get; set; }
        public required string Code { get; set;  }
        public required string  ProductName { get; set;  }
        public required string CustomText { get; set;  }
        public required string ProductWeight { get; set;  }
        public required string ProductWarning { get; set;  }
        public required string Ingredients { get; set; }
        public required string[] ProductContains { get; set; }
        public required string[] ProductDoesNotContain { get; set; }
        public NutritionalDetails? NutritionalDetails { get; set;  }
    }    
}
