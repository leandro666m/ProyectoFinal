using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Rules;
using System.Diagnostics;

namespace ProyectoFinal.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController( ILogger<HomeController> logger ) {
            _logger = logger;
        }

        public IActionResult Index( ) {
            return View( );
        }
        public IActionResult About( ) {
            return View( );
        }
        public IActionResult Suerte( ) {
            var rule = new PublicacionRule();
            var post = rule.GetOnePostRandom( );
            return View(post); //en la View recibe esto poniendo @model Publicacion
        }
        public IActionResult Contact( ) {
            return View( );
        }





        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error( ) {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}