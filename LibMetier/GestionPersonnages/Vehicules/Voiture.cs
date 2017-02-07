using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.Calculs;
using LibMetier.GestionEnvironnement.Autoroute;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Voiture : Vehicule
    {
        public Voiture() : base()
        {
            Carburant = 50;

            CalculCarburant = new CalculsCarburantVoiture();
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            var autoroute = ProchaineAutorouteLibre(accesList);

            var distanceParcourue = autoroute.Distance;

            Carburant = CalculCarburant.CarburantConsommé(distanceParcourue, Carburant);

            return autoroute.Fin;
        }

        public override string ToString()
        {
            return string.Format("[Voiture, {0}, {1}]", Nom, Carburant);
        }
    }
}
