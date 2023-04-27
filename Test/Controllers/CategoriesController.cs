using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Test.Data;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _appDbContext.Categories.ToListAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(string categoryName)
        {
            await _appDbContext.Categories.AddAsync(new Category { Name = categoryName });
            var result = await _appDbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
