using Microsoft.AspNetCore.Mvc;
using PizzaOrderApp.Models;
using System.Collections.Generic;

namespace PizzaOrderApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("RequestOrder", new { age = user.Age });
            }
            return View(user);
        }

        public IActionResult RequestOrder(int age) // Змінено з Order на RequestOrder
        {
            if (age < 16)
            {
                return RedirectToAction("Register");
            }
            return View();
        }

        [HttpPost]
        public IActionResult OrderQuantity(int quantity) // Змінено на OrderQuantity
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Маргарита", Price = 100 },
                new Product { Name = "Пепероні", Price = 120 },
                new Product { Name = "Гавайська", Price = 140 }
            };

            return View("OrderForm", products);
        }

        [HttpPost]
        public IActionResult ConfirmOrder(List<int> quantities)
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Маргарита", Price = 100 },
                new Product { Name = "Пепероні", Price = 120 },
                new Product { Name = "Гавайська", Price = 140 }
            };

            var orderDetails = new List<string>();
            for (int i = 0; i < products.Count; i++)
            {
                if (quantities[i] > 0)
                {
                    orderDetails.Add($"{products[i].Name}: {quantities[i]} одиниць");
                }
            }

            return View("OrderSummary", orderDetails);
        }
    }
}
