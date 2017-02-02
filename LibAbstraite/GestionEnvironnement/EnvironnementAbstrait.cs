using System.Collections.Generic;
using System.Text;
using LibAbstraite.Fabriques;
using LibAbstraite.GestionPersonnages;
using System.Linq;
using System.Xml.Linq;
using System;
using Newtonsoft.Json;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class EnvironnementAbstrait
    {
        public List<PersonnageAbstrait> PersonnagesList { get; set; }
        public List<ZoneAbstraite> ZoneAbstraitsList { get; set; }
        public List<AccesAbstrait> AccesAbstraitsList { get; set; }

        public List<PersonnageAbstrait> TrainsList { get; set; }
        public List<ZoneAbstraite> StationsList { get; set; }
        public List<AccesAbstrait> RailsList { get; set; }

        private XDocument scenario;


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
        //-------------------------------------------------------------------------------
        public void ChargerLigne(FabriqueAbstraite fabrique)
        {
            scenario = XDocument.Load("scenarioMetro.xml");

            foreach (XElement node in scenario.Descendants("lignes").Nodes())
            {
                if (node.Descendants("ligne") != null)
                {
                    if (node.Descendants("stations") != null)
                    {
                        foreach (XElement st in scenario.Descendants("stations").Nodes())
                        {

                            if (st.Descendants("station") != null)
                            {
                                ZoneAbstraite station = fabrique.CreerZone(st.Attribute("name").Value);
                                station.id = Int32.Parse(st.Attribute("id").Value);
                                AjouteStationAbstraits(station);
                            }
                        }
                    }
                }
            }

            StationsList.OrderBy(o => o.id);
            int count = 0;
            ZoneAbstraite temp = fabrique.CreerZone("temp");
            foreach (ZoneAbstraite station in StationsList)
            {
                if (count == 0)
                {
                    temp = station;
                }
                else {
                    AccesAbstrait ch = fabrique.CreerAcces(temp, station);
                    AjouteRail(fabrique, ch);
                    temp = station;
                }
                count += 1;
            }
        }
        //-------------------------------------------------------------------------
        public virtual void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
            ZoneAbstraitsList[0].AjoutePersonnage(unPersonnage);
            unPersonnage.Position = ZoneAbstraitsList[0];
        }
        //------------------------------------------------------------------------
        public virtual void AjouteTrain(PersonnageAbstrait unTrain, string depart)
        {
            int pos = Int32.Parse(depart);
            pos -= 1;

            TrainsList.Add(unTrain);
            StationsList[pos].AjoutePersonnage(unTrain);
            unTrain.Position = StationsList[pos];
        }
        //--------------------------------------------------------------------
        public void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            AjoutePersonnage(fabrique.CreerPersonnage("jacques"));
            AjoutePersonnage(fabrique.CreerPersonnage("beatrice"));
        }
        //---------------------------------------------------------------------
        public void ChargerTrains(FabriqueAbstraite fabrique)
        {
            scenario = XDocument.Load("scenarioMetro.xml");
            foreach (XElement node in scenario.Descendants("lignes").Nodes())
            {
                if (node.Descendants("ligne") != null)
                {
                    if (node.Descendants("trains") != null)
                    {
                        foreach (XElement st in scenario.Descendants("trains").Nodes())
                        {
                            if (st.Descendants("train") != null)
                            {
                                PersonnageAbstrait train = fabrique.CreerPersonnage(st.Attribute("name").Value);

                                if (st.Descendants("depart") != null)
                                    AjouteTrain(train, st.Element("depart").Value);

                            }
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------------------
        private void AjouteZoneAbstraits(params ZoneAbstraite[] zoneAbstraitsArray)
        {
            ZoneAbstraitsList.AddRange(zoneAbstraitsArray);
        }
        //---------------------------------------------------------------------
        private void AjouteStationAbstraits(ZoneAbstraite station)
        {
            StationsList.Add(station);
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
        //------------------------------------------------------------------------------------------
        private void AjouteRail(FabriqueAbstraite fabrique, AccesAbstrait rail)
        {
            RailsList.Add(rail);
            AccesAbstrait accesInverse = fabrique.CreerAcces(rail.Fin, rail.Debut);
            RailsList.Add(accesInverse);
        }
        //-------------------------------------------------------------------------------------------
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
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public string SimulerMetro()
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            int flag = 0;
            string jsonoutput;

            foreach (PersonnageAbstrait unTrain in TrainsList)
            {
                foreach (AccesAbstrait acc in RailsList)
                {
                    if (RailsList.Count > 0)
                    {
                        if (acc.Debut.Nom == "Nation")
                        {
                            unTrain.passage = DateTime.Now;
                            for (int i = 0; i < RailsList.Count; i++)
                            {
                                if (flag == 1) unTrain.passage = unTrain.passage.AddMinutes(4);
                                else unTrain.passage = unTrain.passage.AddMinutes(2);
                                unTrain.nbPassager = rnd.Next(1, 100);
                                DeplacerPersonnage(unTrain, RailsList[i].Debut, RailsList[i].Fin);
                                //  sb.AppendFormat("{0} : {1} --> {2}, nb passager : {3}, heure de passage : {4}  \n", unTrain.Nom, RailsList[i].Debut.Nom,
                                //     RailsList[i].Fin.Nom, unTrain.nbPassager, unTrain.passage);
                                if (i != RailsList.Count)
                                    i++;
                                flag = 1;
                                jsonoutput = JsonConvert.SerializeObject(unTrain, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                                sb.Append(jsonoutput);
                            }
                            sb.Append("terminus, en attente de départ \n\n\n");
                        }
                        if (acc.Debut.Nom == "Mairie de Montreuil")
                        {
                            unTrain.passage = DateTime.Now;
                            for (int i = RailsList.Count - 1; i >= 0; i--)
                            {
                                unTrain.nbPassager = rnd.Next(1, 100);
                                if (flag == 1) unTrain.passage = unTrain.passage.AddMinutes(4);
                                else unTrain.passage = unTrain.passage.AddMinutes(2);
                                DeplacerPersonnage(unTrain, RailsList[i].Debut, RailsList[i].Fin);
                                //  sb.AppendFormat("{0} : {1} --> {2}, nb passager : {3}, heure de passage : {4} \n", unTrain.Nom, RailsList[i].Debut.Nom,
                                //   RailsList[i].Fin.Nom, unTrain.nbPassager, unTrain.passage);
                                if (i != 0)
                                    i--;
                                jsonoutput = JsonConvert.SerializeObject(unTrain, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                                sb.Append(jsonoutput);
                            }
                            sb.Append("terminus, en attente de départ \n\n\n");
                        }


                    }
                    else
                    {
                        sb.AppendFormat("{0} : au depot \n", unTrain.Nom);
                    }
                }
            }

            //RETOURNER JSON

            return sb.ToString();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        private void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite zoneAbstraiteCible,
            ZoneAbstraite zoneAbstraiteSource)
        {
            unPersonnage.Position = zoneAbstraiteCible;
            zoneAbstraiteSource.RetirePersonnage(unPersonnage);
            zoneAbstraiteCible.AjoutePersonnage(unPersonnage);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        public string Statistiques()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ZoneAbstraitsList.Count + " Zones");
            sb.AppendLine(AccesAbstraitsList.Count + " Accès");
            return sb.ToString();
        }


    }
}