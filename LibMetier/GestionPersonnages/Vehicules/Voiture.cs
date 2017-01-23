using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Voiture : Vehicule
    {
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            return accesList[Hasard.Next(accesList.Count)].Fin;
        }
    }
}
