using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Voiture : Vehicule
    {
        public Voiture()
        {
            Carburant = 50;
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            var autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];

            // Check if highway is not already full, else choose an other route
            while (autoroute.Capacité <= 0)
            {
                autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];
            }

            var distanceParcourue = autoroute.Distance;

            var carburantConsommé = distanceParcourue / 4;

            var carburantRestant = Carburant - carburantConsommé;

            // Remove consummed fuel according with traveled distance
            Carburant = carburantRestant <= 0 ? 0 : carburantRestant;

            return autoroute.Fin;
        }
    }
}
