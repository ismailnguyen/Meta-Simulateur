using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionEnvironnement
{
    class Rails : AccesAbstrait
    {
        public Rails(ZoneAbstraite debut, ZoneAbstraite fin) : base(debut, fin)
        {
        }
    }
}
