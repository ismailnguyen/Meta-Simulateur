namespace LibMetier.Calculs.Autoroute
{
    public abstract class CalculCarburantAbstrait
    {
        // Remove consummed fuel according with traveled distance
        public abstract int CarburantConsommé(int distanceParcourue, int quantitéInitial);
    }
}
