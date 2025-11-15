
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;
using System;

namespace Proseca.API.Controllers
{
    [ApiController]
    [Route("/api/Fincas")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FincasController : ControllerBase
    {
        private readonly DataContext _context;
        public FincasController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        //Get con lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Fincas.ToListAsync());
        }

        [AllowAnonymous]
        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var finca = await _context.Fincas.FirstOrDefaultAsync(x => x.Id == id);
            if (finca == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(finca);
            }
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Finca finca)
        {

            _context.Update(finca);
            await _context.SaveChangesAsync();
            return Ok(finca);
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Finca finca)
        {


            _context.Update(finca);
            await _context.SaveChangesAsync();
            return Ok(finca);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Fincas
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
