using System;
using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibMetier.Fabriques;

namespace FourmiliereConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*      Console.WriteLine("----- Fourmilière -----");

                  FabriqueAbstraite uneFabrique = new FabriqueFourmiliere();

                  EnvironnementAbstrait fourmiPalace = uneFabrique.CreerEnvironment();
                  fourmiPalace.ChargerEnvironnement(uneFabrique);
                  fourmiPalace.ChargerPersonnages(uneFabrique);

                  Console.WriteLine(fourmiPalace.Statistiques());

                  for (int i = 0; i < 10; i++)
                  {
                      Console.WriteLine(fourmiPalace.Simuler());
                  }*/

            Console.WriteLine("----- Metro -----");
            FabriqueAbstraite depotMetro = new FabriqueMetro();
            EnvironnementAbstrait Metro = depotMetro.CreerEnvironment();
            Metro.ChargerEnvironnement(depotMetro);
            Metro.ChargerPersonnages(depotMetro);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Metro.Simuler());
            }

            Console.ReadLine();
        }
    }
}
