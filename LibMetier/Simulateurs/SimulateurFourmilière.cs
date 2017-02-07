using LibAbstraite.Simulateurs;
using LibMetier.Fabriques;
using LibMetier.GestionEnvironnement.Fourmiliere;
using LibMetier.GestionPersonnages.Fourmiliere;
using System.Linq;
using System.Xml.Linq;

namespace LibMetier.Simulateurs
{
    public class SimulateurFourmilière : SimulateurAbstrait
    {
        private string fichierEntrée;

        public SimulateurFourmilière(string _fichierEntrée)
        {
            fichierEntrée = _fichierEntrée;

            // Initialisation of a ant factory
            Fabrique = new FabriqueFourmiliere();

            // Initialisation of a ant environment
            Environnement = Fabrique.CreerEnvironment();
        }

        /***
         * Load environnement using input file
         ***/
        public override void ChargerEnvironnement()
        {
            // Load xml file (with Xml-to-Linq loader)
            var scenario = XDocument.Load(fichierEntrée);

            // Loop through root node named "Fourmiliere"
            foreach (XElement categorie in scenario.Descendants("Fourmiliere"))
            {
                // Zones
                var zones = categorie.Descendants("Zones");
                if (zones != null)
                {
                    foreach (XElement ville in zones.Nodes())
                    {
                        // Add each zone to zone list
                        var zone = Fabrique.CreerZone(ville.Attribute("nom").Value);
                        Environnement.ZoneAbstraitsList.Add(zone);
                    }
                }

                // Access
                var access = categorie.Descendants("Access");
                if (access != null)
                {
                    foreach (XElement element in access.Nodes())
                    {
                        // We retrieve zones from departure and arrival of this access
                        var nomZone1 = element.Attribute("zone1").Value;
                        var zone1 = Environnement.ZoneAbstraitsList.Where(x => x.Nom.StartsWith(nomZone1)).FirstOrDefault();

                        var nomZone2 = element.Attribute("zone2").Value;
                        var zone2 = Environnement.ZoneAbstraitsList.Where(x => x.Nom.StartsWith(nomZone2)).FirstOrDefault();

                        // We create the access using departure and arrival zones
                        var acces = Fabrique.CreerAcces(zone1, zone2);
                        Environnement.AccesAbstraitsList.Add(acces);
                    }
                }

                // If we are looking for ants
                var fourmis = categorie.Descendants("Fourmis");
                if (fourmis != null)
                {
                    // Create ant
                    foreach (XElement fourmi in fourmis.Nodes())
                    {
                        var nom = fourmi.Attribute("nom").Value;

                        Environnement.AjoutePersonnage(new Fourmi() { Nom = nom });
                    }
                }

                // If we are looking for objects
                var objets = categorie.Descendants("Objets");
                if (objets != null)
                {
                    // Create object
                    foreach (XElement element in objets.Nodes())
                    {
                        // Retrieve the position of the object
                        var position = element.Attribute("position").Value;

                        // Retrieve the zone corresponding of the position
                        var zone = Environnement.ZoneAbstraitsList.Where(x => x.Nom.Equals(position)).FirstOrDefault();

                        // Create the object
                        var objet = new Objet() { Position = zone };

                        // Add object to the parcel 
                        ((BoutDeTerrain)zone).AjouteObjet(objet);
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