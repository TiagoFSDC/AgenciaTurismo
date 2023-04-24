using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Models;
using TourAgencyAPIEF.Data;

namespace TourAgencyAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacketsController : ControllerBase
    {
        private readonly TourAgencyAPIEFContext _context;

        public PacketsController(TourAgencyAPIEFContext context)
        {
            _context = context;
        }

        // GET: api/Packets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packet>>> GetPacket()
        {
          if (_context.Packet == null)
          {
              return NotFound();
          }
            return await _context.Packet.ToListAsync();
        }

        // GET: api/Packets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Packet>> GetPacket(int id)
        {
          if (_context.Packet == null)
          {
              return NotFound();
          }
            var packet = await _context.Packet.FindAsync(id);

            if (packet == null)
            {
                return NotFound();
            }

            return packet;
        }

        // PUT: api/Packets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacket(int id, Packet packet)
        {
            if (id != packet.Id)
            {
                return BadRequest();
            }

            _context.Entry(packet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacketExists(id))
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

        // POST: api/Packets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Packet>> PostPacket(Packet packet)
        {
          if (_context.Packet == null)
          {
              return Problem("Entity set 'TourAgencyAPIEFContext.Packet'  is null.");
          }
            _context.Packet.Add(packet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacket", new { id = packet.Id }, packet);
        }

        // DELETE: api/Packets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacket(int id)
        {
            if (_context.Packet == null)
            {
                return NotFound();
            }
            var packet = await _context.Packet.FindAsync(id);
            if (packet == null)
            {
                return NotFound();
            }

            _context.Packet.Remove(packet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacketExists(int id)
        {
            return (_context.Packet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
