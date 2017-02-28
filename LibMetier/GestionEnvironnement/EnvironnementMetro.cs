using LibAbstraite.GestionEnvironnement;
using System.Text;
using LibAbstraite.GestionPersonnages;
using LibAbstraite.Fabriques;
using Newtonsoft.Json;
using System;
using LibMetier.GestionPersonnages.Metro;
using LibMetier.GestionEnvironnement.Metro;

namespace LibMetier.GestionEnvironnement
{
    public class EnvironnementMetro : EnvironnementAbstrait
    {
        public override string Simuler()
        {
            var text = new StringBuilder();
            Random rnd = new Random();
            int flag = 0;
            string jsonoutput;

             foreach(Train unTrain in PersonnagesList)
              {  
                foreach (Rails rail in AccesAbstraitsList)
                {
                    if (AccesAbstraitsList.Count > 0)
                    {
                        if (rail.Debut.Nom == "Nation")
                        {
                            unTrain.Passage = DateTime.Now;
                            for (int i = 0; i < AccesAbstraitsList.Count; i++)
                            {
                                if(flag==1) unTrain.Passage = unTrain.Passage.AddMinutes(4);
                                else unTrain.Passage = unTrain.Passage.AddMinutes(2);
                                unTrain.nbPassager = rnd.Next(1, 100);
                                DeplacerPersonnage(unTrain, AccesAbstraitsList[i].Debut, AccesAbstraitsList[i].Fin);
                                text.AppendFormat("{0} : {1} --> {2}, nb passager : {3}, heure de passage : {4}  \n", unTrain.Nom, AccesAbstraitsList[i].Debut.Nom,
                                AccesAbstraitsList[i].Fin.Nom, unTrain.nbPassager, unTrain.Passage);
                                if(i != AccesAbstraitsList.Count)
                                 i++;
                                flag = 1;
                                jsonoutput = JsonConvert.SerializeObject(unTrain,new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                                //text.Append(jsonoutput);
                            }
                            text.Append("terminus, en attente de départ \n\n\n");
                        }
                        if (rail.Debut.Nom == "Mairie de Montreuil")
                        {
                            unTrain.Passage = DateTime.Now;
                            for (int i = AccesAbstraitsList.Count -1; i >= 0; i--)
                            {
                                unTrain.nbPassager = rnd.Next(1, 100);
                                if (flag == 1) unTrain.Passage = unTrain.Passage.AddMinutes(4);
                                else unTrain.Passage = unTrain.Passage.AddMinutes(2);
                                DeplacerPersonnage(unTrain, AccesAbstraitsList[i].Debut, AccesAbstraitsList[i].Fin);
                                text.AppendFormat("{0} : {1} --> {2}, nb passager : {3}, heure de passage : {4} \n", unTrain.Nom, AccesAbstraitsList[i].Debut.Nom,
                                AccesAbstraitsList[i].Fin.Nom, unTrain.nbPassager, unTrain.Passage);
                                if (i != 0)
                                    i--;
                                jsonoutput = JsonConvert.SerializeObject(unTrain, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                                //text.Append(jsonoutput);
                            }
                            text.Append("terminus, en attente de départ \n\n\n");
                        }


                    }
                    else
                    {
                        text.AppendFormat("{0} : au depot \n", unTrain.Nom);
                    }
                }
              }
            
            //RETOURNER JSON
            
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
