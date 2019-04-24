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
    public class BuildingsController : ControllerBase
    {
        private readonly RoomContext _context;
        public BuildingsController(RoomContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> index()
        {
            return await _context.Building.Include(r=>r.Office).ToListAsync();
        }
        [HttpGet("office/{officeId}")]
        public async Task<ActionResult<IEnumerable<Building>>> SearchBuilding(int officeId)
        {
            var BuildingsWithFilter = await _context.Building.Where(Building => Building.OfficeId==officeId).ToListAsync();
            return BuildingsWithFilter;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Building>>> BuildingDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var building = await _context.Building.Include(b=>b.Office).Where(b=>b.BuildingId==id).ToListAsync();
            if (building == null)
            {
                return NotFound();
            }
            return building;
        }
        [HttpPost]
        public async Task<ActionResult<Office>> CreateBuilding(Building building)
        {
            _context.Building.Add(building);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(index), new { id = building.BuildingId }, building);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Office>> EditBuilding(int id, Building building)
        {
            if (id != building.BuildingId)
            {
                return BadRequest();
            }
            _context.Entry(building).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Office>> DeleteBuilding(int id)
        {
            var BuildingToDelete = await _context.Building.FindAsync(id);
            if (BuildingToDelete == null)
            {
                return BadRequest();
            }
            _context.Building.Remove(BuildingToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}