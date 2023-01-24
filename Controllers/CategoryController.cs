using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Context;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("product")]
        public ActionResult<IEnumerable<CategoryModel>> GetCategoryProduct()
        {
            return _context.Category.Include(p => p.Products).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            return _context.Category.ToList();
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public ActionResult<CategoryModel> Get(int id)
        {
            var category = _context.Category.FirstOrDefault(p => p.CategoryId == id);
            if(category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return category;
        }

        [HttpPost]
        public ActionResult Post(CategoryModel category)
        {
            if (category is null) return BadRequest();

            _context.Category.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.CategoryId }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, CategoryModel category) 
        {
            if(id != category.CategoryId)
            {
                return BadRequest();
            }
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoryModel> Delete(int id)
        {
            var category = _context.Category.FirstOrDefault(p => p.CategoryId == id);

            if(category == null)
            {
                return NotFound();
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }

    }
}
