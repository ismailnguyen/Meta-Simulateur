using System.Collections.Generic;
using System.Text;
using LibAbstraite.Fabriques;
using LibAbstraite.GestionPersonnages;
using System.Xml;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class EnvironnementAbstrait
    {
        public List<PersonnageAbstrait> PersonnagesList { get; set; }
        public List<ZoneAbstraite> ZoneAbstraitsList { get; set; }
        public List<AccesAbstrait> AccesAbstraitsList { get; set; }

        public List<PersonnageAbstrait> TrainsList { get; set; }
        public List<ZoneAbstraite>  StationsList { get; set; }
        public List<AccesAbstrait>  RailsList { get; set; }

        protected EnvironnementAbstrait()
        {
            PersonnagesList = new List<PersonnageAbstrait>();
            ZoneAbstraitsList = new List<ZoneAbstraite>();
            AccesAbstraitsList = new List<AccesAbstrait>();

            TrainsList = new List<PersonnageAbstrait>();
            StationsList = new List<ZoneAbstraite>();
            RailsList = new List<AccesAbstrait>();
        }

       

        //----------------------------------------------------------------------
        public void ChargerEnvironnement(FabriqueAbstraite fabrique)
        { 
            ZoneAbstraite b1 = fabrique.CreerZone("b1-Depart");
            ZoneAbstraite b2 = fabrique.CreerZone("b2");
            ZoneAbstraite b3 = fabrique.CreerZone("b3");
            ZoneAbstraite b4 = fabrique.CreerZone("b4");
            ZoneAbstraite b5 = fabrique.CreerZone("b5");
            AjouteZoneAbstraits(b1, b2, b3, b4, b5);

            AccesAbstrait ch1 = fabrique.CreerAcces(b1, b2);
            AccesAbstrait ch2 = fabrique.CreerAcces(b2, b3);
            AccesAbstrait ch3 = fabrique.CreerAcces(b3, b4);
            AccesAbstrait ch4 = fabrique.CreerAcces(b3, b5);
            AccesAbstrait ch5 = fabrique.CreerAcces(b1, b5);
            AccesAbstrait ch6 = fabrique.CreerAcces(b2, b4);
            AjouteChemins(fabrique, ch1, ch2, ch3, ch4, ch5, ch6);
        }

        public void ChargerLigne(FabriqueAbstraite fabrique)
        {
            //LIRE XML CREER STATIONS
            /*
            xml doc ...
            foreach(station in stationlist)
            {
             ZoneAbstraite nomstation = fabrique.CreerZone("nomstation");  
             AjouteZoneAbstraits(nomstation);
            }
            stationlist.orderby(id)
            foreach(station in stationlist)
            {
             AccesAbstrait ch1 = fabrique.CreerAcces(sation1, station2);
             AjouteChemins(fabrique, ch1);
            }
            */

        }

        public virtual void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
            ZoneAbstraitsList[0].AjoutePersonnage(unPersonnage);
            unPersonnage.Position = ZoneAbstraitsList[0];
        }

        public virtual void AjouteTrain(PersonnageAbstrait unTrain)
        {
            TrainsList.Add(unTrain);
            //lecture xml
            // int position = xml.pos;
            StationsList[0].AjoutePersonnage(unTrain);
            unTrain.Position = ZoneAbstraitsList[0];
        }

        public void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            AjoutePersonnage(fabrique.CreerPersonnage("jacques"));
            AjoutePersonnage(fabrique.CreerPersonnage("beatrice"));
        }

        public void ChargerTrains(FabriqueAbstraite fabrique)
        {
            //LIRE XML AJOUTER DYNAMIQUEMENT LES TRAINS
            /*
            foreach(train in TrainList)
            {
             AjoutePersonnage(fabrique.CreerPersonnage(train.name));
            }
            */
        }
        //----------------------------------------------------------------------
        private void AjouteZoneAbstraits(params ZoneAbstraite[] zoneAbstraitsArray)
        {
            ZoneAbstraitsList.AddRange(zoneAbstraitsArray);
        }

        //----------------------------------------------------------------------
        private void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {
            AccesAbstraitsList.AddRange(accesArray);
            foreach (var acces in accesArray)
            {
                AccesAbstrait accesInverse = fabrique.CreerAcces(acces.Fin, acces.Debut);
                AccesAbstraitsList.Add(accesInverse);
            }
        }

        
        public string Simuler()
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

        public string SimulerMetro()
        {
            StringBuilder sb = new StringBuilder();
            foreach(PersonnageAbstrait unTrain in TrainsList)
            {
                ZoneAbstraite source = unTrain.Position;
            }
            return "coucou";
        }

        private void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite zoneAbstraiteCible,
            ZoneAbstraite zoneAbstraiteSource)
        {
            unPersonnage.Position = zoneAbstraiteCible;
            zoneAbstraiteSource.RetirePersonnage(unPersonnage);
            zoneAbstraiteCible.AjoutePersonnage(unPersonnage);
        }


        public string Statistiques()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ZoneAbstraitsList.Count + " Zones");
            sb.AppendLine(AccesAbstraitsList.Count + " Accès");
            return sb.ToString();
        }


    }
}
