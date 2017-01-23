using System;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

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
            throw new NotImplementedException();
        }
    }
}
