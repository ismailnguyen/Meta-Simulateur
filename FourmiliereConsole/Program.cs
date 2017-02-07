using System;
using System.Threading;
using LibAbstraite.Simulateurs;
using LibMetier.Simulateurs;

namespace FourmiliereConsole
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
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

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("simulation");
                Console.WriteLine(Metro.SimulerMetro());
            }

            Console.ReadLine();
=======
            SimulerFourmilière();

            Console.ReadLine();
        }

        static void SimulerFourmilière()
        {
            Console.WriteLine("----- Fourmilière ----- \n\n");

            SimulateurAbstrait simulateur = new SimulateurFourmilière("scenarioFourmiliere.xml");

            simulateur.ChargerEnvironnement();

            // Launch four simulation with 2 seconds waiting between each simulation
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(simulateur.LancerSimulation());

                Thread.Sleep(2000);
            }

            Console.WriteLine(simulateur.Environnement.Statistiques());
>>>>>>> refs/remotes/origin/simulation/fourmiliere
        }
    }
}
