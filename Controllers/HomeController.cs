using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Rules;
using System.Diagnostics;

namespace ProyectoFinal.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController( ILogger<HomeController> logger, IConfiguration configuration ) {
            _logger = logger;
            _configuration = configuration; //aca viene y se carga lo que puse en el program.cs -> builder.Configuration.AddJsonFile( "appSettings.Leandro.json");
        }

        public IActionResult Index( ) {
            return View( );
        }
        public IActionResult About( ) {
            return View( );
        }

        public IActionResult Suerte( ) {
            var rule = new PublicacionRule( _configuration );
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