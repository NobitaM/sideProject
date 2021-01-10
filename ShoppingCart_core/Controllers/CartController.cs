using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShoppingCart_core.Helpers;

namespace ShoppingCart_core.Controllers
{
    [Route("cart")]
    public class CartController:Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session , "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(x => x.Product.Price * x.Quantity);
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            ProductModel productModel = new ProductModel();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> listCart = new List<Item>();
                listCart.Add(new Item { Product = productModel.findFromID(id), Quantity = 1 });
                SessionHelper.SetObjectToJson(HttpContext.Session, "cart", listCart);
            }
            else
            {
                List<Item> listCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    listCart[index].Quantity++;
                }
                else {
                    listCart.Add(new Item { Product = productModel.findFromID(id), Quantity = 1 });
                }

                SessionHelper.SetObjectToJson(HttpContext.Session, "cart", listCart);

            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(string id)
        {
            List<Item> listCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            listCart.RemoveAt(index);
            SessionHelper.SetObjectToJson(HttpContext.Session, "cart", listCart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> listCart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < listCart.Count; i++)
            {
                if (listCart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
