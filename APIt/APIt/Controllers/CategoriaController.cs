using System.Collections.Generic;
using System.Threading.Tasks;
using APIt.Data;
using APIt.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIt.Controllers
{
    [ApiController]
    [Route("/categoria")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categoria.ToListAsync();
            return categorias;
        }
        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody]Categoria model)
        {
            context.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Categoria>> GetById([FromServices] DataContext context, int id)
        {
            var categoria = await context.Categoria.FirstOrDefaultAsync(x => x.Id == id);
            return categoria;
        }
        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<Categoria>> Delete([FromServices] DataContext context, int id)
        {
            var deleteCategoria = await context.Categoria.FirstOrDefaultAsync(x => x.Id == id);
            context.Categoria.Remove(deleteCategoria);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Delete));
        }

        [HttpPatch]
        [Route("{id:int}")]

        public async Task<ActionResult<Categoria>> Patch([FromServices] DataContext context, [FromBody] Categoria model, int id)
        {
            var updateCategoria = await context.Categoria.FirstOrDefaultAsync(x => x.Id == id);

            context.Categoria.UpdateRange(updateCategoria, model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
