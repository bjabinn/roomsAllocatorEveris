using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISalasEveris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISalasEveris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly RoomContext _context;

        public RoomController(RoomContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> Index()
        {
            return await _context.RoomInformations.ToListAsync();
        }
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> Search(string name)
        {            
            var roomsWithFilter = await _context.RoomInformations.Where(room => room.Name.Contains(name)).ToListAsync();
            return roomsWithFilter;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomInformation>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var RoomInformation = await _context.RoomInformations.FindAsync(id);
            if (RoomInformation == null)
                return NotFound();
            return RoomInformation;
        }
        [HttpPost]
        public async Task<ActionResult<RoomInformation>> Create(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Details), new { id = room.RoomId}, room);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, RoomInformation room)
        {
            //if it does not exist
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _context.RoomInformations.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            _context.RoomInformations.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}