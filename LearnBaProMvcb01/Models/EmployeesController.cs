using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LearnBaProMvcb01.Models
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDatabaseContext _context;

        public EmployeesController(EmployeeDatabaseContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
       /* public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.IdEmp == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }*/

        // GET: Employees/Create
        public IActionResult AddOrEdit(int id=0)
        {
            Employee emp = new Employee();
            if (id == 0)
            {
                return View(emp);
            } else
            {
                emp = _context.Employees.Find(id);
                return View(emp);

            }
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdEmp,NameEmp,Position,PhotoPath,EnrollDate,IdDept")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if(employee.IdEmp == 0)
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                } else
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmp,NameEmp,Position,PhotoPath,EnrollDate,IdDept")] Employee employee)
        {
            if (id != employee.IdEmp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdEmp))
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
            return View(employee);
        }*/

        // GET: Employees/Delete/5
        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.IdEmp == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }*/

        // POST: Employees/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]*/
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdEmp == id);
        }
    }
}
