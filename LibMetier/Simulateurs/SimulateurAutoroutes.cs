using LibAbstraite.Simulateurs;
using LibMetier.Fabriques;
using System.Xml.Linq;
using System.Linq;
using LibMetier.GestionPersonnages.Autoroute;

namespace LibMetier.Simulateurs
{
    public class SimulateurAutoroutes : SimulateurAbstrait
    {
        private string fichierEntrée;
   
        public SimulateurAutoroutes(string _fichierEntrée)
        {
            fichierEntrée = _fichierEntrée;

            // Initialisation of a higwhay factory
            Fabrique = new FabriqueAutoroutes();

            // Initialisation of a highway environment
            Environnement = Fabrique.CreerEnvironment();
        }

        /***
         * Load environnement using input file
         ***/
        public override void ChargerEnvironnement()
        {
            // Load xml file (with Xml-to-Linq loader)
            var scenario = XDocument.Load(fichierEntrée);

            // Loop through root node named "simulation"
            foreach (XElement categorie in scenario.Descendants("simulation"))
            {
                // Cities
                var villes = categorie.Descendants("villes");
                if (villes != null)
                {
                    foreach (XElement ville in villes.Nodes())
                    {
                        // Add each city to zone list
                        var zone = Fabrique.CreerZone(ville.Attribute("nom").Value);
                        Environnement.AjouteZoneAbstraits(zone);
                    }
                }

                // Highways
                var autoroutes = categorie.Descendants("autoroutes");
                if (autoroutes != null)
                {
                    foreach (XElement autoroute in autoroutes.Nodes())
                    {
                        // We retrieve cities from departure and arrival of this highway
                        var entree = Environnement.ZoneAbstraitsList.Where(x => x.Nom.Equals(autoroute.Attribute("entree").Value)).FirstOrDefault();
                        var sortie = Environnement.ZoneAbstraitsList.Where(x => x.Nom.Equals(autoroute.Attribute("sortie").Value)).FirstOrDefault();

                        // We create the highway using departure and arrival cities
                        var acces = Fabrique.CreerAcces(entree, sortie);
                        Environnement.AccesAbstraitsList.Add(acces);
                    }
                }

                // If we are looking for vehicles
                var vehicules = categorie.Descendants("vehicules");
                if (vehicules != null)
                {
                    // Create vehicule with associated type
                    foreach (XElement vehicule in vehicules.Nodes())
                    {
                        var carburant = int.Parse(vehicule.Attribute("carburant").Value);
                        var immatriculation = vehicule.Attribute("plaque").Value;

                        switch (vehicule.Attribute("type").Value)
                        {
                            case "moto":
                                Environnement.AjoutePersonnage(new Moto() { Nom = immatriculation, Carburant = carburant });
                                break;

                            case "camion":
                                Environnement.AjoutePersonnage(new Camion() { Nom = immatriculation, Carburant = carburant });
                                break;

                            case "voiture":
                            default:
                                Environnement.AjoutePersonnage(new Voiture() { Nom = immatriculation, Carburant = carburant });
                                break;
                        }
                    }
                }
            }
        }

        public override string LancerSimulation()
        {
            return Environnement.Simuler();
        }
    }
}
