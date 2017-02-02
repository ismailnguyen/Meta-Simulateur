using LibAbstraite.Simulateurs;
using LibMetier.Simulateurs;
using System;

namespace AutoroutesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulerAutoroutes();
            //SimulerFourmilière();
            //SimulerMetro();

            Console.ReadLine();
        }

        static void SimulerAutoroutes()
        {
            Console.WriteLine("----- Réseau autoroutiers ----- \n\n");

            SimulateurAbstrait simulateur = new SimulateurAutoroutes("scenarioAutoroutes.xml");

            simulateur.ChargerEnvironnement();

            Console.WriteLine(simulateur.LancerSimulation());
        }
    }
}
