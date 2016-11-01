using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hangout.Models;

namespace Hangout.Controllers
{
    public class ItemController : ApiController
    {
        public ItemListResponse GetItemList(int objectId)
        {
            ItemListResponse resp = new ItemListResponse();
            IList<Item> itemList = new List<Item>();
            itemList.Add(new Item { ItemId = 1, ItemName = "xxxxx1", Description = "xxxxDesc1", Price = 4.13 });
            itemList.Add(new Item { ItemId = 2, ItemName = "xxxxx2", Description = "xxxxDesc2", Price = 4.23 });
            itemList.Add(new Item { ItemId = 3, ItemName = "xxxxx3", Description = "xxxxDesc3", Price = 4.39 });
            itemList.Add(new Item { ItemId = 4, ItemName = "xxxxx4", Description = "xxxxDesc4", Price = 4.49 });
            resp.ItemList = itemList;
            return resp;
        }

        public void GetItemDetails(int objectId)
        {
            
        }
        public void GetItemComments(int objectId)
        {

        }

        public void AddComments(int objectId)
        {

        }
    }
}
