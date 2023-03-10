using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Context;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Dica: Nunca retornar todos os registros do Get em uma consulta. Exemplo: _context.ProductModel.Take(10).ToList();
        //Dica: Nunca retornar objetos relacionados sem aplicar um filtro. Exemplo: _context.CategoryModel.Include(p => p.Product)
                                                                                          //.Where(c => c.CategoryId <= 5).ToList();

        //O IEnumerable permite adiar a execução ou seja ele vai trabalhar por demanda.
        //Usando o IEnumerable não é preciso ter toda a coleção na memoria.
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            var product = _context.Product.AsNoTracking().ToList();
            if(product is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return product;
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public ActionResult<ProductModel> Get(int id)
        {
            var product = _context.Product.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
            if(product is null)
            {
                return NotFound("Produto não encontrado");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(ProductModel product)
        {
            if(product is null)  return BadRequest();
            _context.Product.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ProductModel product)
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var product = _context.Product.FirstOrDefault(p => p.ProductId == id);

            if(product is null)
            {
                return NotFound("Produto não localizado");
            }
            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

    }
}
