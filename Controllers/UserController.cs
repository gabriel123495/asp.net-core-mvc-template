using Microsoft.AspNetCore.Mvc;
using Minecraft.Data;
using Minecraft.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Minecraft.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(updatedUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(updatedUser);
        }
    }
}