using EmployeesLeaveApplication.Models;
using EmployeesLeaveApplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesLeaveApplication.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        public async Task<IActionResult> Index()
        {
            var leaves = await _leaveService.GetLeavesAsync();
            return View(leaves);
        }

        // GET: Leave/Create
        public IActionResult Create()
        {
            return View(); // shows Apply Leave form
        }

        // POST: Leave/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _leaveService.AddAsync(model);

            TempData["Success"] = "Leave successfully applied!";

            return RedirectToAction(nameof(LeaveHistory), new { employeeId = model.EmployeeId });
        }

        public async Task<IActionResult> LeaveHistory(int employeeId)
        {
            if (employeeId <= 0)
            {
                return BadRequest("Invalid Employee ID");
            }

            var leaveList = await _leaveService.GetLeavesByEmployeeAsync(employeeId);
            return View(leaveList);
        }
    }
}
