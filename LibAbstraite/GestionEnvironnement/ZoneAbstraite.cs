using System.Collections.Generic;
using LibAbstraite.GestionPersonnages;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class  ZoneAbstraite
    {
        public string Nom { get; set; }

        public int id { get; set; }
        public List<AccesAbstrait> AccesAbstraitList { get; set; }

        public List<PersonnageAbstrait> PersonnagesList { get; set; }

        // public List<Objet> ObjetsList { get; set; }

        protected ZoneAbstraite(string unNom)
        {
            Nom = unNom;
            AccesAbstraitList = new List<AccesAbstrait>();
            PersonnagesList = new List<PersonnageAbstrait>();
        }

        internal void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }

        internal void RetirePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Remove(unPersonnage);
        }

        public void AjouteAcces(AccesAbstrait acces)
        {
            AccesAbstraitList.Add(acces);
        }


    }
}