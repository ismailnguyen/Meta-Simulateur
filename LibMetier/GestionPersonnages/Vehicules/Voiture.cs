using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.Calculs;

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
            var autoroute = ProchaineAutorouteLibre(accesList);

            var distanceParcourue = autoroute.Distance;

            CalculCarburantAbstrait calculs = new CalculsCarburantVoiture();

            Carburant = calculs.CarburantConsommé(distanceParcourue, Carburant);

            return autoroute.Fin;
        }

        public override string ToString()
        {
            return string.Format("[Voiture, {0}, {1}]", Nom, Carburant);
        }
    }
}
