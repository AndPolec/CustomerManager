namespace CustomerManager.Domain.Models
{
    public class CustomerSalesData
    {
        public int Id { get; set; }
        public int? DistributorId { get; set; }
        public List<PurchasedProductDetails> ActiveProducts { get; set; }
        public string Notes { get; set; }
    }
}