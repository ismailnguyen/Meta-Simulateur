namespace LibMetier.Calculs
{
    public class CalculsCarburantVoiture : CalculCarburantAbstrait
    {
        public override int CarburantConsommé(int distanceParcourue, int quantitéInitial)
        {
            var carburantConsommé = distanceParcourue / 4;

            if (carburantConsommé > quantitéInitial) return 0;

            return quantitéInitial - carburantConsommé;
        }
    }
}
