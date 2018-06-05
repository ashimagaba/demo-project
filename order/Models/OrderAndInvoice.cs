using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace order.Models
{

    public class OrderAndInvoice
    {
        SlipCartDatabaseContext context;

        public OrderAndInvoice()
        {

        }
        public OrderAndInvoice(SlipCartDatabaseContext context)
        {
            this.context = context;
        }
        public string[] PostForOrderInvoice(OrderedProducts orders)
        {
            //try
            //{

                string[] InvoiceData;
            List<SelectProductViewModel> products = orders.Products;
            string OrderNumber=Guid.NewGuid().ToString();
            string InvoiceNo = Guid.NewGuid().ToString();
            OrderDetails orderDetails = new OrderDetails() {
                OrderDate = orders.OrderDate,
                CustomerId = orders.CustomerId,
                InvoiceNo = InvoiceNo,
                 OrderNumber=OrderNumber
            };
               context.OrderDetails.Add(orderDetails);

                context.SaveChanges();

                //----get order id from orderdetails on the basis of OrderNumber
                int OrderId = context.OrderDetails.SingleOrDefault(c => c.OrderNumber == OrderNumber).OrderId;
                List<OrderedProductB2c> SelectedProducts = new List<OrderedProductB2c>();
                OrderedProductB2c data;Product product;
                foreach (SelectProductViewModel temp in orders.Products)
                {
                    data = new OrderedProductB2c()
                    {
                        OrderId = OrderId,
                        ProdId = temp.ProdId,
                        PurchasedQty = temp.PurchasedQty,
                        TotalPrice = temp.PurchasedQty * temp.ProdPrice
                    };
                    SelectedProducts.Add(data);
                    product=  context.Product.SingleOrDefault(c => c.ProdId == temp.ProdId);
                product.ProdQty = product.ProdQty - temp.PurchasedQty;
                }
                
                context.OrderedProductB2c.AddRange(SelectedProducts);
                context.SaveChanges();

                InvoiceData = new string[] { OrderNumber, InvoiceNo };

                return InvoiceData;

            
            //catch(Exception ex)
            //{
                

            //    return 
                
            }
        }

        
    }


