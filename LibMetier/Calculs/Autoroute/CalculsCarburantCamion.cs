namespace LibMetier.Calculs.Autoroute
{
    public class CalculsCarburantCamion : CalculCarburantAbstrait
    {
        public override int CarburantConsommé(int distanceParcourue, int quantitéInitial)
        {
            var carburantConsommé = distanceParcourue / 5;

            if (carburantConsommé > quantitéInitial) return 0;

            return quantitéInitial - carburantConsommé;
        }
    }
}
