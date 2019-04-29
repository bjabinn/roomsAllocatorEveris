using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using APISalasEveris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace APISalasEveris.Controllers
{
    
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly RoomContext _context;

        public RoomController(RoomContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> Index(string token,string userData)
        {
            TokenGeneratorController tgc = new TokenGeneratorController(_context,_configuration);
            if(!tgc.Validate(token, userData)){
                return Forbid();
            }
            List<RoomInformation> rooms = new List<RoomInformation>();

            rooms = await _context.RoomInformations.Include(r => r.Building.Office).ToListAsync();


            return Ok(rooms);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> Search(string name)
        {            
            var roomsWithFilter = await _context.RoomInformations.Where(room => room.RoomName.Contains(name)).ToListAsync();
            return roomsWithFilter;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RoomInformation>>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var RoomInformation = await _context.RoomInformations.Include(r=>r.Building).Where(room=>room.RoomId==id).ToListAsync();
            if (RoomInformation == null)
                return NotFound();
            return RoomInformation;
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult<RoomInformation>> Create(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
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
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
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