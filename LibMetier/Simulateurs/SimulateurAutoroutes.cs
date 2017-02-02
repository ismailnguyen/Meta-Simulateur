using LibAbstraite.Simulateurs;
using LibMetier.Fabriques;
using LibMetier.GestionEnvironnement;
using System.Xml.Linq;
using System.Linq;
using LibMetier.GestionPersonnages.Vehicules;

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
            Environnement = new Autoroutes();
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
                if (categorie.Descendants("villes") != null)
                {
                    foreach (XElement ville in categorie.Descendants("villes").Nodes())
                    {
                        // Add each city to zone list
                        var zone = Fabrique.CreerZone(ville.Attribute("nom").Value);
                        Environnement.ZoneAbstraitsList.Add(zone);
                    }
                }

                // Highways
                if (categorie.Descendants("autoroutes") != null)
                {
                    foreach (XElement autoroute in categorie.Descendants("autoroutes").Nodes())
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
                if (categorie.Descendants("vehicules") != null)
                {
                    // Create vehicule with associated type
                    foreach (XElement vehicule in categorie.Descendants("vehicules").Nodes())
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
            return base.LancerSimulation(11);
        }
    }
}
