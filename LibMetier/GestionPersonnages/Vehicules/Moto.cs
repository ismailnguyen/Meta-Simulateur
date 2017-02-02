using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Moto : Vehicule
    {
        public Moto()
        {
            Carburant = 15;
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            var autoroute = accesList[Hasard.Next(accesList.Count)];
            var distanceParcourue = ((Autoroute)autoroute).Distance;

            var carburantConsommé = distanceParcourue / 3;

            // Remove consummed fuel according with traveled distance
            Carburant -= carburantConsommé;

            return autoroute.Fin;
        }
    }
}
