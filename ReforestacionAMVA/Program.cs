using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaCorantioquia;

namespace ReforestacionAMVA
{
    class Program
    {
        static void Main(string[] args)
        {
            byte actividades = 100;

            Console.WriteLine("Programa que simula 100 actividades de reforestacion");
            Console.WriteLine($"Se evaluan {actividades} actividades de reforestancion realizadas por la comunidad y por proveedores");

            Corantioquia corantioquia = new Corantioquia(new ActividadReforestacion[actividades]);

            corantioquia.TotalizaDatos();

            Console.WriteLine(corantioquia.ObtieneInfo());
            Console.WriteLine(corantioquia.ToString());
        }
    }
}
