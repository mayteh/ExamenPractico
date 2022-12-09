using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opc;

            Console.WriteLine("Seleccione La opcion a realizar");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Mostrar");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                        case 1:
                            Libro.Add();
                            Console.ReadKey();
                            break;

                        case 2:
                    Libro.GetAll();
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.ReadKey();
                            break;

                        case 5:
                            
                            Console.ReadKey();
                            break;

                        default:
                            break;

                    
            }
        }
    }
}
