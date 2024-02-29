using Db_employee_salary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Db_employee_salary.Controllers
{
    public class EmpController : Controller
    {
        TestContext _db;

        public EmpController(TestContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var employee =  _db.TblEmployees.Join(_db.TblEmployeeSalaries,
                t1 => t1.EId,
                t2 => t2.Id,
                (t1, t2) => new TblEmployee
                {
                    EId = t1.EId,
                    Name = t1.Name,
                    Address = t1.Address,
                    Ph = t1.Ph,
                    Salary_clmn = t2.Salary
                });
            return View(employee);
        }

        [HttpGet]
        public IActionResult add_emp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add_emp(TblEmployee e)
        {
            try
            {
                await _db.TblEmployees.AddAsync(e);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult add_sal()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> add_sal(TblEmployeeSalary s)
        {
            try
            {
                await _db.TblEmployeeSalaries.AddAsync(s);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }


        public IActionResult Emp_Details(int id)
        {
            var employee = _db.TblEmployees.Where(a => a.EId == id).FirstOrDefault();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _db.TblEmployees.Where(a => a.EId == id).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TblEmployee e)
        {
            try
            {
                _db.Entry(e).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public IActionResult sal_Details(int id)
        {
            var employee= _db.TblEmployeeSalaries.Where(a => a.Id == id).FirstOrDefault();
            return View(employee);
        }
    }
}
