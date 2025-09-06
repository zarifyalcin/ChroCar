using ChroCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly ChroCarDbContext _context;

    public BrandsController(ChroCarDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Brand>> PostBrand(CreateBrandDto brandDto)
    {
        var brand = new Brand
        {
            BrandName = brandDto.BrandName
        };

        try
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            // Başarılı olursa 201 Created yanıtı dön
            return CreatedAtAction(nameof(GetBrand), new { id = brand.BrandId }, brand);
        }
        catch (DbUpdateException ex)
        {
            // İç hatayı yakala ve mesajını dön
            var innerException = ex.InnerException;
            // Buraya bir breakpoint koyarak hata mesajını inceleyebilirsiniz.
            return BadRequest($"Veritabanı hatası: {innerException?.Message}");
        }
    }
    // GET: api/Brands/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Brand>> GetBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        return Ok(brand);
    }
}