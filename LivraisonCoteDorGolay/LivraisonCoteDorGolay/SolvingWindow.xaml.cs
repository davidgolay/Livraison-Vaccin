using LivraisonCoteDorGolay.customComponents;
using LogicProject;
using LogicProject.algorithms;
using LogicProject.algorithms.localResearchs;
using LogicProject.networks;
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
using System.Windows.Shapes;

namespace LivraisonCoteDorGolay
{
    /// <summary>
    /// Logique d'interaction pour SolvingWindow.xaml
    /// </summary>
    public partial class SolvingWindow : Window
    {
        private List<City> cities;
        private List<Solver> gloutonSolvers;
        private List<Solver> localResearchSolvers;

        public SolvingWindow(List<City> cities)
        {
            InitializeComponent();
            this.cities = new List<City>(cities);
            this.gloutonSolvers = new List<Solver>();
            this.localResearchSolvers = new List<Solver>();
            GloutonSolvers();
        }

        private void GloutonSolvers()
        {
            GraphicSolver procheVoisin = GraphicSolverFactory.Create("plusProcheVoisin", new List<City>(cities));
            procheVoisin.SolverGrid();
            gloutonGrid.Children.Add(procheVoisin);
            Grid.SetColumn(procheVoisin, 0);

            GraphicSolver procheVoisinAmeliore = GraphicSolverFactory.Create("plusProcheVoisinAméliore", new List<City>(cities));
            procheVoisinAmeliore.SolverGrid();
            gloutonGrid.Children.Add(procheVoisinAmeliore);
            Grid.SetColumn(procheVoisinAmeliore, 1);

            GraphicSolver insertionProche = GraphicSolverFactory.Create("insertionProche", new List<City>(cities));
            insertionProche.SolverGrid();
            gloutonGrid.Children.Add(insertionProche);
            Grid.SetColumn(insertionProche, 2);

        }
    }
}
