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
    public class PackageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public PackageController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Package
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Packages.ToListAsync());
        }

        // GET: Package/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .Include(d => d.CreatedBy) 
                .Include(d => d.LastModifiedBy) 
                .Include(d => d.Coupons)
                .Include(d => d.Reviews)
                .Include(d => d.Coordinator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Package/Create
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> Create()
        {
            // Fetch the list of destinations from the database
            var destinations = await _context.Destinations.ToListAsync();
            
            // Convert to SelectList to be used in the view
            ViewBag.Destinations = destinations;

            var coordinators = await _context.Coordinators.ToListAsync();
            
            // Convert to SelectList to be used in the view
            ViewBag.Coordinators = coordinators;

            return View();
        }

        // POST: Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> Create([Bind("Name,Budget,Duration,Services,TransportOption,TransportCompany,Category,DestinationId,CoordinatorId")] Package package)
        {
            if (!ModelState.IsValid)
            {
                // Print validation errors to the console
                foreach (var state in ModelState.Values)
                {
                    foreach (var error in state.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        Console.WriteLine(errorMessage);
                    }
                }
                
                return View(package);
            }

            // Retrieve the currently logged-in user
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Set the CreatedBy and LastModifiedBy properties
            package.CreatedBy = currentUser;
            package.LastModifiedBy = currentUser;

            // Fetch the selected destination from the database
            package.Destination = await _context.Destinations.FindAsync(package.DestinationId);

            // Check if the destination was found
            if (package.Destination == null)
            {
                // Destination not found, handle the error (e.g., display an error message)
                ModelState.AddModelError("Destination", "Selected destination not found.");
                return View(package);
            }

            package.Coordinator = await _context.Coordinators.FindAsync(package.CoordinatorId);

            if (package.Coordinator == null)
            {
                ModelState.AddModelError("Coordinator", "Selected coordinator not found.");
                return View(package);
            }

            // Add the package to the context and save changes
            _context.Add(package);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }


        // GET: Package/Edit/5
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            // Fetch the list of destinations from the database
            var destinations = await _context.Destinations.ToListAsync();
            
            // Convert to SelectList to be used in the view
            ViewBag.Destinations = destinations;

            var coordinators = await _context.Coordinators.ToListAsync();
            
            // Convert to SelectList to be used in the view
            ViewBag.Coordinators = coordinators;

            return View(package);
        }

        // POST: Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Budget,Duration,Services,TransportOption,TransportCompany,Category,DestinationId,CoordinatorId")] Package package)
        {
            if (id != package.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalPackage = await _context.Packages.FindAsync(id);
                    if (originalPackage == null)
                    {
                        return NotFound();
                    }

                    // Set the modified properties
                    originalPackage.Name = package.Name;
                    originalPackage.StartDate = package.StartDate;
                    originalPackage.Budget = package.Budget;
                    originalPackage.Duration = package.Duration;
                    originalPackage.Services = package.Services;
                    originalPackage.TransportOption = package.TransportOption;
                    originalPackage.TransportCompany = package.TransportCompany;
                    originalPackage.Category = package.Category;

                    // Set the LastModifiedBy and LastModifiedAt properties
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    if (currentUser == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    originalPackage.LastModifiedBy = currentUser;
                    originalPackage.LastModifiedAt = DateTime.UtcNow;

                    originalPackage.Destination = await _context.Destinations.FindAsync(package.DestinationId);

                    // Check if the destination was found
                    if (originalPackage.Destination == null)
                    {
                        // Destination not found, handle the error (e.g., display an error message)
                        ModelState.AddModelError("Destination", "Selected destination not found.");
                        return View(package);
                    }

                    originalPackage.Coordinator = await _context.Coordinators.FindAsync(package.CoordinatorId);

                    if (originalPackage.Coordinator == null)
                    {
                        ModelState.AddModelError("Coordinator", "Selected coordinator not found.");
                        return View(package);
                    }

                    _context.Update(originalPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.Id))
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
            return View(package);
        }


        // GET: Package/Delete/5
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        [Authorize(Roles = "Admin")]
=======
        [Authorize]
>>>>>>> origin/HarounTest
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(Guid id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
