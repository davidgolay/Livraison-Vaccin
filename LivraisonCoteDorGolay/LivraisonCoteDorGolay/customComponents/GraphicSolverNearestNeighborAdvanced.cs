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
        public GraphicSolverNearestNeighborAdvanced(MainWindow parentController) : base(parentController)
        {
        }

        protected override Tour OnSolveAction()
        {
            Solver solver = new SolverNearestNeighborAdvanced(CitiesToSolve);
            Tour solvedTour = solver.Solve(CitiesToSolve.ElementAt(0));
            AlignSolutionBox();
            return solvedTour;
        }
    }
}
