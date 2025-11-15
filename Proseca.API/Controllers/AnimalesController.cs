

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proseca.API.Data;
using Proseca.Shared.Entidades;

namespace Proseca.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //protegidos

    [ApiController]
    [Route("/api/Animales")]

    public class AnimalesController : ControllerBase
    {
        private readonly DataContext _context;
        public AnimalesController(DataContext context)
        {
            _context = context;
        }

       [AllowAnonymous]
        //Get con lista
        [HttpGet]
        
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Animales.ToListAsync());
        }

        

      [AllowAnonymous] 

        
        //Get por parametro
        [HttpGet("{id:int}")]
        
        public async Task<ActionResult> Get(int id)
        {
            var animal = await _context.Animales.FirstOrDefaultAsync(x => x.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(animal);
            }
        }

        [AllowAnonymous]
        //post modificar 
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(Animal animal)
        {

            _context.Update(animal);
            await _context.SaveChangesAsync();
            return Ok(animal);
        }


        //  [AllowAnonymous] cualquiera lo puede consumir

        //put modificar 
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(Animal animal)
        {


            _context.Update(animal);
            await _context.SaveChangesAsync();
            return Ok(animal);
        }



        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Animales
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
