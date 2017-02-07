using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionPersonnages.Fourmiliere;
using System.Collections.Generic;

namespace LibMetier.GestionEnvironnement
{
    public class BoutDeTerrain : ZoneAbstraite
    {
        public List<Objet> ObjetsList { get; set; } = new List<Objet>();

        public BoutDeTerrain(string unNom) : base(unNom)
        {
        }

        public void AjouteObjet(Objet objet)
        {
            ObjetsList.Add(objet);
        }

        public void EnleveObjet(Objet objet)
        {
            ObjetsList.Remove(objet);
        }
    }
}
