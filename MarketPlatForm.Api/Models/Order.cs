using MarketPlatForm.Api.Models.Base;

namespace MarketPlatForm.Api.Models
{
    public class Order : BaseEntity
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
