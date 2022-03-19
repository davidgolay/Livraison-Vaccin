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
        public static GraphicSolver Create(string name,  List<City> cities)
        {
            GraphicSolver gs = null;
            switch (name)
            {
                case "plusProcheVoisin":
                    gs = new GraphicSolverNearestNeighboor(cities);
                    gs.NameSolution = "Plus proche voisin";
                    gs.AdditiveDescription = "---";
                    break;

                case "plusProcheVoisinAméliore":
                    gs = new GraphicSolverNearestNeighborAdvanced(cities);
                    gs.NameSolution = "Plus proche voisin amélioré";
                    gs.AdditiveDescription = "---";
                    break;

                case "insertionProche" : 
                    gs = new GraphicSolverNearInsertion(cities);
                    gs.NameSolution = "Insertion Proche";
                    gs.AdditiveDescription = "---";
                    break;
                default: gs = new GraphicSolverNearInsertion(cities);
                    break;
            }

            return gs;
        }
    }
}
