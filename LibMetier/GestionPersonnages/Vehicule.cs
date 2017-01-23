using LibAbstraite.GestionPersonnages;

namespace LibMetier.GestionPersonnages
{
    public abstract class Vehicule : PersonnageAbstrait
    {
        public int Carburant { get; set; }

        protected Vehicule()
        {
            Carburant = 0;
        }
    }
}
