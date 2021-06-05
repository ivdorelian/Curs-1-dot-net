using System;
using Curs_1.Data;
using Curs_1.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{

    public class Test_ProductsService
    {
        private ApplicationDbContext _context;
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("In setup.");
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new ApplicationDbContext(options, new OperationalStoreOptionsForTests());

            _context.Products.Add(new Curs_1.Models.Product { Name = "p1 test", Description = "fsd ds fsd fsd", Price = 200 });
            _context.Products.Add(new Curs_1.Models.Product { Name = "p2 test", Description = "dfs sd sd fsd", Price = 300 });
            _context.SaveChanges(); 
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("In teardown");

            foreach (var product in _context.Products)
            {
                _context.Remove(product);
            }
            _context.SaveChanges();
        }

        [Test]
        public void TestGetByMinPrice()
        {
            var service = new ProductsService(_context);
            Assert.AreEqual(2, service.GetAllAbovePrice(100).Count);
            Assert.AreEqual(1, service.GetAllAbovePrice(250).Count);
            Assert.AreEqual(2, service.GetAllAbovePrice(200).Count);
            Assert.AreEqual(0, service.GetAllAbovePrice(500).Count);
        }

        [Test]
        public void TestGetByMinPrice2()
        {
            var service = new ProductsService(_context);
            Assert.AreEqual(2, service.GetAllAbovePrice(100).Count);
            Assert.AreEqual(1, service.GetAllAbovePrice(250).Count);
            Assert.AreEqual(2, service.GetAllAbovePrice(200).Count);
            Assert.AreEqual(0, service.GetAllAbovePrice(500).Count);
        }
    }
}