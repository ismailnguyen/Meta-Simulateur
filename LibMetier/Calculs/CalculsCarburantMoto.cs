namespace LibMetier.Calculs
{
    public class CalculsCarburantMoto: CalculCarburantAbstrait
    {
        public override int CarburantConsommé(int distanceParcourue, int quantitéInitial)
        {
            var carburantConsommé = distanceParcourue / 3;

            if (carburantConsommé > quantitéInitial) return 0;

            return quantitéInitial - carburantConsommé;
        }
    }
}
