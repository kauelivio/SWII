using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2_API.Data;
using P2_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P2_API.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.Include(x => x.Usuario).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Get([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.Include(x => x.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post([FromServices] DataContext context, [FromBody] Produto model)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            } 
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Put(
            [FromServices] DataContext context,
            [FromBody] Produto model,
            int id)
        {
            if (ModelState.IsValid)
            {
                var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto != null)
                {
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Status = model.Status;
                    produto.IdUsuarioCadastro = model.IdUsuarioCadastro;
                    produto.IdUsuarioUpdate = model.IdUsuarioUpdate;

                    await context.SaveChangesAsync();

                    return NoContent();
                }

                return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Delete([FromServices] DataContext context, int id)
        {
            Produto produto = new Produto() { Id = id };

            context.Produtos.Attach(produto);
            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
