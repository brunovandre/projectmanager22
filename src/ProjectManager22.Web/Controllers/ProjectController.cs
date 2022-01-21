using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Enums;
using ProjectManager22.Domain.Interfaces.Repositories;
using ProjectManager22.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager22.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectDomainService _domainProjectService;

        public ProjectController(
            IProjectRepository projectRepository,
            IProjectDomainService domainProjectService)
        {
            _projectRepository = projectRepository;
            _domainProjectService = domainProjectService;
        }

        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            var projects = await _projectRepository.GetAllAsync();

            return View(projects);
        }

        // GET: ProjectController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var project = await _projectRepository.GetDtoByIdAsync(id);

            return View(project);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            var status = new List<ProjectStatusEnum> { ProjectStatusEnum.ApprovedReview, ProjectStatusEnum.Cancelled, ProjectStatusEnum.Closed, ProjectStatusEnum.DoneReview, ProjectStatusEnum.InProgress, ProjectStatusEnum.Planned, ProjectStatusEnum.Review, ProjectStatusEnum.Started };
            ViewBag.Status = status.Select(c => new SelectListItem() { Text = c.ToString(), Value = c.ToString() }).ToList();

            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            await _domainProjectService.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProjectController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            
            var status = new List<ProjectStatusEnum> { ProjectStatusEnum.ApprovedReview, ProjectStatusEnum.Cancelled, ProjectStatusEnum.Closed, ProjectStatusEnum.DoneReview, ProjectStatusEnum.InProgress, ProjectStatusEnum.Planned, ProjectStatusEnum.Review, ProjectStatusEnum.Started };
            ViewBag.Status = status.Select(c => new SelectListItem(){ Text = c.ToString(), Value = c.ToString() }).ToList();
            var project = await _projectRepository.GetDtoByIdAsync(id);

            return View(project);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ProjectDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            await _domainProjectService.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProjectController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var project = await _projectRepository.GetDtoByIdAsync(id);

            return View(project);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            if (!ModelState.IsValid)
                return View();

            await _domainProjectService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
