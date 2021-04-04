using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
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

        //[TestMethod]
        //public void Get()
        //{
        //    var response = _controller.Get();

        //    var responseData = response.Result.Content.ToString();
        //    Console.WriteLine(responseData);
        //    var result = JsonConvert.DeserializeObject<List<Product>>(responseData.ToString());

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Console.WriteLine(result);
        //    Assert.AreEqual("value1", result.ElementAt(0));
        //    Assert.AreEqual("value2", result.ElementAt(1));
        //}

        [TestMethod]
        public void GetProducts_ShouldReturnProductList()
        {
            var result = _controller.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostProduct_ShouldCreateProduct()
        {
            var product = GetDemoProduct();

            var result = _controller.Post(product);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProduct()
        {
            var result = _controller.Get(2);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PutProduct_ShouldUpdateProduct()
        {
            var product = GetDemoProduct();

            var result = _controller.Put(2, product);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteProduct_ShouldDeleteProduct()
        {
            var result = _controller.Delete(2);
            Assert.IsNotNull(result);
        }

        Product GetDemoProduct()
        {
            return new Product() { Id = 3, Name = "Demo name", Description = "Demo Description", Price = 5, Type = "Demo Type" };
        }
    }
}
