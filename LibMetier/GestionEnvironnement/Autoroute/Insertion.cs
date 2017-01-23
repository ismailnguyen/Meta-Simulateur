using LibAbstraite.GestionEnvironnement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.GestionEnvironnement.Autoroute
{
    public class Insertion : AccesAbstrait
    {
        public Insertion(ZoneAbstraite debut, ZoneAbstraite fin) : base(debut, fin)
        {
        }
    }
}
