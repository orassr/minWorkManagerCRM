using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using JobFlow;

namespace minWorkManagerCRM.Controllers
{
    public class JobRequestsController : Controller
    {
        private readonly EntitiesDbContext _context;

        public JobRequestsController(EntitiesDbContext context)
        {
            _context = context;
        }

        // GET: JobRequests
        public async Task<IActionResult> Index()
        {
            var entitiesDbContext = _context.JobRequests.Include(j => j.Company);
            return View(await entitiesDbContext.ToListAsync());
        }

        // GET: JobRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.JobRequests == null)
            {
                return NotFound();
            }

            var jobRequest = await _context.JobRequests
                .Include(j => j.Company)
                .FirstOrDefaultAsync(m => m.JobRequestId == id);
            if (jobRequest == null)
            {
                return NotFound();
            }

            return View(jobRequest);
        }

        // GET: JobRequests/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: JobRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobRequestId,Title,CompanyID,Status")] JobRequest jobRequest)
        {
            if (ModelState.IsValid)
            {
                jobRequest.JobRequestId = Guid.NewGuid();
                _context.Add(jobRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", jobRequest.CompanyID);
            return View(jobRequest);
        }

        // GET: JobRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.JobRequests == null)
            {
                return NotFound();
            }

            var jobRequest = await _context.JobRequests.FindAsync(id);
            if (jobRequest == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", jobRequest.CompanyID);
            return View(jobRequest);
        }

        // POST: JobRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("JobRequestId,Title,CompanyID,Status")] JobRequest jobRequest)
        {
            if (id != jobRequest.JobRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobRequestExists(jobRequest.JobRequestId))
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
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyName", jobRequest.CompanyID);
            return View(jobRequest);
        }

        // GET: JobRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.JobRequests == null)
            {
                return NotFound();
            }

            var jobRequest = await _context.JobRequests
                .Include(j => j.Company)
                .FirstOrDefaultAsync(m => m.JobRequestId == id);
            if (jobRequest == null)
            {
                return NotFound();
            }

            return View(jobRequest);
        }

        // POST: JobRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.JobRequests == null)
            {
                return Problem("Entity set 'EntitiesDbContext.JobRequests'  is null.");
            }
            var jobRequest = await _context.JobRequests.FindAsync(id);
            if (jobRequest != null)
            {
                _context.JobRequests.Remove(jobRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobRequestExists(Guid id)
        {
          return (_context.JobRequests?.Any(e => e.JobRequestId == id)).GetValueOrDefault();
        }
    }
}
