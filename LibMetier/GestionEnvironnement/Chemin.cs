using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionEnvironnement
{
    public class Chemin : AccesAbstrait
    {
        public Chemin(ZoneAbstraite debut, ZoneAbstraite fin) : base(debut, fin)
        {
        }
    }
}
