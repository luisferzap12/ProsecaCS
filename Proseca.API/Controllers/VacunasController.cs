
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;

namespace Proseca.API.Controllers
{
    [ApiController]
    [Route("/api/Vacunas")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VacunasController : ControllerBase
    {
        private readonly DataContext _context;
        public VacunasController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Vacunas.ToListAsync());
        }

        [AllowAnonymous]
        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var vacuna = await _context.Vacunas.FirstOrDefaultAsync(x => x.Id == id);
            if (vacuna == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vacuna);
            }
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Vacuna vacuna)
        {

            _context.Update(vacuna);
            await _context.SaveChangesAsync();
            return Ok(vacuna);
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Vacuna vacuna)
        {


            _context.Update(vacuna);
            await _context.SaveChangesAsync();
            return Ok(vacuna);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Vacunas
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
