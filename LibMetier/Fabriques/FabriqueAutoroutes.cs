using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Autoroute;
using LibMetier.GestionPersonnages.Vehicules;

namespace LibMetier.Fabriques
{
    public class FabriqueAutoroutes : FabriqueAbstraite
    {
        public override EnvironnementAbstrait CreerEnvironment()
        {
            return new Autoroutes();
        }

        public override ZoneAbstraite CreerZone(string nom)
        {
            return new Autoroute(nom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin)
        {
            return new Ville(zdebut, zfin);
        }

        public override PersonnageAbstrait CreerPersonnage(string nom)
        {
            return new Voiture();
        }
    }
}
