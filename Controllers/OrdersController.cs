using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class OrdersController : ApiController
    {
        NodeOrders500Entities myDB = new NodeOrders500Entities();
        // GET api/Orders
        public IHttpActionResult GetAllSalesPersons()
        {
            var allSalesPersons = from employees in myDB.SalesPersonTables
                                  select new { employees.FirstName, employees.LastName };

            List<string> salesPersons = new List<string>();
            foreach (var item in allSalesPersons)
            {
                salesPersons.Add(item.FirstName + " " + item.LastName);
            }
            return Json(salesPersons);
        }

        public IHttpActionResult GetAllSalesPersons(string id)
        {
            var pricePaid = from salesPerson in myDB.SalesPersonTables
                            join sales in myDB.Orders on salesPerson.salesPersonID equals sales.salesPersonID
                            where salesPerson.LastName == id
                            select sales.pricePaid;

            var totalSales = 0;
            foreach (var item in pricePaid)
            {
                totalSales += item;
            }
            return Json(totalSales);
        }
    }
}
