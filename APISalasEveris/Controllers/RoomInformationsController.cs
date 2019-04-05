using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APISalasEveris.Models;

namespace APISalasEveris.Controllers
{
    [Route("api/[controller]")]
    public class RoomInformationsController : Controller
    {
        private readonly RoomContext _context;

        public RoomInformationsController(RoomContext context)
        {
            _context = context;
        }

        // GET: RoomInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomInformations.ToListAsync());
        }

        // GET: RoomInformations/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var roomInformation = await _context.RoomInformations
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (roomInformation == null)
            {
                return NotFound();
            }

            return View(roomInformation);
        }

        // POST: RoomInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Name,Floor,NumRoom")] RoomInformation roomInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomInformation);
        }

        // POST: RoomInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Name,Floor,NumRoom")] RoomInformation roomInformation)
        {
            if (id != roomInformation.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomInformationExists(roomInformation.RoomId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roomInformation);
        }

        // POST: RoomInformations/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomInformation = await _context.RoomInformations.FindAsync(id);
            _context.RoomInformations.Remove(roomInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomInformationExists(int id)
        {
            return _context.RoomInformations.Any(e => e.RoomId == id);
        }
    }
}
