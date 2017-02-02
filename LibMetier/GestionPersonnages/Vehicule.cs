using LibAbstraite.GestionPersonnages;

namespace LibMetier.GestionPersonnages
{
    public abstract class Vehicule : PersonnageAbstrait
    {
        // Litres
        public int Carburant { get; set; }

        protected Vehicule()
        {
            Carburant = 0;
        }
    }
}
