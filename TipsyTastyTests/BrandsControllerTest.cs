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

        // CREATE #1 (GET THE VIEW)
        [TestMethod]
        public void CreateViewLoads()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = (ViewResult)controller.Create();
            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        // CREATE #2 (POST WAS SUCCESSFUL)
        [TestMethod]
        public void PostCreateBrand()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            Brand newBrand = new Brand { Image = null, Id = 104, Name = "Test", AgeStatment = "4", AlcoholContent = 45, CategoryId = 100 };
            var result = controller.Create(newBrand, null);
            // Assert
            var brand = _context.Brands.Where(b => b.Name == newBrand.Name).FirstOrDefault();
            Assert.IsNotNull(brand);
        }

        // CREATE #3 (POST WAS NOT SUCCESSFUL)
        [TestMethod]
        public void PostCreateBrandFailure()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            Brand newBrand = new Brand { Image = null, Id = 105, AgeStatment = "4", AlcoholContent = 45, CategoryId = 100 };
            var result = controller.Create(newBrand, null);
            // Assert
            var brand = _context.Brands.Where(b => b.Name == newBrand.Name).FirstOrDefault();
            Assert.IsNull(brand);
        }

        // EDIT #1 (GET THE VIEW)
        [TestMethod]
        public void EditViewLoads()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Edit(101);
            var viewResult = (ViewResult)result.Result;
            // Assert
            Assert.AreEqual("Edit", viewResult.ViewName);
        }

        // EDIT #2 (NOT FOUND)
        [TestMethod]
        public void GetEditNotFoundWithNoId()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Edit(null);
            var notFoundResult = (NotFoundResult)result.Result;
            // Assert
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // DELETE #1 (GET THE VIEW)
        [TestMethod]
        public void DeleteViewLoads()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Delete(101);
            var viewResult = (ViewResult)result.Result;
            // Assert
            Assert.AreEqual("Delete", viewResult.ViewName);
        }

        // DELETE #2 (NOT FOUND)
        [TestMethod]
        public void GetDeleteNotFoundWithNoId()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Delete(null);
            var notFoundResult = (NotFoundResult)result.Result;
            // Assert
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // DETAILS #1 (GET THE VIEW)
        [TestMethod]
        public void DetailViewLoads()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Details(101);
            var viewResult = (ViewResult)result.Result;
            // Assert
            Assert.AreEqual("Details", viewResult.ViewName);
        }

        // DETAILS #2 (NOT FOUND)
        [TestMethod]
        public void GetDetailsNotFoundWithNoId()
        {
            // Arrange - logic is happening in TestInitialize
            // Act
            var result = controller.Details(null);
            var notFoundResult = (NotFoundResult)result.Result;
            // Assert
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

    }
}
