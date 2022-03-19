using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public class GraphicSolverNearestNeighborAdvanced : GraphicSolver
    {
        public GraphicSolverNearestNeighborAdvanced(List<City> cities) : base(cities)
        {
        }

        protected override void OnSolveAction()
        {
            Solver solver = new SolverNearestNeighborAdvanced(CitiesToSolve);
            Tour solvedTour = solver.Solve(CitiesToSolve.ElementAt(0));
            SolutionBox.Text = solvedTour.DisplayTour();
            CostBox.Text = Math.Round(solvedTour.Cost, 4).ToString();

            AlignSolutionBox();
        }
    }
}
