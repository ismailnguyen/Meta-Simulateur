using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.Calculs;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Camion : Vehicule
    {
        public Camion()
        {
            Carburant = 120;
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            var autoroute = ProchaineAutorouteLibre(accesList);

            var distanceParcourue = autoroute.Distance;

            CalculCarburantAbstrait calculs = new CalculsCarburantCamion();

            Carburant = calculs.CarburantConsommé(distanceParcourue, Carburant);

            return autoroute.Fin;
        }
    }
}
