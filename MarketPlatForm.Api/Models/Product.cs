using MarketPlatForm.Api.Models.Base;

namespace MarketPlatForm.Api.Models
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public long CateogryId { get; set; }
        public string ImagePath { get; set; } =string.Empty;
        public decimal Price { get; set; }
    }
}
