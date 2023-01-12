using Microsoft.AspNetCore.Mvc;
using MongoDBLabb_Webbshop.Models;
using MongoDBLabb_Webbshop.Services;

namespace MongoDBLabb_Webbshop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService) => _productService = productService;

    [HttpGet]
    public async Task<List<Product>> Get() => await _productService.GetAsync();

    [HttpGet("{id:length(24)}")]

    public async Task<ActionResult<Product>> Get(string id)
    {
        var product = await _productService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product newProduct)
    {
        await _productService.CreateAsync(newProduct);

        return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Product updatedProduct)
    {
        var Product = await _productService.GetAsync(id);

        if (Product is null)
        {
            return NotFound();
        }

        updatedProduct.Id = Product.Id;

        await _productService.UpdateAsync(id, updatedProduct);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Product = await _productService.GetAsync(id);

        if (Product is null)
        {
            return NotFound();
        }

        await _productService.RemoveAsync(id);

        return NoContent();

    }
}
