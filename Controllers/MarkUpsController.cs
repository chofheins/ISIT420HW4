using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class MarkUpsController : ApiController
    {
        NodeOrders500Entities myDB = new NodeOrders500Entities();
        // GET api/MarkUps
        public IHttpActionResult GetMarkUps()
        {
            var markUps = from city in myDB.StoreTables
                          join price in myDB.Orders on city.storeID equals price.storeID
                          where price.pricePaid > 13
                          group city by city.City into newGroup
                          orderby newGroup.Count() descending
                          select newGroup;

            List<MarkUp> markUpList = new List<MarkUp>();
            foreach (var group in markUps)
            {
                markUpList.Add(new MarkUp(group.Key, group.Count()));
            }
            return Json(markUpList);
        }
    }

    class MarkUp
    {
        public MarkUp(string pCity, int pCount)
        {
            Count = pCount;
            City = pCity; 
        }
        public int Count { get; set; }
        public string City { get; set; }
    }
}
