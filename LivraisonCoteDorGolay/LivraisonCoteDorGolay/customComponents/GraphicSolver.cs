using LogicProject.algorithms;
using LogicProject.algorithms.localResearchs;
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
        private MainWindow parent;

        private string xName;
        private string solutionName;
        private string additiveDescription;

        private Label lName;
        private Label lAdditiveDescription;
        private Button solveButton;
        private TextBox outputBox;
        private TextBox inputBox;
        private TextBox costBox;

        private FontFamily fontFamily = new FontFamily("Microsoft JhengHei");
        private ComboBox inputTourOption;
        private string[] presolvingItems = new string[] { "basique", "après PPV", "après PPV amélioré", "après Insertion Proche", "après échange succ. 1er d'abord", "après échange succ. meilleur d'abord" };


        #region propreties
        public string XName { get => xName; set => xName = value; }
        public string NameSolution { get => solutionName; set => solutionName = value; }
        public string AdditiveDescription { get => additiveDescription; set => additiveDescription = value; }


        public Label LName { get => lName; set => lName = value; }
        public Label LAdditiveDescription { get => lAdditiveDescription; set => lAdditiveDescription = value; }
        public Button BtnSolveButton { get => solveButton; set => solveButton = value; }
        public List<City> CitiesToSolve { get => citiesToSolve; set => citiesToSolve = value; }
        public TextBox OutputBox { get => outputBox; set => outputBox = value; }
        public TextBox InputBox { get => inputBox; set => inputBox = value; }
        public TextBox CostBox { get => costBox; set => costBox = value; }
        public Tour BestTourComputed { get => bestTourComputed; set => bestTourComputed = value; }
        public Tour LastTourComputed1 { get => lastTourComputed; set => lastTourComputed = value; }

        #endregion

        public GraphicSolver(MainWindow parentController)
        {
            this.citiesToSolve = new List<City>(parentController.Cities);
            this.untouchedCities = new List<City>(parentController.Cities);
            this.parent = parentController;
            InitComboBox(); 
        }

        protected abstract Tour OnSolveAction();

        private void Button_Click(object sender, EventArgs e)
        {
            lastTourComputed = OnSolveAction();
            UpdateSolution();
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            CityMapper.ShuffleCities(this.CitiesToSolve);
            UpdateInput();
        }

        private void BringBackBestTour_Click(object sender, EventArgs e)
        {
            citiesToSolve = bestTourComputed.Cities;
            UpdateSolution();
        }

        private void UpdateInput()
        {
            Tour t = new Tour(CitiesToSolve);
            inputBox.Text = t.DisplayTour();
        }

        private void UpdateSolution()
        {
            outputBox.Text = lastTourComputed.DisplayTour();
            CostBox.Text = Math.Round(lastTourComputed.Cost, 4).ToString();
        }


        /// <summary>
        /// Generate the main component
        /// </summary>
        public void SolverGrid()
        {
            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            rowDef3.Height = new GridLength(8.0, GridUnitType.Star);
            this.RowDefinitions.Add(rowDef1);
            this.RowDefinitions.Add(rowDef2);
            this.RowDefinitions.Add(rowDef3);
            this.RowDefinitions.Add(rowDef4);

            //Content generation
            Grid gTitle = GenerateTitleBox();

            Grid gControls = GenerateControlsGrid();
            this.Children.Add(gControls);

            Grid costGrid = GenerateCostGrid();
            this.Children.Add(costGrid);

            Grid solutionGrid = GenerateSolutionBox();
            this.Children.Add(solutionGrid);

            Grid.SetRow(gTitle, 0);
            Grid.SetRow(gControls, 1);
            Grid.SetRow(solutionGrid, 2);
            Grid.SetRow(costGrid, 3);

            //Margin and styles
            float margin = 5;
            this.Margin = new Thickness(margin, margin, margin, margin);
            this.ShowGridLines = false;
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFADADAD"));

            UpdateInput();
        }

        private Label GenerateLabel(string value)
        {
            Label l = new Label();
            l.FontFamily = fontFamily;
            l.SetValue(Label.FontWeightProperty, FontWeights.Bold);
            l.Content = value;
            return l;
        }

        private Grid GenerateTitleBox()
        {
            lName = GenerateLabel("Methode de résolution " + NameSolution);
            lName.FontSize = 18;
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
            TextBlock tb = new TextBlock();
            tb.Text = "A partir de " + parent.FileName;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Right;
            tb.FontSize = 12;
            tb.Padding = new Thickness(0, 0, 5, 0);
            tb.TextWrapping = TextWrapping.Wrap;
            tb.SetValue(Label.FontWeightProperty, FontWeights.Bold);
            tb.Margin = new Thickness(0, 0, 5, 0);

            // Define the Rows
            Grid g = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(2.0, GridUnitType.Star);
            g.ColumnDefinitions.Add(col1);
            g.ColumnDefinitions.Add(col2);
            //g.ColumnDefinitions.Add(col4);

            //Adding children to grid
            g.Children.Add(tb);
            g.Children.Add(inputTourOption);

            Grid.SetColumn(tb, 0);
            Grid.SetColumn(inputTourOption, 1);

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
                UpdateInput();
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[1])
            {
                citiesToSolve = untouchedCities;
                Solver snn = new SolverNearestNeighbor(CitiesToSolve);
                citiesToSolve = snn.Solve(citiesToSolve.ElementAt(0)).Cities;
                UpdateInput();
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[2])
            {
                citiesToSolve = untouchedCities;
                Solver snna = new SolverNearestNeighborAdvanced(CitiesToSolve);
                citiesToSolve = snna.Solve(citiesToSolve.ElementAt(0)).Cities;
                UpdateInput();
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[3])
            {
                citiesToSolve = untouchedCities;
                Solver snna = new SolverNearInsertion(CitiesToSolve);
                citiesToSolve = snna.Solve(citiesToSolve.ElementAt(0)).Cities;
                UpdateInput();
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[4])
            {
                citiesToSolve = untouchedCities;
                Solver ff = new SolverLRFirstlyFirst(CitiesToSolve, new Tour(citiesToSolve));
                citiesToSolve = ff.Solve(citiesToSolve.ElementAt(0)).Cities;
                UpdateInput();
                updateSolvingButtonContent(itemSelected);
            }
            else if (itemSelected == presolvingItems[5])
            {
                citiesToSolve = untouchedCities;
                Solver md = new SolverLRBestSuccessor(CitiesToSolve, new Tour(citiesToSolve));
                citiesToSolve = md.Solve(citiesToSolve.ElementAt(0)).Cities;
                UpdateInput();
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
            btn.Margin = new Thickness(5, 0, 5, 0);
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

        private Grid GenerateSolutionBox()
        {
            Label lInput = GenerateLabel("Tournée d'input :");
            Label lOutput = GenerateLabel("Tournée calculée :");
            lInput.VerticalContentAlignment = VerticalAlignment.Bottom;
            lOutput.VerticalContentAlignment = VerticalAlignment.Bottom;
            Button randomizeBtn = RandomizeButton();
            this.solveButton = SolverButton();
            updateSolvingButtonContent(inputTourOption.SelectedItem.ToString());

            this.inputBox = TextBoxBasis();
            this.inputBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            this.inputBox.VerticalContentAlignment = VerticalAlignment.Top;
            this.outputBox = TextBoxBasis();
            Grid g = new Grid();

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(2.0, GridUnitType.Star);
            g.ColumnDefinitions.Add(col1);
            g.ColumnDefinitions.Add(col2);

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            row3.Height = new GridLength(5.0, GridUnitType.Star);
            g.RowDefinitions.Add(row1);
            g.RowDefinitions.Add(row2);
            g.RowDefinitions.Add(row3);

            g.Children.Add(lInput);
            g.Children.Add(lOutput);
            g.Children.Add(inputBox);
            g.Children.Add(outputBox);
            g.Children.Add(randomizeBtn);
            g.Children.Add(solveButton);

            Grid.SetColumn(lInput, 0);
            Grid.SetRow(lInput, 0);
            Grid.SetColumn(lOutput, 1);
            Grid.SetRow(lOutput, 0);

            Grid.SetColumn(randomizeBtn, 0);
            Grid.SetRow(randomizeBtn, 1);
            Grid.SetColumn(solveButton, 1);
            Grid.SetRow(solveButton, 1);

            Grid.SetColumn(this.inputBox, 0);
            Grid.SetRow(this.inputBox, 2);
            Grid.SetColumn(this.outputBox, 1);
            Grid.SetRow(this.outputBox, 2);

            return g;
        }

        private TextBox TextBoxBasis()
        {
            TextBox tb = new TextBox();
            tb.FontFamily = fontFamily;
            tb.Text = "Not Computed";
            tb.HorizontalContentAlignment = HorizontalAlignment.Center;
            tb.VerticalContentAlignment = VerticalAlignment.Center;
            float margin = 5;
            tb.Margin = new Thickness(margin, margin, margin, margin);
            tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE2E2E2"));
            return tb;
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

        private Button SolverButton()
        {
            Button b = ButtonBasis();
            b.FontSize = 12;
            b.Click += new RoutedEventHandler(Button_Click);
            return b;
        }

        protected void AlignSolutionBox()
        {
            outputBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            outputBox.VerticalContentAlignment = VerticalAlignment.Top;
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
