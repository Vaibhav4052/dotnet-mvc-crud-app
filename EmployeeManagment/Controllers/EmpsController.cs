
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagment.Models;

public class EmpsController : Controller
{
    private readonly IacsddbContext _context;

    public EmpsController(IacsddbContext context)
    {
        _context = context;
    }

    // GET: EMPS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Emps.ToListAsync());
    }

    // GET: EMPS/Details/5
    public async Task<IActionResult> Details(int? no)
    {
        if (no == null)
        {
            return NotFound();
        }

        var emp = await _context.Emps
            .FirstOrDefaultAsync(m => m.No == no);
        if (emp == null)
        {
            return NotFound();
        }

        return View(emp);
    }

    // GET: EMPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("No,Name,Address")] Emp emp)
    {
        if (ModelState.IsValid)
        {
            _context.Add(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(emp);
    }

    // GET: EMPS/Edit/5
    public async Task<IActionResult> Edit(int? no)
    {
        if (no == null)
        {
            return NotFound();
        }

        var emp = await _context.Emps.FindAsync(no);
        if (emp == null)
        {
            return NotFound();
        }
        return View(emp);
    }

    // POST: EMPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? no, [Bind("No,Name,Address")] Emp emp)
    {
        if (no != emp.No)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(emp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(emp.No))
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
        return View(emp);
    }

    // GET: EMPS/Delete/5
    public async Task<IActionResult> Delete(int? no)
    {
        if (no == null)
        {
            return NotFound();
        }

        var emp = await _context.Emps
            .FirstOrDefaultAsync(m => m.No == no);
        if (emp == null)
        {
            return NotFound();
        }

        return View(emp);
    }

    // POST: EMPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? no)
    {
        var emp = await _context.Emps.FindAsync(no);
        if (emp != null)
        {
            _context.Emps.Remove(emp);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpExists(int? no)
    {
        return _context.Emps.Any(e => e.No == no);
    }
}
