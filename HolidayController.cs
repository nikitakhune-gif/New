using EmployeesLeaveApplication.Interface;
using EmployeesLeaveApplication.Models;
using EmployeesLeaveApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesLeaveApplication.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _holidayService.GetAllHolidaysAsync();
            return View(holidays);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Holiday model)
        {
            if (ModelState.IsValid)
            {
                await _holidayService.AddHolidayAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
