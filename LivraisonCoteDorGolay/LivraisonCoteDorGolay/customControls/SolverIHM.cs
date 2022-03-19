using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LivraisonCoteDorGolay.customControls
{
    public class SolverIHM : Control
    {
        private Label solutionName;
        private Label additiveName;

        static SolverIHM()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SolverIHM), new FrameworkPropertyMetadata(typeof(SolverIHM)));

        }

        public override void OnApplyTemplate()
        {
            solutionName = Template.FindName("solutionName", this) as Label;
            additiveName = Template.FindName("additiveName", this) as Label;
            initFields();
            base.OnApplyTemplate();
        }

        private void initFields()
        {

        }

        public void SetName(string name)
        {
            solutionName.Content = name;
        }

        public void SetAdditiveDescription(string description)
        {
            solutionName.Content = description;
        }
    }
}
