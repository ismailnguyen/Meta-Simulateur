using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionEnvironnement.Metro
{
    public class Station : ZoneAbstraite
    {
        public int Id { get; set; }

        public Station(string unNom) : base(unNom)
        {
        }
    }
}
