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
    class GraphicSolverLRMeilleurQuelconque : GraphicSolver
    {
        public GraphicSolverLRMeilleurQuelconque(MainWindow parentController) : base(parentController)
        {
        }

        protected override Tour OnSolveAction()
        {
            Solver solver = new SolverLRMeilleurQuelconque(CitiesToSolve, new Tour(base.CitiesToSolve));
            Tour solvedTour = solver.Solve(CitiesToSolve.ElementAt(0));
            AlignSolutionBox();
            return solvedTour;
        }
    }
}
