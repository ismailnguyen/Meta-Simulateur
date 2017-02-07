using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.Calculs;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Camion : Vehicule
    {
        public Camion() : base()
        {
            Carburant = 120;

            CalculCarburant = new CalculsCarburantCamion();
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
            return string.Format("[Camion, {0}, {1}]", Nom, Carburant);
        }
    }
}
