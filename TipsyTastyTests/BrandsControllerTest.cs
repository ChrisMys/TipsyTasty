using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsyTasty.Controllers;
using TipsyTasty.Data;
using TipsyTasty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TipsyTastyTests
{
    [TestClass]
    public class BrandsControllerTest
    {
        // In-Memory DB
        private ApplicationDbContext _context;
        // Empty list of Brands
        List<Brand> brands = new List<Brand>();
        // Declare the controller
        BrandsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            // Instantiate DB
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            // Create Mock Data
            var category = new Category { Id = 100, Name = "Test Category" };
            _context.Categories.Add(category);
            _context.SaveChanges();
            brands.Add(new Brand { Id = 101, Name = "Product One", AgeStatment = "2", AlcoholContent = 40, Category = category });
            brands.Add(new Brand { Id = 102, Name = "Product Two", AgeStatment = "3", AlcoholContent = 45, Category = category });
            brands.Add(new Brand { Id = 103, Name = "Product Six", AgeStatment = "4", AlcoholContent = 50, Category = category });

            foreach (var p in brands)
            {
                _context.Brands.Add(p);
            }
            _context.SaveChanges();

            // Instantiate the Controller with the mock data
            controller = new BrandsController(_context);
        }

        // INDEX (GET)
        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            // Assert
            Assert.AreEqual("Index", viewResult.ViewName);
        }

        // INDEX (GET)
        [TestMethod]
        public void IndexReturnsProductData()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Index();
            var viewResult = (ViewResult)result.Result;
            // Extract a list of brands generated in the controller
            var model = (List<Brand>)viewResult.Model;
            // Match the ordering present in the brand controller
            var orderedProducts = brands.OrderBy(p => p.Name).ToList();
            // Assert
            CollectionAssert.AreEqual(orderedProducts, model);
        }

    }
}
