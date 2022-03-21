using LogicProject.algorithms;
using LogicProject.algorithms.localResearchs;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public class GraphicSolverBestSuccessor : GraphicSolver
    {
        public GraphicSolverBestSuccessor(MainWindow parentController) : base(parentController)
        {
        }

        protected override Tour OnSolveAction()
        {
            Solver solver = new SolverLRBestSuccessor(base.CitiesToSolve, new Tour(base.CitiesToSolve));
            Tour solvedTour = solver.Solve(base.CitiesToSolve.ElementAt(0));
            AlignSolutionBox();
            return solvedTour;
        }
    }
}
