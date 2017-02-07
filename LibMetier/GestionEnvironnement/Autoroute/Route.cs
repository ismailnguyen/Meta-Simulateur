using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionEnvironnement.Autoroute
{
    public class Route : AccesAbstrait
    {
        // Kilometers
        public int Distance { get; set; }

        // Capacity
        public int Capacité { get; set; }

        public Route(ZoneAbstraite debut, ZoneAbstraite fin) : base(debut, fin)
        {
            Distance = 100;
            Capacité = 100;
        }
    }
}
