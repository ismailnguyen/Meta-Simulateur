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
        protected List<IObservateur> Observateurs { get; set; } = new List<IObservateur>();

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
                    NotifierObservateurs();
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
            if (Observateurs.Contains(observateur))
                return;

            Observateurs.Add(observateur);
        }

        public void Supprimer(IObservateur observateur)
        {
            if (!Observateurs.Contains(observateur))
                return;

            Observateurs.Remove(observateur);
        }

        public void NotifierObservateurs()
        {
            if (Observateurs == null)
                return;

            foreach (var observateur in Observateurs)
            {
                observateur.Notifier(this);
            }
        }
    }
}
