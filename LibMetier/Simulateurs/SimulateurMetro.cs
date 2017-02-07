using LibAbstraite.Simulateurs;
using LibMetier.Fabriques;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using LibAbstraite.GestionEnvironnement;
using LibMetier.GestionEnvironnement.Metro;
using LibMetier.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;

namespace LibMetier.Simulateurs
{
    public class SimulateurMetro : SimulateurAbstrait
    {
        private string fichierEntrée;

        public SimulateurMetro(string _fichierEntrée)
        {
            fichierEntrée = _fichierEntrée;

            // Initialisation of a metro factory
            Fabrique = new FabriqueMetro();

            // Initialisation of a metro environment
            Environnement = Fabrique.CreerEnvironment();
        }

        /***
         * Load environnement using input file
         ***/
        public override void ChargerEnvironnement()
        {
            // Load xml file (with Xml-to-Linq loader)
            var scenario = XDocument.Load(fichierEntrée);

            foreach (XElement node in scenario.Descendants("lignes").Nodes())
            {
                if (node.Descendants("ligne") != null)
                {
                    var stations = node.Descendants("stations");
                    if (stations != null)
                    {
                        foreach (XElement st in stations.Nodes())
                        {
                            ZoneAbstraite station = Fabrique.CreerZone(st.Attribute("name").Value);
                            ((Station)station).Id = int.Parse(st.Attribute("id").Value);
                            Environnement.AjouteZoneAbstraits(station);
                        }
                    }

                    var trains = node.Descendants("trains");
                    if (trains != null)
                    {
                        foreach (XElement tr in trains.Nodes())
                        {
                            //GERE ICI + DEPART/ARRIVEE
                            PersonnageAbstrait train = Fabrique.CreerPersonnage(tr.Attribute("name").Value);
                            ((EnvironnementMetro)Environnement).AjouteTrain(train, "1");
                        }
                    }
                }
            }

            Environnement.ZoneAbstraitsList.OrderBy(station => ((Station)station).Id);

            int count = 0;
            ZoneAbstraite temp = Fabrique.CreerZone("temp");
            foreach (Station station in Environnement.ZoneAbstraitsList)
            {
                if (count == 0)
                {
                    temp = station;
                }
                else
                {
                    AccesAbstrait ch = Fabrique.CreerAcces(temp, station);
                    ((EnvironnementMetro)Environnement).AjouteRail(Fabrique, ch);
                    temp = station;
                }
                count += 1;
            }
        }

        public override string LancerSimulation()
        {
            var text = new StringBuilder();
            
            text.AppendLine("ligne chargée");
            text.AppendLine("trains chargés");

            for (int i = 0; i < 10; i++)
            {
                text.AppendLine("simulation");
                text.AppendLine(Environnement.Simuler());
            }

            return text.ToString();
        }
    }
}
