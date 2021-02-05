using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EJ3_GA.Models;

namespace EJ3_GA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Maquinas_RegistradorasController : ControllerBase
    {
        private readonly APIContext _context;

        public Maquinas_RegistradorasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Maquinas_Registradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquinas_Registradoras>>> GetMaquinas_Registradoras()
        {
            return await _context.Maquinas_Registradoras.ToListAsync();
        }

        // GET: api/Maquinas_Registradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquinas_Registradoras>> GetMaquinas_Registradoras(int id)
        {
            var maquinas_Registradoras = await _context.Maquinas_Registradoras.FindAsync(id);

            if (maquinas_Registradoras == null)
            {
                return NotFound();
            }

            return maquinas_Registradoras;
        }

        // PUT: api/Maquinas_Registradoras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinas_Registradoras(int id, Maquinas_Registradoras maquinas_Registradoras)
        {
            if (id != maquinas_Registradoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquinas_Registradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Maquinas_RegistradorasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Maquinas_Registradoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Maquinas_Registradoras>> PostMaquinas_Registradoras(Maquinas_Registradoras maquinas_Registradoras)
        {
            _context.Maquinas_Registradoras.Add(maquinas_Registradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinas_Registradoras", new { id = maquinas_Registradoras.Codigo }, maquinas_Registradoras);
        }

        // DELETE: api/Maquinas_Registradoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maquinas_Registradoras>> DeleteMaquinas_Registradoras(int id)
        {
            var maquinas_Registradoras = await _context.Maquinas_Registradoras.FindAsync(id);
            if (maquinas_Registradoras == null)
            {
                return NotFound();
            }

            _context.Maquinas_Registradoras.Remove(maquinas_Registradoras);
            await _context.SaveChangesAsync();

            return maquinas_Registradoras;
        }

        private bool Maquinas_RegistradorasExists(int id)
        {
            return _context.Maquinas_Registradoras.Any(e => e.Codigo == id);
        }
    }
}
