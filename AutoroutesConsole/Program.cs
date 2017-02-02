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
            Console.WriteLine("----- Réseau autoroutiers -----");

            SimulateurAbstrait simulateur = new SimulateurAutoroutes("scenarioAutoroutes.xml");

            simulateur.Initialiser();

            Console.WriteLine(simulateur.LancerSimulation());
        }
    }
}
