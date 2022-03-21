using LivraisonCoteDorGolay.customComponents;
using Logic.extractors;
using LogicProject.networks;
using LogicProject.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LivraisonCoteDorGolay
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<City> _cities = new List<City>();
        private string fileName;


        public List<City> Cities { get => _cities; set => _cities = value; }
        public string FileName { get => fileName; set => fileName = value; }

        public MainWindow()
        {
            InitializeComponent();
            InitFields();
        }

        private void OnAddFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    List<string> lines = File.ReadLines(openFileDialog.FileName).ToList();
                    CityExtractorTxt extractor = new CityExtractorTxt();
                    this.Cities = extractor.ExtractCitiesFromLines(lines);
                    filePreview.Text = File.ReadAllText(openFileDialog.FileName);
                    string fullPath = System.IO.Path.GetFullPath(openFileDialog.FileName).TrimEnd(System.IO.Path.DirectorySeparatorChar);
                    this.fileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
                    btnGlouton.IsEnabled = true;
                    btnLocalSearch.IsEnabled = true;

                } catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }


            }
        }

        private void InitFields()
        {
            filePreview.Text = "Vous devez importer un fichier .txt";
        }

        private void GoGlouton(object sender, RoutedEventArgs e)
        {
            if (Cities != null)
            {
                try
                {
                    SolvingWindow second = new SolvingWindow(Cities, fileName, GloutonSolvers());
                    second.Title = " Liste de ville " + fileName;
                    second.Show();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void GoLocalSearch(object sender, RoutedEventArgs e)
        {
            if (Cities != null)
            {
                try
                {
                    SolvingWindow second = new SolvingWindow(Cities, fileName, LocalSearchSolvers());
                    second.Title = " Liste de ville " + fileName;
                    second.Show();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private List<GraphicSolver> GloutonSolvers()
        {
            GraphicSolver procheVoisin = GraphicSolverFactory.Create("plusProcheVoisin", this);
            GraphicSolver procheVoisinAmeliore = GraphicSolverFactory.Create("plusProcheVoisinAméliore", this);
            GraphicSolver insertionProche = GraphicSolverFactory.Create("insertionProche", this);

            List<GraphicSolver> list = new List<GraphicSolver>();
            list.Add(procheVoisin);
            list.Add(procheVoisinAmeliore);
            list.Add(insertionProche);

            return list;
        }

        private List<GraphicSolver> LocalSearchSolvers()
        {
            GraphicSolver PremierDabord = GraphicSolverFactory.Create("premierDabord", this);
            GraphicSolver MeilleurSuccesseur = GraphicSolverFactory.Create("meilleurSuccesseur", this);
            GraphicSolver EchangeQlcPremierDabord = GraphicSolverFactory.Create("quelconquePremierDabord", this);
            GraphicSolver EchangeQlcMeilleurDabord = GraphicSolverFactory.Create("quelconqueMeilleurDabord", this);
            List<GraphicSolver> list = new List<GraphicSolver>();
            list.Add(PremierDabord);
            list.Add(MeilleurSuccesseur);
            list.Add(EchangeQlcPremierDabord);
            list.Add(EchangeQlcMeilleurDabord);
            return list;
        }
    }
}
