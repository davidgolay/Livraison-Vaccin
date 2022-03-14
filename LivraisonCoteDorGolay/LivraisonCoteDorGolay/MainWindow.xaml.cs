using LivraisonCoteDor.network;
using Logic.generators;
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
                filePreview.Text = File.ReadAllText(openFileDialog.FileName);
                List<string> lines = File.ReadLines(openFileDialog.FileName).ToList();
                CityExtractorTxt extractor = new CityExtractorTxt();
                extractor.ExtractCitiesFromLines(lines);
            }

        }

        private void InitFields()
        {
            filePreview.Text = "Aucun fichier texte n'a été renseigné";
        }
    }
}
