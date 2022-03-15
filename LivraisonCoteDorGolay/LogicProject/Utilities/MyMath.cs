using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.Utilities
{
    public class MyMath
    {
        public static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        }

        public static double GetDistanceBetweenDegreesCoordinates(double x1, double y1, double x2, double y2)
        {
            double distance = 0;
            double r = 6371;
            x1 = ConvertDegreesToRadians(x1);
            y1 = ConvertDegreesToRadians(y1);
            x2 = ConvertDegreesToRadians(x2);
            y2 = ConvertDegreesToRadians(y2);
            double op1 = Math.Sin(y1) * Math.Sin(y2);
            double op2 = Math.Cos(y1) * Math.Cos(y2) * Math.Cos(x1 - x2);
            distance = Math.Abs(r * Math.Acos(op1 + op2));
            return distance;
        }

        public static double GetMinimum(List<double> doubles)
        {
            double min = 0;
            foreach (double d in doubles)
            {
                if (d < min) min = d;
            }
            return min;
        }

        public static double GetMaximum(List<double> doubles)
        {
            double max = 0;
            foreach (double d in doubles)
            {
                if (d > max) max = d;
            }
            return max;
        }
    }
}
