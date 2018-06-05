using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace order.Models
{
    public class SelectProductViewModel
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public int? ProdPrice { get; set; }
        public int? PurchasedQty { get; set; }
        public string ProdCode { get; set; }
    }


    public class OrderedProducts
    {
        public List<SelectProductViewModel> Products { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
