namespace LibAbstraite.GestionEnvironnement
{
    public abstract class AccesAbstrait
    {
        public ZoneAbstraite Debut { get; set; }
        public ZoneAbstraite Fin { get; set; }

        protected AccesAbstrait(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            Debut = debut;
            Debut.AjouteAcces(this);
            Fin = fin;
        }
    }
}
