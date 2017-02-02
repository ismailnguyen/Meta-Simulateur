using LibAbstraite.Fabriques;
using LibAbstraite.GestionEnvironnement;
using System.Text;

namespace LibAbstraite.Simulateurs
{
    public abstract class SimulateurAbstrait
    {
        public FabriqueAbstraite Fabrique { get; set; }
        public EnvironnementAbstrait Environnement { get; set; }

        public abstract void ChargerEnvironnement();

        // By default launch 10 iteration of simulation
        public virtual string LancerSimulation()
        {
            return LancerSimulation(10);
        }

        public virtual string LancerSimulation(int iteration)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < iteration; i++)
            {
                stringBuilder.AppendLine(Environnement.Simuler());
            }

            return stringBuilder.ToString();
        }
    }
}
