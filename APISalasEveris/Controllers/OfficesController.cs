using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISalasEveris.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISalasEveris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly RoomContext _context;
        public OfficesController(RoomContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> index()
        {
            return await _context.Office.ToListAsync();
        }
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Office>>> SearchOffice(string name)
        {
            var OfficesWithFilter = await _context.Office.Where(Office => Office.OfficeName.Contains(name)).ToListAsync();
            return OfficesWithFilter;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> OfficeDetails(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var office = await _context.Office.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            return office;
        }
        [HttpPost]
        public async Task<ActionResult<Office>> CreateOffice(Office office)
        {
            _context.Office.Add(office);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(index), new { id = office.OfficeId }, office);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Office>> EditOffice(int id, Office office)
        {
            if (id != office.OfficeId)
            {
                return BadRequest();
            }
            _context.Entry(office).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Office>> DeleteOffice(int id)
        {
            var officeToDelete = await _context.Office.FindAsync(id);
            if (officeToDelete == null)
            {
                return BadRequest();
            }
            _context.Office.Remove(officeToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}