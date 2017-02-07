using System;
using System.Threading;
using LibAbstraite.Simulateurs;
using LibMetier.Simulateurs;

namespace AutoroutesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulerAutoroutes();

            Console.ReadLine();
        }

        static void SimulerAutoroutes()
        {
            Console.WriteLine("----- Réseau autoroutiers ----- \n\n");

            SimulateurAbstrait simulateur = new SimulateurAutoroutes("scenarioAutoroutes.xml");

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
