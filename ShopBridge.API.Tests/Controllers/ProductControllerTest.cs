using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridge.API.Controllers;
using ShopBridge.Data;

namespace ShopBridge.API.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        ProductController _controller = new ProductController();

        [TestMethod]
        public async void Get()
        {
            var response = await _controller.Get();

            var responseData = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(responseData.ToString());

            // Assert
            Assert.IsNotNull(result);
            Console.WriteLine(result);
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        //[TestMethod]
        //public void GetProducts()
        //{
        //    var response = _controller.Get();

        //    var responseData = response.Result.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<List<Product>>(responseData.ToString());

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Console.WriteLine(result);
        //    Assert.AreEqual("value1", result.ElementAt(0));
        //    Assert.AreEqual("value2", result.ElementAt(1));
        //}

        //[TestMethod]
        //public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        //{
        //    var response = await _controller.Get();

        //    var responseData = response.Content.ReadAsStringAsync();
        //    var testProducts = JsonConvert.DeserializeObject<List<Product>>(responseData.ToString());

        //    var controller = new ProductController(testProducts);

        //    var result = await controller.GetAllProductsAsync() as List<Product>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}


        [TestMethod]
        public async void GetById()
        {
            var result = await _controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public async void Post()
        {
            // Act
            //await _controller.Post("value");

            // Assert
        }

        [TestMethod]
        public async void Put()
        {
            // Act
            //_controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public async void Delete()
        {
            // Act
            //_controller.Delete(5);

            // Assert
        }
    }
}
