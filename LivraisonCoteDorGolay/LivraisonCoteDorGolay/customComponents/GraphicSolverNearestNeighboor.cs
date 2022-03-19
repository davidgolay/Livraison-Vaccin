using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public class GraphicSolverNearestNeighboor : GraphicSolver
    {
        public GraphicSolverNearestNeighboor(MainWindow parentController) : base(parentController)
        {
        }

        protected override Tour OnSolveAction()
        {
            Solver solver = new SolverNearestNeighbor(CitiesToSolve);
            Tour solvedTour = solver.Solve(CitiesToSolve.ElementAt(0));
            AlignSolutionBox();
            return solvedTour;
        }
    }
}
