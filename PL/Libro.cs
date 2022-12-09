using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro(); //Instancia


            Console.WriteLine("Ingrese los datos del libro\n");
            Console.WriteLine("Ingrese el nombre");
            libro.NombreLibro = Console.ReadLine();
            Console.WriteLine("Ingrese el id del autor");
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su fecha de la publicacion dd-MM-yyy");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Ingrese el id de la editorial");
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la Edicion");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("Ingrese el id de la editorial");
            libro.Genero = new ML.Genero();
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro); 

            if (result.Correct)
            {
                Console.WriteLine("Se agrego correctamente");
                Console.ReadKey();
            }
        }//YA  
    }
}
