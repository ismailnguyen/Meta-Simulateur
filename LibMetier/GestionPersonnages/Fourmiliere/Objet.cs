using LibAbstraite.GestionPersonnages;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement;

namespace LibMetier.GestionPersonnages.Fourmiliere
{
    public class Objet : PersonnageAbstrait
    {
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            return new BoutDeTerrain("un bout de terrain");
        }

        public override string ToString()
        {
            return "Objet ";
        }
    }
}
