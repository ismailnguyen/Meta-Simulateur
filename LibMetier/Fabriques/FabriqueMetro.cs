using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Metro;
using LibMetier.GestionPersonnages.Metro;

namespace LibMetier.Fabriques
{
    public class FabriqueMetro : FabriqueAbstraite
    {
        public override EnvironnementAbstrait CreerEnvironment()
        {
            return new EnvironnementMetro();
        }

        public override ZoneAbstraite CreerZone(string nom)
        {
            return new Station(nom);
        }

        public override AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin)
        {
            return new Rails(zdebut, zfin);
        }

        public override PersonnageAbstrait CreerPersonnage(string nom)
        {
            return new Train { Nom = nom };
        }
    }
}