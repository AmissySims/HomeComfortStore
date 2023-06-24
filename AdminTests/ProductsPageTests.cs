using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComfortStoreLibrary.Models;
using Admin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Pages.Tests
{
    [TestClass()]
    public class ProductsPageTests
    {
        [TestMethod()]
        public void ProductsPageTest()
        {
            Product prod = new Product();   
            prod.Title = "Test";
            prod.Description = "TestDes"; 
            prod.Price = 100;
            prod.Count = 2;
            App.db.Product.Add(prod);
            App.db.SaveChanges();
            var product = App.db.Product.FirstOrDefault(x => x.Title == prod.Title);
            Assert.IsTrue(product != null);


        }

        [TestMethod()]
        public void ProductsPageTest1()
        {
            Product prod = new Product();
            prod.Title = "Test1";
            prod.Description = "TestDes";
            prod.Price = 100;
            prod.Count = 2;
            App.db.Product.Add(prod);
            App.db.SaveChanges();
            var product = App.db.Product.FirstOrDefault(x => x.Title == prod.Title);
            prod.Title = "123";
            prod.Count = 0;
            App.db.SaveChanges();
            var product1 = App.db.Product.FirstOrDefault(x => x.Title == "123");
            Assert.IsTrue(product != null);


        }

        [TestMethod()]
        public void ProductsPageTest2()
        {
            Product prod = new Product();
            prod.Title = "Test2";
            prod.Description = "TestDes";
            prod.Price = 100;
            prod.Count = 2;
            App.db.Product.Add(prod);
            App.db.SaveChanges();

            var product = App.db.Product.FirstOrDefault(x => x.Title == prod.Title);
            App.db.Product.Remove(product);
            App.db.SaveChanges();
            Assert.IsTrue(product != null);


        }
    }
}