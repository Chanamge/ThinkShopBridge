using ShopBridge.BL;
using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;
        public ProductController()
        {
            this._productRepository = new ProductRepository();
        }

        List<Product> products = new List<Product>();
        public ProductController(List<Product> products)
        {
            this.products = products;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(Product product)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                _productRepository.InsertProduct(product);
                int res = _productRepository.Save();

                if (res > 0)
                {
                    var showmessage = "Product saved successfully.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showmessage = "Product not saved. Please try again.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int pageNumber, int pageSize)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            try
            {
                PagingParameterModel pagingModel = new PagingParameterModel()
                {
                    pageNumber = pageNumber,
                    pageSize = pageSize
                };
                var products = _productRepository.GetProducts(pagingModel);
                if (products == null || products.Data.Count() == 0)
                {
                    var showmessage = "Products not found.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }

                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                Product product = _productRepository.GetProductByID(id);
                if (product == null)
                {
                    var showmessage = string.Format("Product with id = {0} not found", id);
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(int id, Product product)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                Product exi_product = _productRepository.GetProductByID(id);

                foreach (PropertyInfo property in typeof(Product).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
                {
                    property.SetValue(exi_product, property.GetValue(product, null), null);
                }

                _productRepository.UpdateProduct(exi_product);
                int res = _productRepository.Save();

                if (res > 0)
                {
                    var showmessage = "Product updated successfully.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showmessage = "Product not updated. Please try again.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                Product product = _productRepository.GetProductByID(id);
                _productRepository.DeleteProduct(id);
                int res = _productRepository.Save();

                if (res > 0)
                {
                    var showmessage = "Product deleted successfully.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.OK, dict);
                }
                else
                {
                    var showmessage = "Product not deleted. Please try again.";
                    dict.Add("Message", showmessage);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
