using System.Text;
using System.Collections.Generic;
using LibAbstraite.GestionPersonnages;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class EnvironnementAbstrait
    {
        public List<PersonnageAbstrait> PersonnagesList { get; set; } = new List<PersonnageAbstrait>();
        public List<ZoneAbstraite> ZoneAbstraitsList { get; set; } = new List<ZoneAbstraite>();
        public List<AccesAbstrait> AccesAbstraitsList { get; set; } = new List<AccesAbstrait>();

        public virtual void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
            ZoneAbstraitsList[0].AjoutePersonnage(unPersonnage);
            unPersonnage.Position = ZoneAbstraitsList[0];
        }

        public virtual void AjouteZoneAbstraits(params ZoneAbstraite[] zoneAbstraitsArray)
        {
            ZoneAbstraitsList.AddRange(zoneAbstraitsArray);
        }

        public virtual string Simuler()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PersonnageAbstrait unPersonnage in PersonnagesList)
            {
                ZoneAbstraite zoneAbstraiteSource = unPersonnage.Position;

                var accesList = zoneAbstraiteSource.AccesAbstraitList;
                if (accesList.Count > 0)
                {
                    ZoneAbstraite zoneAbstraiteCible = unPersonnage.ChoixZoneSuivante(accesList);

                    DeplacerPersonnage(unPersonnage, zoneAbstraiteSource, zoneAbstraiteCible);
                    sb.AppendFormat("{0} : {1} --> {2}\n", unPersonnage.Nom, zoneAbstraiteSource.Nom,
                        zoneAbstraiteCible.Nom);
                }
                else
                {
                    sb.AppendFormat("{0} : dans cul de sac\n", unPersonnage.Nom);
                }
            }
            return sb.ToString();
        }

        protected virtual void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite zoneAbstraiteCible,
            ZoneAbstraite zoneAbstraiteSource)
        {
            unPersonnage.Position = zoneAbstraiteCible;
            zoneAbstraiteSource.RetirePersonnage(unPersonnage);
            zoneAbstraiteCible.AjoutePersonnage(unPersonnage);
        }

        public virtual string Statistiques()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ZoneAbstraitsList.Count + " Zones");
            sb.AppendLine(AccesAbstraitsList.Count + " Accès");
            return sb.ToString();
        }
    }
}
