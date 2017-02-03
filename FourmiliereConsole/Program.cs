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

            Metro.ChargerLigne(depotMetro);
            Console.WriteLine("ligne chargée");
            Metro.ChargerTrains(depotMetro);
            Console.WriteLine("trains chargés");

           
                Console.WriteLine("simulation");
                Console.WriteLine(Metro.SimulerMetro());
            

            Console.ReadLine();
        }
    }
}
