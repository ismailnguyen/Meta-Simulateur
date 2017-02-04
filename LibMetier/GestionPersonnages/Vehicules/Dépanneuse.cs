using LibAbstraite.GestionObservations;

namespace LibMetier.GestionPersonnages.Vehicules
{
    public class Dépanneuse : IObservateur
    {
        // Dépanneuse remove car from map
        public void Notifier(IObservable observable)
        {
            ((Vehicule)observable).Position = null;
        }

        public override string ToString()
        {
            return "Dépanneuse";
        }
    }
}
