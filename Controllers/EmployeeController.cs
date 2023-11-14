using Microsoft.AspNetCore.Mvc;
using EmployeeManagementWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // Static list to store employees (temporary storage)
        static List<Employee> employees = new List<Employee>();

        // GET: Employee
        public IActionResult Index()
        {
            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Designation,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Count + 1; // Simple ID generation
                employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Designation,Salary")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employeeToUpdate = employees.FirstOrDefault(e => e.Id == id);
                if (employeeToUpdate != null)
                {
                    employeeToUpdate.Name = employee.Name;
                    employeeToUpdate.Designation = employee.Designation;
                    employeeToUpdate.Salary = employee.Salary;

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
