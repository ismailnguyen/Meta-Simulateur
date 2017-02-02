using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;
using LibMetier.GestionPersonnages.Vehicules;
using System.Text;

namespace LibMetier.GestionEnvironnement
{
    public class Autoroutes : EnvironnementAbstrait
    {
        protected override void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite zoneAbstraiteCible,
            ZoneAbstraite zoneAbstraiteSource)
        {
            base.DeplacerPersonnage(unPersonnage, zoneAbstraiteCible, zoneAbstraiteSource);


            ((Vehicule)unPersonnage).Carburant--;
        }

        public override string Simuler()
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

                    var typeVéhicule = "";
                    if (unPersonnage.GetType() == typeof(Moto))
                    {
                        typeVéhicule = "Moto";
                    }
                    else if (unPersonnage.GetType() == typeof(Camion))
                    {
                        typeVéhicule = "Camion";
                    }
                    else
                    {
                        typeVéhicule = "Voiture";
                    }

                    sb.AppendFormat(
                        "{0} {1} va de {2} à {3} en prenant l'autoroute \n",
                        typeVéhicule,
                        unPersonnage.Nom, 
                        zoneAbstraiteSource.Nom,
                        zoneAbstraiteCible.Nom
                    );
                }
                else
                {
                    sb.AppendFormat("{0} : dans cul de sac\n", unPersonnage.Nom);
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
