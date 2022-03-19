using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public static class GraphicSolverFactory
    {

        public static GraphicSolver Create(string name,  SolvingWindow parent)
        {
            GraphicSolver gs = null;
            switch (name)
            {
                case "plusProcheVoisin":
                    gs = new GraphicSolverNearestNeighboor(parent);
                    gs.NameSolution = "PPV";
                    gs.AdditiveDescription = "";
                    break;

                case "plusProcheVoisinAméliore":
                    gs = new GraphicSolverNearestNeighborAdvanced(parent);
                    gs.NameSolution = "PPV Amélioré";
                    gs.AdditiveDescription = "";
                    break;

                case "insertionProche" : 
                    gs = new GraphicSolverNearInsertion(parent);
                    gs.NameSolution = "Insertion Proche";
                    gs.AdditiveDescription = "";
                    break;
                default: gs = new GraphicSolverNearInsertion(parent);
                    break;
            }

            return gs;
        }
    }
}
