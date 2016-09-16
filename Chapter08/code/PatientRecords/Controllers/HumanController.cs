using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientRecords.Data;
using PatientRecords.Models;
using Microsoft.AspNetCore.Authorization;

namespace PatientRecords.Controllers
{
    [Authorize]
    public class HumanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HumanController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Human
        [Authorize(Roles = "Doctors,Nurses")]
        public async Task<IActionResult> Index()
        {
            var humans = _context.Humans.Include(h => h.RobotDoctor);
            return View(humans);

        }

        // GET: Human/Details/5
        [Authorize(Policy = "DoctorsOnly")]
        public async Task<IActionResult> Details(int? id)
        {
            Human human = await _context.Humans
                .Include(h => h.RobotDoctor)
                .SingleOrDefaultAsync(h => h.ID == id);
            if (human == null)
            {
                return NotFound();
            }
            return View(human);
        }

        // GET: Human/Create
        [Authorize(Roles = "Doctors")]
        public IActionResult Create()
        {
            ViewBag.RobotDoctors = GetListOfRobotDoctors();
            return View();
        }

        private IEnumerable<SelectListItem> GetListOfRobotDoctors(int selected = -1)
        {
            var tmp = _context.RobotDoctors.ToList();

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(rb => rb.ModelNumber)
                .Select(rb => new SelectListItem
                {
                    Text = String.Format("{0}: {1}", rb.ModelNumber, rb.PreferredName),
                    Value = rb.RobotDoctorId.ToString(),
                    Selected = rb.RobotDoctorId == selected
                });
        }


        // POST: Human/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialSecurityNumber,DateOfBirth,FirstName,LastName,RobotDoctorId")] Human human)
        {
            if (ModelState.IsValid)
            {
                _context.Add(human);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(human);
        }

        // GET: Human/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Human human = _context.Humans.Single(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            ViewBag.RobotDoctors = GetListOfRobotDoctors();
            return View(human);
        }

        // POST: Human/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialSecurityNumber", "DateOfBirth", "FirstName", "LastName", "RobotDoctorId")] Human human)
        {
            if (id != human.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                human.ID = id;
                _context.Humans.Attach(human);
                _context.Entry(human).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(human);

        }

        // GET: Human/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Humans.SingleOrDefaultAsync(m => m.ID == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // POST: Human/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var human = await _context.Humans.SingleOrDefaultAsync(m => m.ID == id);
            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HumanExists(int id)
        {
            return _context.Humans.Any(e => e.ID == id);
        }
    }
}
