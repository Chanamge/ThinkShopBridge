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

        [TestMethod]
        public void GetProducts_ShouldReturnProductList()
        {
            var result = _controller.Get(1, 10);
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
