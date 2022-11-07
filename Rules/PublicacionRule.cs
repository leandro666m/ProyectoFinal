using ProyectoFinal.Models;

namespace ProyectoFinal.Rules {
    public class PublicacionRule {

        public Publicacion GetOnePostRandom( ) {
            //ahora 'harcodeado' pero va a tener q buscar una pub random en la BD
            var post = new Publicacion{
                Titulo="Titulo de post hardodeado",
                SubTitulo="Sub Titulo de post hardodeado",
                Cuerpo="Cuerpo de post hardodeado",
                Creacion= new DateTime(1987, 03, 26),
                Creador="Creador de post hardodeado",
                Imagen="/assets/img/port-bg.jpg"
            };

            return post;
        }

    }
}
