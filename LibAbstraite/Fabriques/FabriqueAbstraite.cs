using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;

namespace LibAbstraite.Fabriques
{
    public abstract class FabriqueAbstraite
    {
        public abstract EnvironnementAbstrait CreerEnvironment();
        public abstract ZoneAbstraite CreerZone(string nom);
        public abstract AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin);
        public abstract PersonnageAbstrait CreerPersonnage(string nom);
    }
}
