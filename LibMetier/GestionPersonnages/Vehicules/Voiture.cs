using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

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
            return accesList[Hasard.Next(accesList.Count)].Fin;
        }
    }
}
