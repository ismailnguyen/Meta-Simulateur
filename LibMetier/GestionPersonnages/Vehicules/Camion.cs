using System;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

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
            throw new NotImplementedException();
        }
    }
}
