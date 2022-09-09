using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjects;
using System.Web.Mvc;
namespace BusinessLogic
{
    public class CustomerBL
    {
        public CustomBO AddCustomer(CustomerBO customerBO)
        {
            return new CustomerDAL().AddCustomer(customerBO);
        }
        public IEnumerable<SelectListItem> GetCustomerNames()
        {
            return new CustomerDAL().GetAllCustomerNames();
        }
    }
}
