using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGameShop
{
    [Table("Customer")]
    public class Customer
    {
        [PrimaryKey, NotNull] public string CustomerId { get; set; }

        [Column, NotNull] public string FirstName { get; set; }

        [Column, NotNull] public string LastName { get; set; }

        [Column] public string PatronymicName { get; set; }

        [Column, NotNull] public string Email { get; set; }

        [Column, NotNull] public DateTime Birthday { get; set; }

        [Column("Address"), NotNull] public string Address { get; set; }

        [Column("PasswordHash"), NotNull] public string PasswordHash { get; set; }
    }
}
