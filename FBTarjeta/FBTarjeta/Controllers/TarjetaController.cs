using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBTarjeta.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBTarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarjetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _context.TarjetaCreditos.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (id != tarjeta.Id)
                {
                    return NotFound();
                }

                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new {message="Tarjeta actualizada con exito"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCreditos.FindAsync(id);
                if (tarjeta == null)
                    return NotFound();

                _context.TarjetaCreditos.Remove(tarjeta);
                await _context.SaveChangesAsync();

                return Ok(new {message="Tarjeta eliminada con exito"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
