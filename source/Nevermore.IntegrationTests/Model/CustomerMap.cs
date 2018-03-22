using System.Data;
using Nevermore.Mapping;

namespace Nevermore.IntegrationTests.Model
{
    public class CustomerMap : DocumentMap<Customer>
    {
        public CustomerMap()
        {
            Column(m => m.FirstName).WithMaxLength(20);
            Column(m => m.LastName);
            Column(m => m.Roles);
            Column(m => m.AutoId).ReadOnly(true);
            Unique("UniqueCustomerNames", new[] { "FirstName", "LastName" }, "Customers must have a unique name");
        }
    }
}