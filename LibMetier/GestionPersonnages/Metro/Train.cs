using LibAbstraite.GestionPersonnages;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Metro;
using System;

namespace LibMetier.GestionPersonnages.Metro
{
    public class Train : PersonnageAbstrait
    {
        public DateTime Passage { get; set; }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            return accesList[((Station)Position).Id].Fin;
        }

        public override string ToString()
        {
            return "Train " + Nom;
        }
    }
}
