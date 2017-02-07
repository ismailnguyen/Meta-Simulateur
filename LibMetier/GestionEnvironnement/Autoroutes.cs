using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObservations;
using LibMetier.GestionPersonnages;
using System.Text;
using System.Collections.Generic;

namespace LibMetier.GestionEnvironnement
{
    public class Autoroutes : EnvironnementAbstrait, IObservateur
    {
        protected List<Vehicule> VéhiculesEnPanne = new List<Vehicule>();

        public override string Simuler()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Vehicule vehicule in PersonnagesList)
            {
                // Dépanneuse will observe vehicule to check fuel quantity
                vehicule.AjouterObservateur(this);

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

            récupérerVéhiculesEnPanne();

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

        // Notify dépanneuse that a vehicule is stopped due to empty fuel
        public void Notifier(IObservable observable)
        {
            var vehicule = (Vehicule)observable;

            if (!VéhiculesEnPanne.Contains(vehicule))
                VéhiculesEnPanne.Add(vehicule);
        }

        // Dépanneuse remove car from map
        private void récupérerVéhiculesEnPanne()
        {
            foreach (var vehicule in VéhiculesEnPanne)
            {
                PersonnagesList.RemoveAll(v => v.Nom.Equals(vehicule.Nom));
            }
        }
    }
}
