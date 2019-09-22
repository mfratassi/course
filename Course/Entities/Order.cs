using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        List<OrderItem> OrderItems { get; set; } = new List<OrderItem> { };

        public Order()
        {
            Moment = DateTime.Now;
        }

        public Order(OrderStatus status)
        {
            Status = status;
            Moment = DateTime.Now;
        }

        public Order(OrderStatus status, Client client) : this(status)
        {
            Client = client;
            Moment = DateTime.Now;
        }

        public Order(OrderStatus status, Client client, List<OrderItem> orderItems) : this(status, client)
        {
            OrderItems = orderItems;
            Moment = DateTime.Now;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        public double Total()
        {
            double total = 0.0; 
            foreach(OrderItem oi in OrderItems)
            {
                total += oi.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.AppendLine();
            s.AppendLine("ORDER SUMMARY");
            s.AppendLine();
            s.AppendLine($"Order Moment: {Moment}");
            s.AppendLine($"Client: {Client.Name} {Client.BirthDate.ToShortDateString()} - {Client.Email}");
            s.AppendLine("Order Items: ");
            foreach (OrderItem oi in OrderItems)
            {
                s.Append($"{ oi.Product.Name}, ");
                s.Append($"R$ {oi.Price.ToString("F2", CultureInfo.InvariantCulture)}, ");
                s.Append($"Quantity: {oi.Quantity}, ");
                s.AppendLine($"Subtotal: R$ {oi.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            s.AppendLine();
            s.AppendLine($"Total Price: R$ {Total().ToString("F2", CultureInfo.InvariantCulture)}");

            return s.ToString();
        }
    }
}
