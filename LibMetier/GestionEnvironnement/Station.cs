﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionPersonnages;

namespace LibMetier.GestionEnvironnement
{
    class Station : ZoneAbstraite
    {
        public Station(string unNom) : base(unNom)
        {
        }
    }
}
