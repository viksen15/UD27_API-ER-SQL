﻿using System;
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
    public class EquiposController : ControllerBase
    {
        private readonly APIContext _context;

        public EquiposController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipos>>> GetEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipos>> GetEquipos(char? id)
        {
            var equipos = await _context.Equipos.FindAsync(id);

            if (equipos == null)
            {
                return NotFound();
            }

            return equipos;
        }

        // PUT: api/Equipos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipos(char? id, Equipos equipos)
        {
            if (id != equipos.NumSerie)
            {
                return BadRequest();
            }

            _context.Entry(equipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquiposExists(id))
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

        // POST: api/Equipos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Equipos>> PostEquipos(Equipos equipos)
        {
            _context.Equipos.Add(equipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipos", new { id = equipos.NumSerie }, equipos);
        }

        // DELETE: api/Equipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Equipos>> DeleteEquipos(char? id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipos);
            await _context.SaveChangesAsync();

            return equipos;
        }

        private bool EquiposExists(char? id)
        {
            return _context.Equipos.Any(e => e.NumSerie == id);
        }
    }
}
