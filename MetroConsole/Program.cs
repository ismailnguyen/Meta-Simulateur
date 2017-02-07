using System;
using LibAbstraite.Simulateurs;
using LibMetier.Simulateurs;

namespace MetroConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulerMetro();

            Console.ReadLine();
        }

        static void SimulerMetro()
        {
            Console.WriteLine("----- Metro -----");

            SimulateurAbstrait simulateur = new SimulateurMetro("scenarioMetro.xml");

            simulateur.ChargerEnvironnement();

            Console.WriteLine(simulateur.LancerSimulation());

            Console.WriteLine(simulateur.Environnement.Statistiques());
        }
    }
}
