using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public class GraphicSolverNearInsertion : GraphicSolver
    {
        public GraphicSolverNearInsertion(MainWindow parentController) : base(parentController)
        {
        }

        protected override Tour OnSolveAction()
        {
            Solver solver = new SolverNearInsertion(base.CitiesToSolve);
            Tour solvedTour = solver.Solve(base.CitiesToSolve.ElementAt(0));

            return solvedTour;
        }
    }
}
