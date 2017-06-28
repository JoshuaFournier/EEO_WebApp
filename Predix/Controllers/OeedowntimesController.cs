using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Predix.Models;

namespace Predix.Controllers
{
    public class OeedowntimesController : Controller
    {
        private readonly PredixOEEContext _context;

        public OeedowntimesController(PredixOEEContext context)
        {
            _context = context;    
        }

        // GET: Oeedowntimes
        public async Task<IActionResult> Index()
        {
            var predixOEEContext = _context.Oeedowntime.Include(o => o.Equipement);
            return View(await predixOEEContext.ToListAsync());
        }

        // GET: Oeedowntimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeedowntime = await _context.Oeedowntime
                .Include(o => o.Equipement)
                .SingleOrDefaultAsync(m => m.OeedowntimeId == id);
            if (oeedowntime == null)
            {
                return NotFound();
            }

            return View(oeedowntime);
        }

        // GET: Oeedowntimes/Create
        public IActionResult Create()
        {
            ViewData["EquipementId"] = new SelectList(_context.Equipement, "EquipementId", "EquipementId");
            return View();
        }

        // POST: Oeedowntimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OeedowntimeId,DateDebut,DateFin,Duree,Commentaire,EquipementId")] Oeedowntime oeedowntime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oeedowntime);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EquipementId"] = new SelectList(_context.Equipement, "EquipementId", "EquipementId", oeedowntime.EquipementId);
            return View(oeedowntime);
        }

        // GET: Oeedowntimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeedowntime = await _context.Oeedowntime.SingleOrDefaultAsync(m => m.OeedowntimeId == id);
            if (oeedowntime == null)
            {
                return NotFound();
            }
            ViewData["EquipementId"] = new SelectList(_context.Equipement, "EquipementId", "EquipementId", oeedowntime.EquipementId);
            return View(oeedowntime);
        }

        // POST: Oeedowntimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OeedowntimeId,DateDebut,DateFin,Duree,Commentaire,EquipementId")] Oeedowntime oeedowntime)
        {
            if (id != oeedowntime.OeedowntimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oeedowntime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OeedowntimeExists(oeedowntime.OeedowntimeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["EquipementId"] = new SelectList(_context.Equipement, "EquipementId", "EquipementId", oeedowntime.EquipementId);
            return View(oeedowntime);
        }

        // GET: Oeedowntimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oeedowntime = await _context.Oeedowntime
                .Include(o => o.Equipement)
                .SingleOrDefaultAsync(m => m.OeedowntimeId == id);
            if (oeedowntime == null)
            {
                return NotFound();
            }

            return View(oeedowntime);
        }

        // POST: Oeedowntimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oeedowntime = await _context.Oeedowntime.SingleOrDefaultAsync(m => m.OeedowntimeId == id);
            _context.Oeedowntime.Remove(oeedowntime);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OeedowntimeExists(int id)
        {
            return _context.Oeedowntime.Any(e => e.OeedowntimeId == id);
        }
    }
}
