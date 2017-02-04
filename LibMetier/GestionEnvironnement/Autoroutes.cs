using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionPersonnages;
using System.Text;

namespace LibMetier.GestionEnvironnement
{
    public class Autoroutes : EnvironnementAbstrait
    {
        public Vehicule Dépanneuse { get; set; }

        public override string Simuler()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Vehicule vehicule in PersonnagesList)
            {
                ZoneAbstraite zoneAbstraiteSource = vehicule.Position;

                var accesList = zoneAbstraiteSource.AccesAbstraitList;
                if (accesList.Count > 0)
                {
                    ZoneAbstraite zoneAbstraiteCible = vehicule.ChoixZoneSuivante(accesList);

                    DeplacerPersonnage(vehicule, zoneAbstraiteSource, zoneAbstraiteCible);

                    sb.AppendFormat(
                        "{0} : {1} à {2}\n",
                        vehicule.ToString(),
                        zoneAbstraiteSource.Nom,
                        zoneAbstraiteCible.Nom
                    );
                }
                else
                {
                    sb.AppendFormat("{0} : dans cul de sac\n", vehicule.ToString());
                }
            }

            return sb.ToString();
        }

        public override string Statistiques()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(PersonnagesList.Count + " véhicules en circulation");
            sb.AppendLine(ZoneAbstraitsList.Count + " villes");
            sb.AppendLine(AccesAbstraitsList.Count + " autoroutes");

            return sb.ToString();
        }
    }
}
