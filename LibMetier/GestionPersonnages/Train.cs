using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;

namespace LibMetier.GestionPersonnages
{
    class Train : PersonnageAbstrait
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