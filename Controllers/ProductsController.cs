using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Simpel_api.Models;

namespace simpel_api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IList<Product> _products;
    public ProductsController()
    {
        _products =
        [
            new Product { Id = 1, ProdutName = "Eluttag", Price = 12.95M },
            new Product { Id = 2, ProdutName = "Stickkontakt", Price = 16.95M },
        ];
    }

    [HttpGet()]
    public ActionResult ListProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public ActionResult FindProduct(int id)
    {
        Product product = _products.FirstOrDefault(c => c.Id == id);

        if (product is null) return NotFound("Hittade inget");

        return Ok(product);
    }


    [HttpGet("search/{productName}")]
    public ActionResult FindByProductName(string productName)
    {
        Product product = _products.FirstOrDefault(c => c.ProdutName == productName);

        if (product is null) return NotFound("Hittade inget");

        return Ok(product);
    }

    [HttpPost()]
    public ActionResult AddProduct(Product product)
    {
        //Logik som sparar datat ner till en databas
        _products.Add(product);
        return StatusCode(201, _products);
    }


    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product product)
    {
        //Logik som sparar datat ner till en databas
        Product item = _products.FirstOrDefault(c => c.Id == id);

        if (item is null) return NotFound("Hittade fortfarande inget");

        _products.Remove(item);
        _products.Add(product);
        return Ok(200);
        //return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        //Logik som tar bort en product
        Product product = _products.FirstOrDefault(c => c.Id == id);
        _products.Remove(product);
        return NoContent();
    }
}


