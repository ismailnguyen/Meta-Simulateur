using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObservations;
using LibAbstraite.GestionPersonnages;
using LibMetier.Calculs;
using LibMetier.GestionEnvironnement.Autoroute;
using System.Collections.Generic;

namespace LibMetier.GestionPersonnages
{
    public abstract class Vehicule : PersonnageAbstrait, IObservable
    {
        protected IObservateur Observateur { get; set; }

        public CalculCarburantAbstrait CalculCarburant { get; set; }

        // Litres
        private int carburant;
        public int Carburant
        {
            get { return carburant; }
            set
            {
                if (value <= 0)
                {
                    NotifierObservateur();
                }

                carburant = value;
            }
        }

        protected Vehicule()
        {
            carburant = 0;
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
            Observateur = observateur;
        }

        public void SupprimerObservateur(IObservateur observateur)
        {
            Observateur = null;
        }

        public void NotifierObservateur()
        {
            if (Observateur == null)
                return;

            Observateur.Notifier(this);
        }
    }
}
