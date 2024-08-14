using MarketPlatForm.Api.Models.Base;

namespace MarketPlatForm.Api.Models
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; }=string.Empty;
    }
}
