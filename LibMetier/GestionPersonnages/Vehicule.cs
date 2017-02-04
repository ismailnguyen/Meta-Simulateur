using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObservations;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement.Autoroute;
using System.Collections.Generic;

namespace LibMetier.GestionPersonnages
{
    public abstract class Vehicule : PersonnageAbstrait, IObservable
    {
        public List<IObservateur> Observateurs { get; set; }

        // Litres
        public int Carburant
        {
            get { return Carburant; }
            set
            {
                if (value <= 0)
                {
                    NotifierObservateurs();
                }

                Carburant = value;
            }
        }

        protected Vehicule()
        {
            Carburant = 0;
        }

        protected Autoroute ProchaineAutorouteLibre(List<AccesAbstrait> accesList)
        {
            var autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];

            // Check if highway is not already full, else choose an other route
            while (autoroute.Capacité <= 0)
            {
                autoroute = (Autoroute) accesList[Hasard.Next(accesList.Count)];
            }

            return autoroute;
        }

        public abstract override string ToString();

        public void AjouterObservateur(IObservateur observateur)
        {
            Observateurs.Add(observateur);
        }

        public void Supprimer(IObservateur observateur)
        {
            Observateurs.Remove(observateur);
        }

        public void NotifierObservateurs()
        {
            foreach (var observateur in Observateurs)
            {
                observateur.Notifier(this);
            }
        }
    }
}
