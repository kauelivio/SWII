using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2_API.Data;
using P2_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P2_API.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
        {
            var usuarios = await context.Usuarios.ToListAsync();
            return usuarios;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Usuario>> Get ([FromServices] DataContext context, int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post (
            [FromServices] DataContext context,
            [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.Usuarios.Add(model);
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
        public async Task<ActionResult<Usuario>> Put (
            [FromServices] DataContext context,
            [FromBody] Usuario model,
            int id)
        {
            if (ModelState.IsValid)
            {
                var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario != null)
                {
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                  
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
        public async Task<ActionResult<Usuario>> Delete ([FromServices] DataContext context, int id)
        {
            Usuario usuario = new Usuario() { Id = id };
            context.Usuarios.Attach(usuario);
            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
