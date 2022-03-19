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
        private string fileNameUsed;
        private List<Solver> gloutonSolvers;
        private List<Solver> localResearchSolvers;
        public List<City> Cities { get => cities; set => cities = value; }
        public string FileNameUsed { get => fileNameUsed; set => fileNameUsed = value; }

        public SolvingWindow(List<City> cities, string fileNameUsed)
        {
            InitializeComponent();
            this.Cities = new List<City>(cities);
            this.FileNameUsed = fileNameUsed;
            this.gloutonSolvers = new List<Solver>();
            this.localResearchSolvers = new List<Solver>();
            GloutonSolvers();
        }


        private void GloutonSolvers()
        {
            GraphicSolver procheVoisin = GraphicSolverFactory.Create("plusProcheVoisin", this);
            procheVoisin.SolverGrid();
            gloutonGrid.Children.Add(procheVoisin);
            Grid.SetColumn(procheVoisin, 0);

            GraphicSolver procheVoisinAmeliore = GraphicSolverFactory.Create("plusProcheVoisinAméliore", this);
            procheVoisinAmeliore.SolverGrid();
            gloutonGrid.Children.Add(procheVoisinAmeliore);
            Grid.SetColumn(procheVoisinAmeliore, 1);

            GraphicSolver insertionProche = GraphicSolverFactory.Create("insertionProche", this);
            insertionProche.SolverGrid();
            gloutonGrid.Children.Add(insertionProche);
            Grid.SetColumn(insertionProche, 2);
        }

        private void LocalSearchSolvers()
        {
            GraphicSolver localSearchFF = GraphicSolverFactory.Create("rechercheLocalPremierDabord", this);
            localSearchFF.SolverGrid();
            localSearchGrid.Children.Add(localSearchFF);
            Grid.SetColumn(localSearchFF, 0);
        }
    }
}
