using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Simpel_api.Data;
using Simpel_api.Models;

namespace simpel_api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly string _path;

    public ProductsController(IWebHostEnvironment environment)
    {
        _environment = environment;
        _path = string.Concat(_environment.ContentRootPath, "/Data/products.json");

    }

    [HttpGet()]
    public ActionResult ListProducts()
    {
        var products = Storage<Product>.ReadJson(_path);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult FindProduct(int id)
    {
        var products = Storage<Product>.ReadJson(_path);
        Product product = products.SingleOrDefault(c => c.Id == id);

        if (product is null) return NotFound("Hittade inget");

        return Ok(product);
    }


    [HttpGet("search/{productName}")]
    public ActionResult FindByProductName(string productName)
    {
        return Ok();
    }

    [HttpPost()]
    public ActionResult AddProduct(Product product)
    {
        var products = Storage<Product>.ReadJson(_path);
        products.Add(product);
        Storage<Product>.WriteJson(_path, products);
        return Ok(201);
    }


    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product product)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        return NoContent();
    }
}


