using System.Collections.Generic;
using System.Threading.Tasks;
using APIt.Data;
using APIt.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIt.Controllers
{
    [ApiController]
    [Route("produto")]

    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produto.Include(x => x.Categoria).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produto.Include(x => x.Categoria).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] Produto model)
        {
            context.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<Produto>> Delete([FromServices] DataContext context, int id)
        {
            var deleteProduto = await context.Produto.FirstOrDefaultAsync(x => x.Id == id);
            context.Produto.Remove(deleteProduto);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Delete));
        }

        [HttpPatch]
        [Route("{id:int}")]

        public async Task<ActionResult<Produto>> Patch([FromServices] DataContext context, [FromBody] Produto model, int id)
        {
            var updateProduto = await context.Produto.FirstOrDefaultAsync(x => x.Id == id);

            context.Produto.UpdateRange(updateProduto, model);
            await context.SaveChangesAsync();
            return model;
        }
    }

}
