using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQsql_1
{
    [Table(Name = "Customers")] 
    public class Customer
    {
        private string _CustomerID;
        private string _City;
        private string _CompanyName;
        private EntitySet<Order> _Orders;

        [Column(IsPrimaryKey = true, Storage = "_CustomerID")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
            }
        }
        
        [Column(Storage = "_City")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }
        
        [Column(Storage = "_CompanyName")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this._CompanyName = value;
            }
        }
        
        public override string ToString()
        {
            return CustomerID + "\t" + City + "\t" + CompanyName;
        }
       
        public Customer()
        {
            this._Orders = new EntitySet<Order>();
        }
        
        [Association(Storage = "_Orders", OtherKey = "CustomerID")]
        public EntitySet<Order> Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders.Assign(value);
            }
        }
    }
}
