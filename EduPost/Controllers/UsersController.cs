using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduPost.Data;
using EduPost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EduPost.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UsersController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,FacultyId,RoleId,Id,NormalizedUserName,NormalizedEmail,EmailConfirmed,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User user, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.ToListAsync();
            ViewData["Roles"] = new SelectList(roles, "Name", "Name");

            var faculties = await _context.Faculty.ToListAsync();
            ViewData["Faculties"] = new SelectList(faculties, "FacultyName", "FacultyName");

            return View(user);
        }

		// POST: Users/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("UserName,Email,Faculty,Role,Id,NormalizedUserName,NormalizedEmail,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User userInput)
		{
			if (id != userInput.Id)
			{
				return NotFound();
			}

			var userInDb = _context.Users.Find(id); // Synchronously finding the user
			if (userInDb == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Entry(userInDb).CurrentValues.SetValues(userInput);
					_context.Entry(userInDb).Property(x => x.PasswordHash).IsModified = false;
					_context.Entry(userInDb).Property(x => x.SecurityStamp).IsModified = false;
					_context.Entry(userInDb).Property(x => x.ConcurrencyStamp).IsModified = false;
					_context.Entry(userInDb).Property(x => x.Role).IsModified = true;
					_context.Entry(userInDb).Property(x => x.Faculty).IsModified = true;

					_context.SaveChanges();

					var currentRoles = _userManager.GetRolesAsync(userInDb).Result;
					var newRoleName = userInput.Role;

					if (!currentRoles.Contains(newRoleName))
					{
						if (currentRoles.Any())
						{
							_userManager.RemoveFromRolesAsync(userInDb, currentRoles).Wait();
						}
						if (!String.IsNullOrEmpty(newRoleName))
						{
							_userManager.AddToRoleAsync(userInDb, newRoleName).Wait(); 
						}
					}

					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!UserExists(userInput.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}
			return View(userInput);
		}

		// GET: Users/Delete/5
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
