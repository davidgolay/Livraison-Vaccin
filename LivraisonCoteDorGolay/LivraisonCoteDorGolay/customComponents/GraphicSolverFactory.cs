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

        public static GraphicSolver Create(string name, MainWindow parentController)
        {
            GraphicSolver gs = null;
            switch (name)
            {
                case "plusProcheVoisin":
                    gs = new GraphicSolverNearestNeighboor(parentController);
                    gs.NameSolution = "PPV";
                    gs.AdditiveDescription = "";
                    break;

                case "plusProcheVoisinAméliore":
                    gs = new GraphicSolverNearestNeighborAdvanced(parentController);
                    gs.NameSolution = "PPV Amélioré";
                    gs.AdditiveDescription = "";
                    break;

                case "insertionProche" : 
                    gs = new GraphicSolverNearInsertion(parentController);
                    gs.NameSolution = "Insertion Proche";
                    gs.AdditiveDescription = "";
                    break;
                case "premierDabord":
                    gs = new GraphicSolverLRFF(parentController);
                    gs.NameSolution = "premier d'abord";
                    gs.AdditiveDescription = "";
                    break;
                default: gs = new GraphicSolverNearInsertion(parentController);
                    gs.NameSolution = "Insertion Proche";
                    gs.AdditiveDescription = "";
                    break;
            }

            return gs;
        }
    }
}
