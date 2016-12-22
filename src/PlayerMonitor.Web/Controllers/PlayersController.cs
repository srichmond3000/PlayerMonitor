using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerMonitor.Core;
using PlayerMonitor.Core.RepositoryInterfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }
        
        public IActionResult Index()
        {
            return View(_unitOfWork.Players.GetAllPlayers());
        }
    }
}
