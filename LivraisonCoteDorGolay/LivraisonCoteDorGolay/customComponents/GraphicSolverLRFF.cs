﻿using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDorGolay.customComponents
{
    public class GraphicSolverLRFF : GraphicSolver
    {
        public GraphicSolverLRFF(SolvingWindow sw) : base(sw)
        {
        }

        protected override Tour OnSolveAction()
        {
            throw new NotImplementedException();
        }
    }
}