using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Domain.Entities;
using ApiTestEntraID.Web.Models;
using ApiTestEntraID.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestEntraID.Web.Controllers;

[Authorize(Policy = AppPolicies.DocsGeneral)]
public sealed class DocumentationController : Controller
{
    private const int DepartmentId = 1;
    private readonly ITaskRepository _taskRepository;
    private readonly IReportService _reportService;
    private readonly IUserRepository _userRepository;

    public DocumentationController(ITaskRepository taskRepository, IReportService reportService, IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _reportService = reportService;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [Authorize(Policy = AppPolicies.DocsTasks)]
    [HttpGet]
    public IActionResult Tasks()
    {
        ViewBag.Users = _userRepository.GetAll();
        return View(_taskRepository.GetByDepartment(DepartmentId));
    }

    [Authorize(Policy = AppPolicies.DocsTasks)]
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

    [Authorize(Policy = AppPolicies.DocsReport)]
    [HttpGet]
    public IActionResult Report() => View(_reportService.GetByDepartment(DepartmentId));
}