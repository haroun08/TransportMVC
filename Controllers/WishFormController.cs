using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportMVC.Data;

namespace TransportMVC.Controllers
{
    public class WishFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WishForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.WishForms.ToListAsync());
        }

        // GET: WishForm/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishForm = await _context.WishForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wishForm == null)
            {
                return NotFound();
            }

            return View(wishForm);
        }

        // GET: WishForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Destination,DepartureDate,Duration,Budget,Interests,AdditionalNotes,SubmissionDate")] WishForm wishForm)
        {
            if (ModelState.IsValid)
            {
                wishForm.Id = Guid.NewGuid();
                _context.Add(wishForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishForm);
        }

        // GET: WishForm/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishForm = await _context.WishForms.FindAsync(id);
            if (wishForm == null)
            {
                return NotFound();
            }
            return View(wishForm);
        }

        // POST: WishForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Destination,DepartureDate,Duration,Budget,Interests,AdditionalNotes,SubmissionDate")] WishForm wishForm)
        {
            if (id != wishForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishFormExists(wishForm.Id))
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
            return View(wishForm);
        }

        // GET: WishForm/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishForm = await _context.WishForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wishForm == null)
            {
                return NotFound();
            }

            return View(wishForm);
        }

        // POST: WishForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var wishForm = await _context.WishForms.FindAsync(id);
            if (wishForm != null)
            {
                _context.WishForms.Remove(wishForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishFormExists(Guid id)
        {
            return _context.WishForms.Any(e => e.Id == id);
        }
    }
}
