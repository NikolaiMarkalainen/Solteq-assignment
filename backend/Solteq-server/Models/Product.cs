public class Product 
{
    public required int Id { get; set; }
    public required string  ProductName { get; set;  }
    public required string CustomText { get; set;  }
    public required string ProductWeight { get; set;  }
    public required string ProductWarning { get; set;  }
    public required string Code { get; set;  }

    public nutrtionalDetails? NutritionalDetails { get; set;  }
}