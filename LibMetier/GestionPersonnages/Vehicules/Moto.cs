using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.Calculs;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Moto : Vehicule
    {
        public Moto() : base()
        {
            Carburant = 15;

            CalculCarburant = new CalculsCarburantMoto();
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
            return string.Format("[Moto, {0}, {1}]", Nom, Carburant);
        }
    }
}
