using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.GestionPersonnages.Vehicules;
using System.Collections.Generic;

namespace LibMetier.GestionPersonnages
{
    public abstract class Vehicule : PersonnageAbstrait
    {
        // Litres
        public int Carburant { get; set; }

        protected Vehicule()
        {
            Carburant = 0;
        }

        protected Autoroute ProchaineAutorouteLibre(List<AccesAbstrait> accesList)
        {
            var autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];

            // Check if highway is not already full, else choose an other route
            while (autoroute.Capacité <= 0)
            {
                autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];
            }

            return autoroute;
        }

        public abstract override string ToString();
    }
}
