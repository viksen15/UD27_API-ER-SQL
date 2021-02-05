using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EJ4_I.Models;

namespace EJ4_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadesController : ControllerBase
    {
        private readonly APIContext _context;

        public FacultadesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Facultades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultades>>> GetFacultades()
        {
            return await _context.Facultades.ToListAsync();
        }

        // GET: api/Facultades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultades>> GetFacultades(int? id)
        {
            var facultades = await _context.Facultades.FindAsync(id);

            if (facultades == null)
            {
                return NotFound();
            }

            return facultades;
        }

        // PUT: api/Facultades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultades(int? id, Facultades facultades)
        {
            if (id != facultades.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(facultades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadesExists(id))
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

        // POST: api/Facultades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Facultades>> PostFacultades(Facultades facultades)
        {
            _context.Facultades.Add(facultades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultades", new { id = facultades.Codigo }, facultades);
        }

        // DELETE: api/Facultades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Facultades>> DeleteFacultades(int? id)
        {
            var facultades = await _context.Facultades.FindAsync(id);
            if (facultades == null)
            {
                return NotFound();
            }

            _context.Facultades.Remove(facultades);
            await _context.SaveChangesAsync();

            return facultades;
        }

        private bool FacultadesExists(int? id)
        {
            return _context.Facultades.Any(e => e.Codigo == id);
        }
    }
}
