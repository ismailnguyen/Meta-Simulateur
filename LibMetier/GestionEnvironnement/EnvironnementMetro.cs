using LibAbstraite.GestionEnvironnement;
using System.Text;
using LibAbstraite.GestionPersonnages;
using LibAbstraite.Fabriques;

namespace LibMetier.GestionEnvironnement
{
    public class EnvironnementMetro : EnvironnementAbstrait
    {
        public override string Simuler()
        {
            var text = new StringBuilder();

            foreach (var unTrain in PersonnagesList)
            {
                ZoneAbstraite source = unTrain.Position;

                //Si ce n'est pas le terminus
                if (AccesAbstraitsList.Count > 0)
                {
                    //Changer de méthode (pas de hasard)
                    ZoneAbstraite cible = unTrain.ChoixZoneSuivante(AccesAbstraitsList);

                    DeplacerPersonnage(unTrain, source, cible);
                    text.AppendFormat("{0} : {1} --> {2}\n", unTrain.Nom, source.Nom,
                        cible.Nom);
                }
                else
                {
                    text.AppendFormat("{0} : terminus\n", unTrain.Nom);
                }
            }

            return text.ToString();
        }

        public void AjouteTrain(PersonnageAbstrait unTrain, string depart)
        {
            var pos = int.Parse(depart);

            AjoutePersonnage(unTrain);
        }

        public void AjouteStationAbstraits(ZoneAbstraite station)
        {
            ZoneAbstraitsList.Add(station);
        }

        public void AjouteRail(FabriqueAbstraite fabrique, AccesAbstrait rail)
        {
            AccesAbstraitsList.Add(rail);
            AccesAbstrait accesInverse = fabrique.CreerAcces(rail.Fin, rail.Debut);
            AccesAbstraitsList.Add(accesInverse);
        }
    }
}
