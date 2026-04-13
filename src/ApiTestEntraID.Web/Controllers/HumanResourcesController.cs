using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Domain.Entities;
using ApiTestEntraID.Web.Models;
using ApiTestEntraID.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestEntraID.Web.Controllers;

[Authorize(Policy = AppPolicies.HRGeneral)]
public sealed class HumanResourcesController : Controller
{
    private const int DepartmentId = 2;
    private readonly ITaskRepository _taskRepository;
    private readonly IReportService _reportService;
    private readonly IUserRepository _userRepository;

    public HumanResourcesController(ITaskRepository taskRepository, IReportService reportService, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _reportService = reportService;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [Authorize(Policy = AppPolicies.HRTasks)]
    [HttpGet]
    public IActionResult Tasks()
    {
        ViewBag.Users = _userRepository.GetAll();
        return View(_taskRepository.GetByDepartment(DepartmentId));
    }

    [Authorize(Policy = AppPolicies.HRTasks)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Tasks(AddTaskInputModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = _userRepository.GetAll();
            return View(_taskRepository.GetByDepartment(DepartmentId));
        }

        _taskRepository.Add(new WorkTask
        {
            Id = Guid.NewGuid(),
            Date = model.Date,
            Description = model.Description,
            DepartmentId = DepartmentId,
            AssignedUserId = model.AssignedUserId
        });

        return RedirectToAction(nameof(Tasks));
    }

    [Authorize(Policy = AppPolicies.HRReport)]
    [HttpGet]
    public IActionResult Report() => View(_reportService.GetByDepartment(DepartmentId));
}