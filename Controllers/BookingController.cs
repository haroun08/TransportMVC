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
    public class BookingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public BookingController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Booking
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                                        .Include(b => b.AssociatedPackage)
                                        .ToListAsync();

            return View(bookings);
        }

        // GET: Booking/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(d => d.CreatedBy) 
                .Include(d => d.LastModifiedBy) 
                .Include(d => d.AssociatedPackage)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            // Fetch the list of packages from the database
            var packages = await _context.Packages.ToListAsync();
            
            ViewBag.Packages = packages;

            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("NumberOfTravellers,PaymentMethod,AssociatedPackageId,IsPaid,CouponCode")] Booking booking)
        {
            var packages = await _context.Packages.ToListAsync();
            
            ViewBag.Packages = packages;

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
                
                return View(booking);
            }
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

                booking.CreatedBy = currentUser;
                booking.LastModifiedBy = currentUser;

                var associatedPackage = await _context.Packages
                    .Include(p => p.Coupons)
                    .FirstOrDefaultAsync(p => p.Id == booking.AssociatedPackageId);

                if (associatedPackage != null)
                {
                    booking.AssociatedPackage = associatedPackage;
                }
            

                if (booking.AssociatedPackage == null)
                {
                    ModelState.AddModelError("Package", "Selected package not found.");
                    return View(booking);
                }
                booking.TotalAmount =  booking.AssociatedPackage.Budget * booking.NumberOfTravellers;
                
                if (booking.CouponCode != null)
                {
                    List<Coupon> ListOfCoupons = booking.AssociatedPackage.Coupons;
                    Coupon coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == booking.CouponCode);

                    if (coupon != null)
                    {
                        if (ListOfCoupons != null && ListOfCoupons.Contains(coupon) && coupon.ExpirationDate.Date > DateTime.UtcNow.Date)
                        {
                            booking.TotalAmount -= coupon.DiscountAmount;
                        }
                        else
                        {
                            ModelState.AddModelError("Coupon", "Coupon not valid for the selected package.");
                            ViewBag.Message = "Coupon not valid for the selected package";
                            return View(booking);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Coupon", "Coupon not found.");
                        ViewBag.Message = "Coupon not found";
                        return View(booking);
                    }
                }


                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Booking/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var packages = await _context.Packages.ToListAsync();
            
            ViewBag.Packages = packages;

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,State,NumberOfTravellers,IsPaid,PaymentMethod,AssociatedPackageId,CouponCode")] Booking updatedBooking)
        {
            if (id != updatedBooking.Id)
            {
                return NotFound();
            }
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
                
                return View(updatedBooking);
            }
            if (ModelState.IsValid)
            {
                try
                {   
                    var packages = await _context.Packages.ToListAsync();
            
                    ViewBag.Packages = packages;


                    // Fetch the existing booking entity from the database
                    var originalBooking = await _context.Bookings.FindAsync(id);
                    if (originalBooking == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existing booking entity
                    originalBooking.State = updatedBooking.State;
                    originalBooking.NumberOfTravellers = updatedBooking.NumberOfTravellers;
                    originalBooking.IsPaid = updatedBooking.IsPaid;
                    originalBooking.PaymentMethod = updatedBooking.PaymentMethod;
                    originalBooking.CouponCode = updatedBooking.CouponCode;

                    // Set the LastModifiedBy and LastModifiedAt properties to reflect the current user and time
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    if (currentUser == null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    originalBooking.LastModifiedBy = currentUser;
                    originalBooking.LastModifiedAt = DateTime.UtcNow;




                    var associatedPackage = await _context.Packages
                        .Include(p => p.Coupons)
                        .FirstOrDefaultAsync(p => p.Id == updatedBooking.AssociatedPackageId);

                    if (associatedPackage != null)
                    {
                        originalBooking.AssociatedPackage = associatedPackage;
                    }
                

                    if (originalBooking.AssociatedPackage == null)
                    {
                        ModelState.AddModelError("Package", "Selected package not found.");
                        return View(updatedBooking);
                    }

                    originalBooking.TotalAmount =  originalBooking.AssociatedPackage.Budget * originalBooking.NumberOfTravellers;
                    
                    if (updatedBooking.CouponCode != null)
                    {
                        List<Coupon> ListOfCoupons = originalBooking.AssociatedPackage.Coupons;
                        Coupon coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == updatedBooking.CouponCode);



                        if (coupon != null)
                        {
                            if (ListOfCoupons != null && ListOfCoupons.Contains(coupon) && coupon.ExpirationDate.Date > DateTime.UtcNow.Date)
                            {
                                originalBooking.TotalAmount -= coupon.DiscountAmount;
                            }
                            else
                            {
                                ModelState.AddModelError("Coupon", "Coupon not valid for the selected package.");
                                ViewBag.Message = "Coupon not valid for the selected package";
                                return View(updatedBooking);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Coupon", "Coupon not found.");
                            ViewBag.Message = "Coupon not found";
                            return View(updatedBooking);
                        }
                    }





                    // Update the database with the modified booking
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(updatedBooking.Id))
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
            return View(updatedBooking);
        }



        // GET: Booking/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(Guid id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
