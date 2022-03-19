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
                List<string> lines = File.ReadLines(openFileDialog.FileName).ToList();
                CityExtractorTxt extractor = new CityExtractorTxt();
                this._cities = extractor.ExtractCitiesFromLines(lines);
                filePreview.Text = File.ReadAllText(openFileDialog.FileName);
                GoSolvingWindow(openFileDialog.FileName);
            }
        }

        private void GoSolvingWindow(string fullPath)
        {
            if (_cities != null) {
                try
                {
                    fullPath = System.IO.Path.GetFullPath(fullPath).TrimEnd(System.IO.Path.DirectorySeparatorChar);
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(fullPath);


                    SolvingWindow second = new SolvingWindow(_cities, fileName);
                    second.Title = " City Set " + fullPath;
                    second.Show();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void InitFields()
        {
            filePreview.Text = "You must add a city set .txt file";
        }

    }
}
