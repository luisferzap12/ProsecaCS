

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;

namespace Proseca.API.Controllers
{
    [ApiController]
    [Route("/api/Reproducciones")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReproduccionesController : ControllerBase
    {
        private readonly DataContext _context;
        public ReproduccionesController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Reproducciones.ToListAsync());
        }

        [AllowAnonymous]
        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var reproduccion = await _context.Reproducciones.FirstOrDefaultAsync(x => x.Id == id);
            if (reproduccion == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(reproduccion);
            }
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Reproduccion reproduccion)
        {

            _context.Update(reproduccion);
            await _context.SaveChangesAsync();
            return Ok(reproduccion);
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Reproduccion reproduccion)
        {


            _context.Update(reproduccion);
            await _context.SaveChangesAsync();
            return Ok(reproduccion);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Reproducciones
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}

