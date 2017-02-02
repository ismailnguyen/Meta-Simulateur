using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.Calculs;

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
            var autoroute = ProchaineAutorouteLibre(accesList);

            var distanceParcourue = autoroute.Distance;

            CalculCarburantAbstrait calculs = new CalculsCarburantMoto();

            Carburant = calculs.CarburantConsommé(distanceParcourue, Carburant);

            return autoroute.Fin;
        }
    }
}
