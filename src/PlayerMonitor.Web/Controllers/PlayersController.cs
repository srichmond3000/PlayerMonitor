using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PlayerMonitor.Core;
using PlayerMonitor.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Core.v3;
using PlayerMonitor.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PlayersController(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            return View(_unitOfWork.Players.GetAllPlayers());
        }

        public IActionResult Add()
        {
            var viewModel = new PlayerFormViewModel() {Heading = "Add Player"};

            return View("PlayerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Add(PlayerFormViewModel viewModel)
        {

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            return new EmptyResult();
        }

        public IActionResult Delete()
        {
            return new EmptyResult();
        }

        public ViewResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (file == null || file.Length == 0)
                return View();

            var buffer = new byte[file.Length];

            using (var stream = file.OpenReadStream())
            {
                stream.Read(buffer, 0, (int)file.Length);
            }

            var text = System.Text.Encoding.UTF8.GetString(buffer);

           return View();
        }
    }
}
