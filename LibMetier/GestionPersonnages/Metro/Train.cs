using LibAbstraite.GestionPersonnages;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionPersonnages.Metro
{
    public class Train : PersonnageAbstrait
    {
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            return accesList[Position.id].Fin;
        }

        public override string ToString()
        {
            return "Train " + Nom;
        }
    }
}
