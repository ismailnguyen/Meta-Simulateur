using System;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

namespace LibAbstraite.GestionPersonnages
{
    public abstract class PersonnageAbstrait
    {
        protected static readonly Random Hasard = new Random();

        public string Nom { get; set; }
        public int nbPassager { get; set; }

        public ZoneAbstraite Position { get; set; }
        

        protected PersonnageAbstrait()
        {
            Position = null;
        }

        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);

    }
}
