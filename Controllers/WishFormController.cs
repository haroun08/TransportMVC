using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace TransportMVC.Controllers
{
    public class WishFormController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public WishFormController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: WishForm
        [AllowAnonymous]
        [Authorize]
        public async Task<IActionResult> Index()
        {
             var wishForms = await _context.WishForms
                                        .Include(b => b.CreatedBy)
                                        .ToListAsync();

            return View(wishForms);
        }

        // GET: WishForm/Details/5
        [AllowAnonymous]
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishForm = await _context.WishForms
                .Include(d => d.CreatedBy) 
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wishForm == null)
            {
                return NotFound();
            }

            return View(wishForm);
        }

        // GET: WishForm/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Destination,DepartureDate,Duration,Budget,Interests,AdditionalNotes,SubmissionDate")] WishForm wishForm)
        {
            
            if (ModelState.IsValid)
            {
                // Set the CreatedBy and LastModifiedBy properties to the currently logged-in user
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                // Ensure that the current user is not null
                if (currentUser == null)
                {
                    // Handle the case where the current user is not found
                    return RedirectToAction(nameof(Index));
                }

                wishForm.CreatedBy = currentUser;

                _context.Add(wishForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishForm);
        }

        // GET: WishForm/Edit/5
        [Authorize]
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
        [Authorize]
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
                    var existingWishForm = await _context.WishForms.FindAsync(id);
                    if (existingWishForm == null)
                    {
                        return NotFound();
                    }

                    // Only update the editable properties
                    existingWishForm.Destination = wishForm.Destination;
                    existingWishForm.DepartureDate = wishForm.DepartureDate;
                    existingWishForm.Duration = wishForm.Duration;
                    existingWishForm.Budget = wishForm.Budget;
                    existingWishForm.Interests = wishForm.Interests;
                    existingWishForm.AdditionalNotes = wishForm.AdditionalNotes;

                    _context.Update(existingWishForm);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
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
            }
            return View(wishForm);
        }

        // GET: WishForm/Delete/5
        [Authorize]
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
        [Authorize]
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
