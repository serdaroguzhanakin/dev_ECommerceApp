using ECommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IConfiguration _configuration;
        


        List<Product> productList = new List<Product>();
        //List<Product> productList = new List<Product>()
        //{
        //    new Product(){Name="Bigisayar", Price= 500.17m, ImgUrl="https://productimages.hepsiburada.net/s/7/552/9768352383026.jpg" },
        //    new Product(){Name="Monitor", Price= 300, ImgUrl="https://productimages.hepsiburada.net/s/7/552/9772267438130.jpg" },
        //    new Product(){Name="Klavye", Price= 50, ImgUrl="https://productimages.hepsiburada.net/s/18/552/9790996840498.jpg" },
        //    new Product(){Name="Kamera", Price= 80, ImgUrl="https://productimages.hepsiburada.net/s/10/552/8940080332850.jpg" }
        //};
        private readonly ECommerceContext _context;
        public ProductController(ECommerceContext context, IConfiguration configuration)
        {
            //appsetting.json dan değer alma
            //_configuration = configuration;
            //string value = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            _context = context;
        }

        // GET api/product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //_context.Products.AddRange(productList);
            //_context.SaveChanges();



            return _context.Products.ToList();
        }

        [HttpGet("{name}")]
        //public Product Get(string name)
        //{
        //    return _context.Products.First(p => p.Name == name);
        //}


        //GET api/product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.First(p => p.ProductId == id);
        }

        [HttpGet, Route("GetByName/{productId}")]
        public Product Get([FromBody] Product product, int productId)
        {
            return _context.Products.FirstOrDefault();
        }



        [HttpGet, Route("GetByName2/{productID}/{flag}")]
        public Product Get(string productID, int flag)
        {
            return _context.Products.FirstOrDefault();
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost, Route("PostDeneme/{test}")]
        public void PostDeneme([FromBody]Product product, string test)
        {
            //_context.Products.Add(product);
            //_context.SaveChanges();
        }


        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product newProduct)
        {
            if (IsProductValid(id))
            {
                Product product = _context.Products.Find(id);
                product.Name = newProduct.Name;
                product.Price = newProduct.Price;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //List<Product> list = _context.Products.ToList();
            //foreach (var product in list)
            //{
            //    _context.Products.Remove(product);
            //    _context.SaveChanges();
            //}
            if (IsProductValid(id))
            {
                Product product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        private bool IsProductValid(int id)
        {
            Product product = _context.Products.First(p => p.ProductId == id);
            return product != null ? true : false;
        }
    }
}
