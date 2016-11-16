using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionPersonnages;

namespace LibMetier.Fabriques
{
    public class FabriqueFourmiliere : FabriqueAbstraite
    {
        public override EnvironnementAbstrait CreerEnvironment()
        {
            return new Fourmiliere();
        }

        public override ZoneAbstraite CreerZone(string nom)
        {
            return new BoutDeTerrain(nom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin)
        {
            return new Chemin(zdebut, zfin);
        }

        public override PersonnageAbstrait CreerPersonnage(string nom)
        {
            return new Fourmi {Nom = nom};
        }
    }
}
