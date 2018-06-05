using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndInvoice.Models
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
        public  List<SelectProductViewModel> Products { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

    }

    public class DemoProductContainer {
        public static List<SelectProductViewModel> GetProducts()
        {
            return new List<SelectProductViewModel>() {
            new SelectProductViewModel() { ProdId=4, ProdCode = "0", ProdName = "Shoe", ProdPrice = 200, PurchasedQty = 10 },
            new SelectProductViewModel() { ProdId=21,ProdCode = "1",ProdName = "Jeans", ProdPrice = 40, PurchasedQty = 20 },
            new SelectProductViewModel() { ProdId=1024,ProdCode = "2", ProdName = "activa", ProdPrice = 1323, PurchasedQty = 50 }
            };
        }
 }
}