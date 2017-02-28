using LibAbstraite.GestionEnvironnement;
using LibAbstraite.Simulateurs;
using LibMetier.Simulateurs;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutoroutesUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimulateurAbstrait simulateur { get; set; }
        IDictionary<string, FrameworkElement> villes = new Dictionary<string, FrameworkElement>();

        public MainWindow()
        {
            InitializeComponent();

            initialiserVilles();

            initialiserSimulateur();
        }

        private void initialiserSimulateur()
        {
            simulateur = new SimulateurAutoroutes("scenarioAutoroutes.xml");

            simulateur.ChargerEnvironnement();

            actualiserCarte(simulateur.Environnement.ZoneAbstraitsList);
        }

        private void lancerSimulation()
        {
            /*for (int i=0; i<5; i++)
            {*/
                simulateur.LancerSimulation();
                var statistiquesSimulation = simulateur.Statistiques();

                actualiserCarte(statistiquesSimulation.ZoneAbstraitsList);

                /*Thread.Sleep(2000);
            }*/
        }

        private void actualiserCarte(List<ZoneAbstraite> zones)
        {
            foreach (var ville in zones)
            {
                var champ = (TextBlock)villes[ville.Nom];
                champ.Text = ville.PersonnagesList.Count.ToString();
            }
        }

        private void initialiserVilles()
        {
            initialiserParis();
            initialiserLyon();
            initialiserBordeaux();
            initialiserToulouse();
            initialiserNice();
            initialiserMontpellier();
            initialiserStrasbourg();
            initialiserMarseille();
            initialiserLille();
        }

        private void initialiserMarseille()
        {
            ajouterTexte("Marseille", 0, 13, 16);
        }

        private void initialiserStrasbourg()
        {
            ajouterTexte("Strasbourg", 0, 16, 6);
        }

        private void initialiserMontpellier()
        {
            ajouterTexte("Montpellier", 0, 11, 15);
        }

        private void initialiserNice()
        {
            ajouterTexte("Nice", 0, 16, 15);
        }

        private void initialiserToulouse()
        {
            ajouterTexte("Toulouse", 0, 8, 15);
        }

        private void initialiserBordeaux()
        {
            ajouterTexte("Bordeaux", 0, 5, 13);
        }

        private void initialiserLyon()
        {
            ajouterTexte("Lyon", 0, 12, 11);
        }

        private void initialiserParis()
        {
            ajouterTexte("Paris", 0, 9, 5);
        }

        private void initialiserLille()
        {
            ajouterTexte("Lille", 0, 9, 2);
        }

        private void ajouterTexte(string nomn, int valeur, int x, int y)
        {
            var champ = new TextBlock();
            Grid.SetColumn(champ, x);
            Grid.SetRow(champ, y);
            champ.Background = Brushes.White;
            champ.Text = valeur.ToString();

            grid.Children.Add(champ);

            villes.Add(nomn, champ);
        }

        private void buttonDémarrer_Click(object sender, RoutedEventArgs e)
        {
            lancerSimulation();
        }
    }
}
