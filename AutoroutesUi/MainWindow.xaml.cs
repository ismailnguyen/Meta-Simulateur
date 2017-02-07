using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoroutesUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initialiserVilles();
        }

        private void initialiserVilles()
        {
            initialiserParis();
            initialiserLyon();
            initialiserBordeaux();
            initialiserToulouse();
            initialiserNice();
            initialiserMontpellier();
            initialiserStrasboug();
            initialiserMarseille();
            initialiserLille();
        }

        private void initialiserMarseille()
        {
            ajouterTexte(0, 13, 16);
        }

        private void initialiserStrasboug()
        {
            ajouterTexte(0, 16, 6);
        }

        private void initialiserMontpellier()
        {
            ajouterTexte(0, 11, 15);
        }

        private void initialiserNice()
        {
            ajouterTexte(0, 16, 15);
        }

        private void initialiserToulouse()
        {
            ajouterTexte(0, 8, 15);
        }

        private void initialiserBordeaux()
        {
            ajouterTexte(0, 5, 13);
        }

        private void initialiserLyon()
        {
            ajouterTexte(0, 12, 11);
        }

        private void initialiserParis()
        {
            ajouterTexte(0, 9, 5);
        }

        private void initialiserLille()
        {
            ajouterTexte(0, 9, 2);
        }

        private void ajouterTexte(int valeur, int x, int y)
        {
            var texte = new TextBlock();
            Grid.SetColumn(texte, x);
            Grid.SetRow(texte, y);
            texte.Background = Brushes.White;
            texte.Text = valeur.ToString();

            grid.Children.Add(texte);
        }
    }
}
