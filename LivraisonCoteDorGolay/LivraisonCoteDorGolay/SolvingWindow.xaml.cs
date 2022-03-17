using LogicProject.algorithmes;
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
        public SolvingWindow(List<City> cities)
        {
            InitializeComponent();
            this.cities = new List<City>(cities);
        }

        private void OnNearestNeighborSolve(object sender, RoutedEventArgs e)
        {
            List<City> citiesToSolve = new List<City>(cities);
            TourSolver solver = new TourSolverNearestNeighbor(citiesToSolve);
            Tour solvedTour = solver.Solve(citiesToSolve.ElementAt(0));
            solutionText.Text = solvedTour.DisplayTour();
            costNearestNeighbor.Text = Math.Round(solvedTour.Cost, 4).ToString();
        }

        //private void OnNearestNeighborAdvancedSolve(object sender, RoutedEventArgs e)
        //{
        //    List<City> citiesToSolve = new List<City>(cities);
        //    TourSolver solver = new TourSolverNearestNeighborAdvanced(citiesToSolve);
        //    Tour solvedTour = solver.Solve(citiesToSolve.ElementAt(0));
        //    solutionText.Text = solvedTour.DisplayTour();
        //    costNearestNeighborAdvanced.Text = Math.Round(solvedTour.Cost, 4).ToString();
        //}
    }
}
