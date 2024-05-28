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
    public class CouponController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public CouponController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        // GET: Coupon
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: Coupon/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .Include(d => d.CreatedBy) 
                .Include(d => d.LastModifiedBy) 
                .Include(d => d.Packages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // GET: Coupon/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Guid? packageId)
        {
            if (packageId == null){
                var packages = await _context.Packages.ToListAsync();
                ViewBag.Packages = packages;
                ViewBag.Mode = "select";
            } else {
                ViewBag.Package = packageId;
                ViewBag.Mode = "direct";
            }
            return View();
        }

        // POST: Coupon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Coupon coupon)
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
                
                return View(coupon);
            }
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                if (currentUser == null)
                {
                    // Handle the case where the current user is not found
                    return RedirectToAction(nameof(Index));
                }

                coupon.CreatedBy = currentUser;
                coupon.LastModifiedBy = currentUser;

                // Retrieve the selected packages and associate them with the coupon
                if (Request.Form["Packages"].Count > 0)
                {
                    var selectedPackageIds = Request.Form["Packages"].Select(Guid.Parse).ToList();
                    coupon.Packages = await _context.Packages.Where(p => selectedPackageIds.Contains(p.Id)).ToListAsync();
                }

                // Add the coupon to the database
                _context.Add(coupon);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(coupon);
        }

        // GET: Coupon/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons.FindAsync(id);

            var packages = await _context.Packages.ToListAsync();
            
            ViewBag.Packages = packages;

            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);
        }

        // POST: Coupon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,DiscountAmount,ExpirationDate")] Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalCoupon = await _context.Coupons.Include(c => c.Packages).FirstOrDefaultAsync(c => c.Id == id);
                    if (originalCoupon == null)
                    {
                        return NotFound();
                    }

                    // Update coupon properties
                    originalCoupon.Code = coupon.Code;
                    originalCoupon.DiscountAmount = coupon.DiscountAmount;
                    originalCoupon.ExpirationDate = coupon.ExpirationDate;

                    // Set LastModifiedBy and LastModifiedAt properties
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    if (currentUser == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    originalCoupon.LastModifiedBy = currentUser;
                    originalCoupon.LastModifiedAt = DateTime.UtcNow;

                    // Retrieve selected package IDs from the form
                    if (Request.Form["Packages"].Count > 0)
                    {
                        var selectedPackageIds = Request.Form["Packages"].Select(Guid.Parse).ToList();

                        // Clear existing packages associated with the coupon
                        originalCoupon.Packages.Clear();

                        // Add selected packages to the coupon
                        foreach (var packageId in selectedPackageIds)
                        {
                            var package = await _context.Packages.FindAsync(packageId);
                            if (package != null)
                            {
                                originalCoupon.Packages.Add(package);
                            }
                        }
                    }
                    else
                    {
                        originalCoupon.Packages.Clear();
                    }

                    _context.Update(originalCoupon);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponExists(coupon.Id))
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
            return View(coupon);
        }


        // GET: Coupon/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponExists(Guid id)
        {
            return _context.Coupons.Any(e => e.Id == id);
        }
    }
}
