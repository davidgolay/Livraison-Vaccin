using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LivraisonCoteDorGolay
{
    public abstract class GraphicSolver : Grid
    {
        private List<City> citiesToSolve;

        private string xName;
        private string solutionName;
        private string additiveDescription;

        private Label lName;
        private Label lAdditiveDescription;
        private Button solveButton;
        private TextBox solutionBox;
        private TextBox costBox;

        private FontFamily fontFamily = new FontFamily("Microsoft JhengHei");

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

        #endregion

        public GraphicSolver(List<City> cities)
        {
            this.citiesToSolve = cities;
        }

        protected abstract void OnSolveAction();

        private Label GenerateLabel(string value)
        {
            Label l = new Label();
            l.FontFamily = fontFamily;
            l.Content = value;
            return l;
        }

        private Grid GenerateCostGrid()
        {
            Label lCost = new Label();
            lCost.Content = "Cost :";
            lCost.VerticalAlignment = VerticalAlignment.Center;
            lCost.HorizontalAlignment = HorizontalAlignment.Right;
            lCost.FontSize = 16;
            lCost.SetValue(Label.FontWeightProperty, FontWeights.Bold);

            this.costBox = new TextBox();
            this.costBox.FontFamily = fontFamily;
            this.costBox.Padding = new Thickness(0, 0, 5, 0);


            // Define the Rows
            Grid g = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(3.0, GridUnitType.Star);
            g.ColumnDefinitions.Add(col1);
            g.ColumnDefinitions.Add(col2);

            //Adding children to grid
            g.Children.Add(lCost);
            g.Children.Add(this.costBox);

            Grid.SetColumn(lCost, 0);
            Grid.SetColumn(this.costBox, 1);

            return g;
        }

        private void GenerateSolutionBox()
        {
            this.solutionBox = new TextBox();
            solutionBox.FontFamily = fontFamily;
            solutionBox.Text = "Not Computed";
            solutionBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            solutionBox.VerticalContentAlignment = VerticalAlignment.Center;
            solutionBox.Padding = new Thickness(0, 0, 5, 0);
            this.Children.Add(solutionBox);
        }

        private void GenerateSolverButton()
        {
            this.solveButton = new Button();
            this.solveButton.Content = this.NameSolution;
            this.solveButton.Background = new SolidColorBrush(Colors.Red);

            this.solveButton.Click += new RoutedEventHandler(Button_Click);

            this.Children.Add(this.solveButton);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            OnSolveAction();
        }

        public void SolverGrid()
        {
            this.ShowGridLines = true;

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            rowDef2.Height = new GridLength(3.0, GridUnitType.Star);
            this.RowDefinitions.Add(rowDef1);
            this.RowDefinitions.Add(rowDef2);
            this.RowDefinitions.Add(rowDef3);
            this.RowDefinitions.Add(rowDef4);

            //Content generation
            Grid gTitle = GenerateTitleBox();
            GenerateSolutionBox();
            Grid costGrid = GenerateCostGrid();
            this.Children.Add(costGrid);
            GenerateSolverButton();

            Grid.SetRow(gTitle, 0);
            Grid.SetRow(solutionBox, 1);
            Grid.SetRow(costGrid, 2);
            Grid.SetRow(solveButton, 3);

            //Margin
            float margin = 5;
            this.Margin = new Thickness(margin, 0, margin, 0);
        }

        private Grid GenerateTitleBox()
        {
            lName = GenerateLabel(NameSolution);
            lName.FontSize = 14;
            lAdditiveDescription = GenerateLabel(AdditiveDescription);
            lAdditiveDescription.FontSize = 12;
            lName.SetValue(Label.FontWeightProperty, FontWeights.Bold);
            lAdditiveDescription.SetValue(Label.FontStyleProperty, FontStyles.Italic);

            Grid gTitle = new Grid();
            RowDefinition gTitlerowDef1 = new RowDefinition();
            RowDefinition gTitlerowDef2 = new RowDefinition();
            gTitle.RowDefinitions.Add(gTitlerowDef1);
            gTitle.RowDefinitions.Add(gTitlerowDef2);

            gTitle.Children.Add(this.lName);
            gTitle.Children.Add(this.lAdditiveDescription);
            Grid.SetRow(this.lName, 0);
            Grid.SetRow(this.lAdditiveDescription, 1);

            this.Children.Add(gTitle);
            return gTitle;
        }

        protected void AlignSolutionBox()
        {
            solutionBox.HorizontalContentAlignment = HorizontalAlignment.Left;
            solutionBox.VerticalContentAlignment = VerticalAlignment.Top;
        }
    }
}
