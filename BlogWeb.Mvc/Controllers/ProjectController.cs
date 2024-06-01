using BlogWeb.Mvc.Constants;
using BlogWeb.Mvc.Features.Commands.Projects.AddProject;
using BlogWeb.Mvc.Features.Queries.Project.GetAllProject;
using BlogWeb.Mvc.Features.Queries.Project.GetProjectDetail;
using BlogWeb.Mvc.Models.ViewModels;
using BlogWeb.Mvc.Models.ViewModels.Project;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogWeb.Mvc.Controllers
{
    [AllowAnonymous]
    public class ProjectController(IMediator _mediator, IWebHostEnvironment _webHostEnvironment, IToastNotification _toastNotification) : BaseController
    {
        /// <summary>
        /// Tüm projelerin geldiği uçnokta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
            GetAllProjectQueryRequest getAllProjectQueryRequest = new();
            List<ProjectModel> projectModels = await _mediator.Send(getAllProjectQueryRequest);

            return View(projectModels);
        }

        /// <summary>
        /// Projenin detaylarının getirildiği uçnokta
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProjectDetail")]
        public async Task<IActionResult> GetProjectDetail(Guid projectId)
        {
            GetProjectDetailRequest getProjectDetailRequest = new(projectId);
            ProjectModel project = await _mediator.Send(getProjectDetailRequest);

            return View(project);
        }

        [HttpGet]
        [Authorize(Roles = $"{Constant.Role.Admin}")]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{Constant.Role.Admin}")]
        public async Task<IActionResult> AddProject(AddProjectViewModel addProjectViewModel, IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                // Dosya adını benzersiz hale getirmek için GUID kullanın
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                // Klasörün var olup olmadığını kontrol edin, yoksa oluşturun
                if (!Directory.Exists(Path.Combine(_webHostEnvironment.WebRootPath, "images")))
                {
                    Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, "images"));
                }

                // Dosyanın wwwroot/uploads içerisine kaydedilir.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                // addProjectViewModel içindeki ImagePath'e yeni dosya adını ekleyin
                addProjectViewModel.ImagePath = "images/" + fileName;
            }

            AddProjectCommandRequest addProjectCommandRequest = new(addProjectViewModel);
            bool response = await _mediator.Send(addProjectCommandRequest);
            if (response is true)
                _toastNotification.AddSuccessToastMessage("Proje ekleme işlemi başarılı.");
            else
                _toastNotification.AddErrorToastMessage("Proje eklenirken bir hata oluştu.");
            return response is true ? RedirectToAction("Index", "Admin") : RedirectToAction("Index", "Admin");
        }
    }
}
