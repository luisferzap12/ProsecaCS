
//ver
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;

namespace Proseca.API.Controllers
{
    [ApiController]
    [Route("/api/ProduccionesDeLeche")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProduccionesDeLecheController : ControllerBase
    {
        private readonly DataContext _context;
        public ProduccionesDeLecheController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ProduccionesDeLeche.ToListAsync());
        }

        [AllowAnonymous]
        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var pl = await _context.ProduccionesDeLeche.FirstOrDefaultAsync(x => x.Id == id);
            if (pl == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pl);
            }
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(ProduccionLeche pl)
        {

            _context.Update(pl);
            await _context.SaveChangesAsync();
            return Ok(pl);
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(ProduccionLeche produccionesDeLeche)
        {


            _context.Update(produccionesDeLeche);
            await _context.SaveChangesAsync();
            return Ok(produccionesDeLeche);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.ProduccionesDeLeche
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