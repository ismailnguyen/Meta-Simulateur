using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibMetier.Fabriques;
using System;

namespace AutoroutesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Réseau autoroutiers -----");

            FabriqueAbstraite uneFabrique = new FabriqueAutoroutes();

            EnvironnementAbstrait reseauAutoroutiers = uneFabrique.CreerEnvironment();
            reseauAutoroutiers.ChargerEnvironnement(uneFabrique);
            reseauAutoroutiers.ChargerPersonnages(uneFabrique);

            Console.WriteLine(reseauAutoroutiers.Statistiques());

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(reseauAutoroutiers.Simuler());
            }

            Console.ReadLine();
        }
    }
}
