namespace CustomerManager.Domain.Models
{
    public class SalesData
    {
        public int Id { get; set; }
        public int DistributorId { get; set; }
        public List<ActiveProduct> ActiveProducts { get; set; }
    }
}