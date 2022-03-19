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
        private List<GraphicSolver> graphicSolvers;
        public List<City> Cities { get => cities; set => cities = value; }
        public string FileNameUsed { get => fileNameUsed; set => fileNameUsed = value; }

        public SolvingWindow(List<City> cities, string fileNameUsed, List<GraphicSolver> graphicSolvers)
        {
            InitializeComponent();
            this.Cities = new List<City>(cities);
            this.FileNameUsed = fileNameUsed;
            this.graphicSolvers = graphicSolvers;
            InitGraphicSolvers();
        }


        private void InitGraphicSolvers()
        {
            int index = 0;
            foreach(GraphicSolver gs in this.graphicSolvers)
            {
                ColumnDefinition col1 = new ColumnDefinition();
                mainGrid.ColumnDefinitions.Add(col1);
                mainGrid.Children.Add(gs);
                Grid.SetColumn(gs, index);
                gs.SolverGrid();
                index++;
            }

            this.Width = index * 400;

        }


    }
}
