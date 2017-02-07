using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.GestionPersonnages.Autoroute;

namespace LibMetier.Fabriques
{
    public class FabriqueAutoroutes : FabriqueAbstraite
    {
        public override EnvironnementAbstrait CreerEnvironment()
        {
            return new EnvironnementAutoroute();
        }

        public override ZoneAbstraite CreerZone(string nom)
        {
            return new Ville(nom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin)
        {
            return new Route(zdebut, zfin);
        }

        public override PersonnageAbstrait CreerPersonnage(string nom)
        {
            return new Voiture();
        }
    }
}
