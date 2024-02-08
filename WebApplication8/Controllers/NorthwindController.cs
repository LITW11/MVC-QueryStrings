using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class NorthwindController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";

        public ActionResult Orders()
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            OrdersViewModel vm = new OrdersViewModel
            {
                Orders = mgr.GetOrders(),
                TodaysDate = DateTime.Today
            };
            return View(vm);
        }

        public ActionResult OrderDetails(int year)
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            OrderDetailsViewModel vm = new OrderDetailsViewModel
            {
                OrderDetails = mgr.GetOrderDetails(year)
            };
            return View(vm);
        }

        public ActionResult OrdersByYear(int year, string country)
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            OrdersByYearViewModel vm = new OrdersByYearViewModel
            {
                Orders = mgr.GetOrdersByYear(year, country),
            };
            return View(vm);
        }

        public ActionResult Categories()
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            return View(new CategoriesViewModel
            {
                Categories = mgr.GetCategories()
            });
        }

        public ActionResult Products(int categoryId = 1)
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            ProductsViewModel vm = new ProductsViewModel
            {
                Products = mgr.GetProductsForCategory(categoryId),
                CategoryName = mgr.GetCategoryName(categoryId)
            };

            return View(vm);
        }

        public ActionResult ProductSearch()
        {
            return View();
        }

        public ActionResult ProductSearchResults(string searchText)
        {
            NorthwindDbManager mgr = new NorthwindDbManager(_connectionString);
            return View(new ProductsSearchViewModel
            {
                Products = mgr.SearchProducts(searchText),
                SearchText = searchText
            });
        }
    }
}

//Create an application that has two pages:
// /northwind/categories
// /northwind/products

//On the categories page, display a list of all categories in the northwind database
//(id, name, description). The name of the category should be a link, that when clicked
//takes the user to the products page. On the products page, only the products
//for the category that was clicked on should be displayed. Additionally, on top of
//the products page, have an H1 that says "Products for Category {CategoryName}"