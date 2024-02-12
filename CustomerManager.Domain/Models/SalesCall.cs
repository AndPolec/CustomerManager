using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models
{
    public class SalesCall : AuditableModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Objective { get; set; }
        public string Result { get; set; }  
        public DateTime Date { get; set; }
        public List<ProductSalesActivity> SalesActivities { get; set; }
    }
}
