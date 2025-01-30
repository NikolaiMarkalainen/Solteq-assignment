

using System.ComponentModel.DataAnnotations.Schema;

namespace Solteq_server.models
{
    public class GenericProduct 
    {
        [Column("id")]
        public required long Id { get; set; }
        [Column("product_name")]
        public required string ProductName { get; set; }
        [Column("category")]
        public required string Category { get; set; }
    }
}
