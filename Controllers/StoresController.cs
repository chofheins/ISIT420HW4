using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class StoresController : ApiController
    {
        NodeOrders500Entities myDB = new NodeOrders500Entities();
        // GET api/Stores
        public IHttpActionResult GetAllStoreLocations()
        {
            var allStoreLocations = from stores in myDB.StoreTables
                                  select stores.City;

            List<string> storeLocations = new List<string>();
            foreach (var item in allStoreLocations)
            {
                storeLocations.Add(item);
            }
            return Json(storeLocations);
        }

        // GET api/Stores/City
        public IHttpActionResult GetAllStoreLocations(string id)
        {
            var pricePaid = from store in myDB.StoreTables
                            join sales in myDB.Orders on store.storeID equals sales.storeID
                            where store.City == id
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
