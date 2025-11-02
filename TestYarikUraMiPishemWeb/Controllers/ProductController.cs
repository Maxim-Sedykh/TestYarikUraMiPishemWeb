using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestYarikUraMiPishemWeb.Dto;
using TestYarikUraMiPishemWeb.Entities;

namespace TestYarikUraMiPishemWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationContext _context;

    public ProductController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("get-all")]
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToArrayAsync();
    }

    [HttpGet("get-by-id")]
    public IActionResult GetById(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return BadRequest("ты шо дядя,мы не можем найти такой товар по такому айдишнику");
        }

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto dto)
    {
        var product = new Product()
        {
            Amount = 0,
            Cost = dto.Cost,
            Name = dto.Name,
        };

        _context.Add(product);

        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("update")]
    public IActionResult UpdateProduct(UpdateProductDto dto)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == dto.Id);
        if (product == null)
        {
            return BadRequest();
        }

        product.Name = dto.Name;
        product.Cost = dto.Cost;

        _context.Update(product);

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("delete")]
    public IActionResult DeleteById(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return BadRequest();
        }

        _context.Remove(product);

        _context.SaveChanges();

        return Ok();
    }
}
