

public class NutritionalDetails
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public required string Calories { get; set;  }
    public required string Fat { get; set;  }
    public required string SaturatedFat { get; set; }
    public required string Carbohydrates { get; set;  }
    public required string Sugars { get; set; }
    public required string Polyols { get; set; }
    public required string Protein { get; set; }
    public required string Salt { get; set;  }
}