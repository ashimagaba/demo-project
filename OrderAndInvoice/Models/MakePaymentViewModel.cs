using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MM2.Controllers
{
    public class MakePaymentViewModel
    {
        public string CustomerName { get; set; }
        public double Amount { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        [StringLength(10)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(3,MinimumLength =3)]
        public string CVVNumber { get; set; }

        [Required]
        [StringLength(4,MinimumLength=4)]
        public string Pin { get; set; }

        public MakePaymentViewModel()
        {
            
        }
    }
}
