using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingProject.Server.Data;
using BlazingProject.Shared.Models;

namespace BlazingProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactCsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactC>>> Getcontact()
        {
          if (_context.contact == null)
          {
              return NotFound();
          }
            return await _context.contact.ToListAsync();
        }
        // GET: api/ContactCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactC>> GetContactC(int id)
        {
          if (_context.contact == null)
          {
              return NotFound();
          }
            var contactC = await _context.contact.FindAsync(id);

            if (contactC == null)
            {
                return NotFound();
            }

            return contactC;
        }

        // PUT: api/ContactCs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactC(int id, ContactC contactC)
        {
            if (id != contactC.ID)
            {
                return BadRequest();
            }

            _context.Entry(contactC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactCExists(id))
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

        // POST: api/ContactCs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactC>> PostContactC(ContactC contactC)
        {
          if (_context.contact == null)
          {
              return Problem("Entity set 'AppDbContext.contact'  is null.");
          }
            _context.contact.Add(contactC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactC", new { id = contactC.ID }, contactC);
        }

        // DELETE: api/ContactCs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactC(int id)
        {
            if (_context.contact == null)
            {
                return NotFound();
            }
            var contactC = await _context.contact.FindAsync(id);
            if (contactC == null)
            {
                return NotFound();
            }

            _context.contact.Remove(contactC);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactCExists(int id)
        {
            return (_context.contact?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
