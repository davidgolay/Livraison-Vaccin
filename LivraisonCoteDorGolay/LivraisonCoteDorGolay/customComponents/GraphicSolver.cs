using LogicProject.algorithms;
using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LivraisonCoteDorGolay
{
    public abstract class GraphicSolver : Grid
    {
        private List<City> citiesToSolve;
        private List<City> untouchedCities;
        private Tour bestTourComputed;
        private Tour lastTourComputed;
        private SolvingWindow parent;

        private string xName;
        private string solutionName;
        private string additiveDescription;

        private Label lName;
        private Label lAdditiveDescription;
        private Button solveButton;
        private TextBox solutionBox;
        private TextBox costBox;

        private FontFamily fontFamily = new FontFamily("Microsoft JhengHei");
        private ComboBox inputTourOption;
        private string[] presolvingItems = new string[] { "basique", "après PPV", "après PPV amélioré", "après Insertion Proche" };


        #region propreties
        public string XName { get => xName; set => xName = value; }
        public string NameSolution { get => solutionName; set => solutionName = value; }
        public string AdditiveDescription { get => additiveDescription; set => additiveDescription = value; }


        public Label LName { get => lName; set => lName = value; }
        public Label LAdditiveDescription { get => lAdditiveDescription; set => lAdditiveDescription = value; }
        public Button BtnSolveButton { get => solveButton; set => solveButton = value; }
        public List<City> CitiesToSolve { get => citiesToSolve; set => citiesToSolve = value; }
        public TextBox SolutionBox { get => solutionBox; set => solutionBox = value; }
        public TextBox CostBox { get => costBox; set => costBox = value; }
        public Tour BestTourComputed { get => bestTourComputed; set => bestTourComputed = value; }
        public Tour LastTourComputed1 { get => lastTourComputed; set => lastTourComputed = value; }

        #endregion

        public GraphicSolver(SolvingWindow sw)
        {
            this.citiesToSolve = new List<City>(sw.Cities);
            this.untouchedCities = new List<City>(sw.Cities);
            this.parent = sw;
            InitComboBox();
        }

        protected abstract Tour OnSolveAction();

        private void Button_Click(object sender, EventArgs e)
        {
            lastTourComputed = OnSolveAction();
            UpdateTour();
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            CityMapper.ShuffleCities(this.CitiesToSolve);
            lastTourComputed = OnSolveAction();
            UpdateTour();
        }

        private void BringBackBestTour_Click(object sender, EventArgs e)
        {
            citiesToSolve = bestTourComputed.Cities;
            UpdateTour();
        }

        private void UpdateTour()
        {
            SolutionBox.Text = lastTourComputed.DisplayTour();
            CostBox.Text = Math.Round(lastTourComputed.Cost, 4).ToString();
        }


        /// <summary>
        /// Generate the main component
        /// </summary>
        public void SolverGrid()
        {
            this.ShowGridLines = false;

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            RowDefinition rowDef5 = new RowDefinition();
            rowDef4.Height = new GridLength(5.0, GridUnitType.Star);
            this.RowDefinitions.Add(rowDef1);
            this.RowDefinitions.Add(rowDef2);
            this.RowDefinitions.Add(rowDef3);
            this.RowDefinitions.Add(rowDef4);
            this.RowDefinitions.Add(rowDef5);

            //Content generation
            Grid gTitle = GenerateTitleBox();
            GenerateSolutionBox();

            Grid gControls = GenerateControlsGrid();
            this.Children.Add(gControls);

            Grid costGrid = GenerateCostGrid();
            this.Children.Add(costGrid);
            GenerateSolverButton();

            Grid.SetRow(gTitle, 0);
            Grid.SetRow(gControls, 1);
            Grid.SetRow(solveButton, 2);
            Grid.SetRow(solutionBox, 3);
            Grid.SetRow(costGrid, 4);

            //Margin
            float margin = 5;
            this.Margin = new Thickness(margin, 0, margin, 0);
        }

        private Label GenerateLabel(string value)
        {
            Label l = new Label();
            l.FontFamily = fontFamily;
            l.Content = value;
            return l;
        }

        private Grid GenerateTitleBox()
        {
            lName = GenerateLabel(NameSolution);
            lAdditiveDescription = GenerateLabel(AdditiveDescription);

            //Seeting weight and style
            lName.FontSize = 14;
            lAdditiveDescription.FontSize = 12;
            lName.SetValue(Label.FontWeightProperty, FontWeights.Bold);
            lAdditiveDescription.SetValue(Label.FontStyleProperty, FontStyles.Italic);

            //Setting alignement
            lName.VerticalAlignment = VerticalAlignment.Top;
            lAdditiveDescription.VerticalAlignment = VerticalAlignment.Bottom;

            Grid gTitle = new Grid();
            gTitle.MinHeight = 40;
            RowDefinition gTitlerowDef1 = new RowDefinition();
            RowDefinition gTitlerowDef2 = new RowDefinition();
            gTitle.RowDefinitions.Add(gTitlerowDef1);
            gTitle.Children.Add(this.lName);
            Grid.SetRow(this.lName, 0);

            if (additiveDescription.Length > 0)
            {
                gTitle.RowDefinitions.Add(gTitlerowDef2);
                gTitle.Children.Add(this.lAdditiveDescription);
                Grid.SetRow(this.lAdditiveDescription, 1);
            }

            this.Children.Add(gTitle);
            return gTitle;
        }

        private Grid GenerateControlsGrid()
        {
            //Cost Label
            Label l = new Label();
            l.Content = "Liste " + parent.FileNameUsed;
            l.VerticalAlignment = VerticalAlignment.Center;
            l.HorizontalAlignment = HorizontalAlignment.Right;
            l.FontSize = 12;
            //l.SetValue(Label.FontWeightProperty, FontWeights.Bold);

            Button randomizeBtn = RandomizeButton();

            Button bringBackBtn = BringBackBestButton();


            // Define the Rows
            Grid g = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            //col2.Width = new GridLength(2.0, GridUnitType.Star);
            g.ColumnDefinitions.Add(col1);
            g.ColumnDefinitions.Add(col2);
            g.ColumnDefinitions.Add(col3);
            //g.ColumnDefinitions.Add(col4);

            //Adding children to grid
            g.Children.Add(l);
            g.Children.Add(inputTourOption);
            g.Children.Add(randomizeBtn);
            //g.Children.Add(bringBackBtn);

            Grid.SetColumn(l, 0);
            Grid.SetColumn(inputTourOption, 1);
            Grid.SetColumn(randomizeBtn, 2);
            //Grid.SetColumn(bringBackBtn, 3);


            //Grid Styling
            float margin = 5;
            g.Margin = new Thickness(0, margin, 0, margin);

            return g;
        }

        private void InitComboBox()
        {
            this.inputTourOption = new ComboBox();
            this.inputTourOption.VerticalAlignment = VerticalAlignment.Stretch;
            this.inputTourOption.VerticalContentAlignment = VerticalAlignment.Center;
            foreach (string item in presolvingItems)
            {
                inputTourOption.Items.Add(item);
            }

            inputTourOption.SelectedIndex = 0;
            inputTourOption.SelectionChanged += new SelectionChangedEventHandler(OnTourInputChanged);
        }

        private void updateSolvingButtonContent(string extension)
        {
            solveButton.Content = "Résoudre " + this.solutionName + " (" + extension + ")";
        }

        private void OnTourInputChanged(object sender, SelectionChangedEventArgs e)
        {
            string itemSelected = this.inputTourOption.SelectedItem.ToString();

            if(itemSelected == presolvingItems[0])
            {
                citiesToSolve = untouchedCities;
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[1])
            {
                citiesToSolve = untouchedCities;
                Solver snn = new SolverNearestNeighbor(CitiesToSolve);
                citiesToSolve = snn.Solve(citiesToSolve.ElementAt(0)).Cities;
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[2])
            {
                citiesToSolve = untouchedCities;
                Solver snna = new SolverNearestNeighborAdvanced(CitiesToSolve);
                citiesToSolve = snna.Solve(citiesToSolve.ElementAt(0)).Cities;
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[3])
            {
                citiesToSolve = untouchedCities;
                Solver snna = new SolverNearInsertion(CitiesToSolve);
                citiesToSolve = snna.Solve(citiesToSolve.ElementAt(0)).Cities;
                updateSolvingButtonContent(itemSelected);
            }
        }

        private Button ButtonBasis()
        {
            Button btn = new Button();
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1F2930"));
            btn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            btn.FontSize = 14;
            btn.Cursor = Cursors.Hand;
            btn.SetValue(Label.FontWeightProperty, FontWeights.Bold);
            btn.Padding = new Thickness(5);
            return btn;
        }


        private Button RandomizeButton()
        {
            Button b = ButtonBasis();
            b.Content = "Mélanger";
            b.Click += new RoutedEventHandler(Randomize_Click);
            return b;
        }

        private Button BringBackBestButton()
        {
            Button b = ButtonBasis();
            b.Content = "Meilleure solution calculée";
            b.Click += new RoutedEventHandler(BringBackBestTour_Click);
            return b;
        }

        private void GenerateSolutionBox()
        {
            this.solutionBox = new TextBox();
            solutionBox.FontFamily = fontFamily;
            solutionBox.Text = "Not Computed";
            solutionBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            solutionBox.VerticalContentAlignment = VerticalAlignment.Center;
            float margin = 5;
            solutionBox.Margin = new Thickness(0, margin, 0, margin);
            solutionBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            this.Children.Add(solutionBox);
        }

        private Grid GenerateCostGrid()
        {
            //Cost Label
            Label lCost = new Label();
            lCost.Content = "Cost :";
            lCost.VerticalAlignment = VerticalAlignment.Center;
            lCost.HorizontalAlignment = HorizontalAlignment.Right;
            lCost.FontSize = 16;
            lCost.SetValue(Label.FontWeightProperty, FontWeights.Bold);

            //Cost box diplayer
            this.costBox = new TextBox();
            this.costBox.Text = "Not computed";
            this.costBox.FontFamily = fontFamily;
            lCost.FontSize = 18;
            this.costBox.Padding = new Thickness(0, 0, 5, 0);
            this.costBox.VerticalContentAlignment = VerticalAlignment.Center;
            this.costBox.HorizontalContentAlignment = HorizontalAlignment.Right;


            // Define the Rows
            Grid g = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(2.0, GridUnitType.Star);
            g.ColumnDefinitions.Add(col1);
            g.ColumnDefinitions.Add(col2);

            //Adding children to grid
            g.Children.Add(lCost);
            g.Children.Add(this.costBox);
            Grid.SetColumn(lCost, 0);
            Grid.SetColumn(this.costBox, 1);

            //Grid Styling
            float margin = 5;
            g.Margin = new Thickness(0, margin, 0, margin);

            return g;
        }

        private void GenerateSolverButton()
        {
            this.solveButton = ButtonBasis();
            this.solveButton.Click += new RoutedEventHandler(Button_Click);
            updateSolvingButtonContent(inputTourOption.SelectedItem.ToString());

            this.Children.Add(this.solveButton);
        }

        protected void AlignSolutionBox()
        {
            solutionBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            solutionBox.VerticalContentAlignment = VerticalAlignment.Top;
        }

        protected void UpdateBestTourComputed()
        {
            if(lastTourComputed.Cost < bestTourComputed.Cost)
            {
                bestTourComputed = lastTourComputed;
            }
        }
    }
}
