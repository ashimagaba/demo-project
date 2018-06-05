using System;
using System.Collections.Generic;

namespace order.Models
{
    public  class Customer
    {
        

        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerMailId { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGender { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        
    }
}
