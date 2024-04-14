using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Order")]
    public class Order
    {
        [PrimaryKey, NotNull] public string OrderId { get; set; }

        [Column, NotNull] public DateTime OrederDate { get; set; }

        [Column, NotNull] public float Sum { get; set; }

        [Column, NotNull] public string Status { get; set; }

        [Column, NotNull] public string DeliveryId { get; set; }

        [Column, NotNull] public string CustomerId { get; set; }

        [Column, NotNull] public string TransactionId { get; set; }

        [Association(ThisKey = "DeliveryId", OtherKey = "DeliveryId")]
        public Delivery Delivery { get; set; }

        [Association(ThisKey = "CustomerId", OtherKey = "CustomerId")]
        public Customer Customer { get; set; }

        [Association(ThisKey = "TransactionId", OtherKey = "TransactionId")]
        public Transaction Transaction { get; set; }
    }
}
