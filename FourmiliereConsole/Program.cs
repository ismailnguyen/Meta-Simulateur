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

            Console.WriteLine(simulateur.Statistiques());
        }
    }
}
