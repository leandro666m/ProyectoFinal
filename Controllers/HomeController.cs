using Microsoft.AspNetCore.Authorization;
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
            var rule = new PublicacionRule(_configuration);
            var posts = rule.GetPostHome( );
            return View( posts );
        }
        public IActionResult Publicaciones( int cant = 5 , int pagina = 0) {
            var rule = new PublicacionRule(_configuration);
            var posts = rule.GetPublicaciones(  cant, pagina );
            return View( posts );
        }
        public IActionResult Post( int id ) {
            var rule = new PublicacionRule( _configuration );
            var post = rule.GetPostById( id );

            return View( post );
        }

        [Authorize] //para q solo ingresen los loggeados
        public IActionResult Nuevo(  ) {

            return View(  );
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add( Publicacion data   ) {
            var rule= new PublicacionRule( _configuration);
            rule.InsertPost( data );
            return RedirectToAction("Index");
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

        [HttpPost]
        public IActionResult Contact( Contact contacto ) {
            if ( !ModelState.IsValid ) {
                return View( "Contacto", contacto );
            }
            var rule = new ContactRule(_configuration);
            var mensaje = @"<h1>Gracias por contactarnos</h1>
                    <p>Hemos recibido tu correo exitosamente.</p>
                    <p>A la brevedad nos pondremos en contacto</p>
                    <hr/><p>Saludos</p> <p><b>Polo MC</b></p>";
            //le manda un msj de confirmacion a la persona
            rule.SendEmail( contacto.Email, mensaje, "Asunto Mensaje Recibido", "De quien: Polo Mina Clavero", "deQuienEmail: polo@polomc.com.ar" );
            //me manda un msj a mi para que me quede el msj y el rtte
            rule.SendEmail( "leandro666m@gmail.com", contacto.Mensaje, "Nuevo contacto", contacto.Nombre, contacto.Email );

            return View( "Contacto" );

        }



        [ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
        public IActionResult Error( ) {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}