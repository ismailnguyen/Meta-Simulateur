﻿using System;
using System.Collections.Generic;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;

namespace LibMetier.GestionPersonnages
{
    public class Fourmi : PersonnageAbstrait
    {
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            int x = Hasard.Next(accesList.Count);
            return accesList[x].Fin;
        }

        public override string ToString()
        {
            return "Fourmi " + Nom;
        }
    }
}
