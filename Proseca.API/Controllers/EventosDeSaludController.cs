

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;

namespace Proseca.API.Controllers
{
    [ApiController]
    [Route("/api/EventosDeSalud")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EventosDeSaludController : ControllerBase
    {
        private readonly DataContext _context;
        public EventosDeSaludController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EventosDeSalud.ToListAsync());
        }

        [AllowAnonymous]
        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var eventoDeSalud = await _context.EventosDeSalud.FirstOrDefaultAsync(x => x.Id == id);
            if (eventoDeSalud == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(eventoDeSalud);
            }
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(EventoDeSalud eventoDeSalud)
        {

            _context.Update(eventoDeSalud);
            await _context.SaveChangesAsync();
            return Ok(eventoDeSalud);
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(EventoDeSalud eventoDeSalud)
        {


            _context.Update(eventoDeSalud);
            await _context.SaveChangesAsync();
            return Ok(eventoDeSalud);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.EventosDeSalud
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
